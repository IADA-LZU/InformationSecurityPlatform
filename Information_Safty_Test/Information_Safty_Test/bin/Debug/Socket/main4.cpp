#include <stdio.h>
#include <winsock2.h>
#define BUFFER_SIZE 1024
#define PORT1 
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
    ClientAddr.sin_port=htons(PORT1);
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
    char IP[100];
    SOCKET sock;
    printf("Input server IP:");
    scanf("%s",IP);
    sock=con(IP);
    FILE *file=fopen(".\\Conio log.txt","w");
    while(recv(sock,buf,BUFFER_SIZE,0)!=-1)
    {
        fprintf(file,"%s ",buf);
        printf("%s ",buf);
        memset(buf,0,BUFFER_SIZE);
    }
    fclose(file);
    printf("\nThe information of conio control has been writen to Conio log.txt.\n");
    closesocket(sock);
    WSACleanup();
    system("pause");
    return 0;
}
