#include <winsock2.h>
#include <stdio.h>
#define PORT1 15001
#define PORT2 8800
#define BUFFER_SIZE 1024
#define FILE_SIZE 1024
void Rec()
{
  SOCKET sock2;
  WSAData WSAData;
  SOCKADDR_IN ServerAddr;
  SOCKET msgsock;
  if(WSAStartup(MAKEWORD(2,2),&WSAData)==SOCKET_ERROR)
  {
    //printf("Socket initialize fail!\n");
    exit(1);
  }
  if((sock2=socket(AF_INET,SOCK_STREAM,0))==ERROR)
  {
    //printf("Socket create fail!\n");
    WSACleanup();
    exit(1);
  }
  ServerAddr.sin_family=AF_INET;
  ServerAddr.sin_port=htons(PORT1);
  ServerAddr.sin_addr.s_addr=INADDR_ANY;
  if(bind(sock2,(LPSOCKADDR)&ServerAddr,sizeof(ServerAddr))==SOCKET_ERROR)
  {
    //printf("Bind fail!\n");
    closesocket(sock2);
    WSACleanup();
    exit(1);
  }
  //printf("Server Socket Port:%d\n",ntohs(ServerAddr.sin_port));
  if(listen(sock2,10)==SOCKET_ERROR)
  {
    //printf("Listen fail!\n");
    closesocket(sock2);
    WSACleanup();
    exit(1);
  }
  char buf[BUFFER_SIZE];
  if((msgsock=accept(sock2,(LPSOCKADDR)0,(int *)0))==INVALID_SOCKET)
  {
      //printf("Accept fail!\n");
      exit(1);
    }

    while(1)
    {
        int Num=0;
        memset(buf,0,sizeof(buf));
        Num=recv(msgsock,buf,BUFFER_SIZE,0);
        printf("%s",buf);
        if(Num<BUFFER_SIZE)
            break;
    }
    closesocket(msgsock);
    closesocket(sock2);
    WSACleanup();
}
SOCKET con(char IP[])
{
    SOCKET sock;
    WSADATA WSAData;
    SOCKADDR_IN ClientAddr;
    if(WSAStartup(MAKEWORD(2,2),&WSAData)==SOCKET_ERROR)
    {
      printf("Socket initialize fail!\n");
      exit(1);
    }
    if((sock=socket(AF_INET,SOCK_STREAM,0))==SOCKET_ERROR)
    {
      printf("Socket create fail!\n");
      WSACleanup();
      system("pause");
      exit(1);
    }
    ClientAddr.sin_family=AF_INET;
    ClientAddr.sin_port=htons(PORT2);
    ClientAddr.sin_addr.s_addr=inet_addr(IP);
    if(connect(sock,(LPSOCKADDR)&ClientAddr,sizeof(ClientAddr))==SOCKET_ERROR)
    {
      printf("Connect fail!\n");
      closesocket(sock);
      WSACleanup();
      system("pause");
      exit(1);
    }
    return sock;
}
int main()
{
  char buf[BUFFER_SIZE];
  char buf2[BUFFER_SIZE];
  int inputLen;
  char IP[100];

  SOCKET sock;

  char Point;
  printf("Would you like to be online and wait for server being online?(Y or N)");
  fflush(stdin);
  Point=getchar();
  //scanf("%c",&Point);
  if(Point=='Y' || Point=='y')
  {
      printf("Waiting...\n");
      Rec();
  }

  printf("Input server IP:");
  scanf("%s",IP);
  while(1)
  {
    inputLen=0;
    memset(buf,0,sizeof(buf));
    printf("Socket\\Client>");
    fflush(stdin);
    while((buf[inputLen]=getchar())!='\n')
    {
      inputLen++;
    }
    buf[inputLen]='\0';
    if(buf[0]=='e' && buf[1]=='x' && buf[2]=='i' && buf[3]=='t')
    {
        printf("Server off line.\n");
        sock=con(IP);
        send(sock,buf,BUFFER_SIZE,0);
        break;

    }
    else if(buf[0]=='s' && buf[1]=='e' && buf[2]=='n' && buf[3]=='d')
    {

        char fileFromName[100];
        int i=0,m=0;
        while(buf[i]!=' ')
        {
            i++;
        }
        i++;
        while(buf[i]!=' ')
        {
            fileFromName[m]=buf[i];
            m++;
            i++;
        }
        fileFromName[m]='\0';
        FILE *file;
        if((file=fopen(fileFromName,"rb"))==NULL)
        {
            printf("File acess error!\n");
        }
        else
        {
            int sendLength=0;
            int readNow,sendNow;
            char filec[FILE_SIZE];
            sock=con(IP);
            send(sock,buf,BUFFER_SIZE,0);
            while((readNow=fread(&filec[0],1,FILE_SIZE,file))!=0)
            {
                sendNow=send(sock,filec,readNow,0);
                memset(filec,0,FILE_SIZE);
                sendLength+=sendNow;
                printf("Send %d\n",sendNow);
            }
            printf("Send finished！file：%s Size: %d KB\n",fileFromName,sendLength/1024);

        }
        fclose(file);
    }
    else if(buf[0]=='r' && buf[1]=='e' && buf[2]=='c' && buf[3]=='v')
    {
        sock=con(IP);
        send(sock,buf,BUFFER_SIZE,0);
        int i=0,j=0;
        char pathc[100];
        while(buf[i]!=' ')
        {
            i++;
        }
        i++;
        while(buf[i]!=' ')
        {
            i++;
        }
        i++;
        while(buf[i]!='\0')
        {
            pathc[j]=buf[i];
            i++;
            j++;
        }
        pathc[j]='\0';
        FILE *file=fopen(pathc,"wb");
        char filec[FILE_SIZE];
        int RecvNow,RecvLongth=0;
        while(1)
        {
            RecvNow=recv(sock,&filec[0],FILE_SIZE,0);
            fwrite(filec, FILE_SIZE, sizeof(char), file);
            RecvLongth+=RecvNow;
            printf("Recive %d\n",RecvNow);
            if(RecvNow<FILE_SIZE)
            {
                fclose(file);
                break;
            }
            memset(filec,0,FILE_SIZE);
        }
        printf("Recive finish！File path:%s Size:%d KB\n",pathc,RecvLongth/1024);

    }
    else
    {
        sock=con(IP);
        send(sock,buf,BUFFER_SIZE,0);
        char ch;
        printf("Would you like to get the back info from server CMD?(Y or N)");
        fflush(stdin);
        ch=getchar();
        if(ch=='Y' || ch=='y')
        {

            while(1)
            {
                int Num=0;
                memset(buf2,0,sizeof(buf2));
                Num=recv(sock,buf2,BUFFER_SIZE,0);
                printf("%s",buf2);
                if(Num<BUFFER_SIZE)
                    break;
            }

        }

    }

    //closesocket(msgsock);
    closesocket(sock);
    WSACleanup();

  }
  return 0;
}
