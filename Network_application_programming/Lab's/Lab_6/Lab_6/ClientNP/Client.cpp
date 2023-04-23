#include <Windows.h>
#include <iostream>
#include <string>
using namespace std;

string SetPipeError(string msgText, int code);
string GetPipeError(int code);

void main()
{
	HANDLE hPipe;
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

	try 
    {
        //connect
        if (!WaitNamedPipe(TEXT("\\\\Petya\\pipe\\Tube"), NMPWAIT_USE_DEFAULT_WAIT))
        {
            throw SetPipeError("waiting: ", GetLastError());
        }

        if ((hPipe = CreateFile(TEXT("\\\\Petya\\pipe\\Tube"),
            GENERIC_READ | GENERIC_WRITE,
            FILE_SHARE_READ | FILE_SHARE_WRITE,
            NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE)
        {
            throw SetPipeError("create: ", GetLastError());
        }

        //write and read
        char strRead[100];
        //cin >> str;
        int count;
        cout << "Введите количество сообщений: ";
        cin >> count;
        char str[] = "Hello from client";

        DWORD byteSize = sizeof(str)*2;
        int i = 0;
        while (i < count)
        {
            if (!WriteFile(hPipe, str, sizeof(str), &byteSize, NULL))
            {
                throw SetPipeError("write: ", GetLastError());
            }

            DWORD byteSize2 = sizeof(strRead)*2;
            if (!ReadFile(hPipe, strRead, sizeof(strRead), &byteSize2, NULL))
            {
                throw SetPipeError("read: ", GetLastError());
            }

            else
            {
                cout << strRead << i << endl;
            }
            i++;
        }

        char end[10] = "end";
        DWORD byteSize3 = sizeof(end);
        if (!WriteFile(hPipe, end, sizeof(end), &byteSize3, NULL))
        {
            throw SetPipeError("write: ", GetLastError());
        }

      /*  if (!WriteFile(hPipe, str, sizeof(str), &byteSize, NULL))
        {
            throw SetPipeError("write: ", GetLastError());
        }
        else
        {
            cout << "Сообщение отправлено!" << endl;
        }

        DWORD byteSize2 = sizeof(strRead);
        if (!ReadFile(hPipe, strRead, sizeof(strRead), &byteSize2, NULL))
        {
            throw SetPipeError("read: ", GetLastError());
        }

        else
        {
            cout << "Сообщение от сервера: ";

            cout << strRead << endl;
        }*/
	}

	catch(string ErrorPipeText)
	{
        cout << endl << ErrorPipeText;
	}
}

string SetPipeError(string msgText, int code)
{
    return msgText + GetPipeError(code);
}

string GetPipeError(int code)
{
    string msgText;
    switch (code)
    {
    case WSAEINTR:
        msgText = "Function interrupted";
        break;
    case WSAEACCES:
        msgText = "Permission denied";
        break;
    case WSAEFAULT:
        msgText = "Wrong address";
        break;
    case WSAEINVAL:
        msgText = "Wrong args";
        break;
    case WSAEMFILE:
        msgText = "Too many files have opened";
        break;
    case WSAEWOULDBLOCK:
        msgText = "Resource temporarily unavailable";
        break;
    case WSAEINPROGRESS:
        msgText = "Operation in progress";
        break;
    case WSAEALREADY:
        msgText = "Operation already in progress";
        break;
    case WSAENOTSOCK:
        msgText = "Wrong socket";
        break;
    case WSAEDESTADDRREQ:
        msgText = "Required adress location";
        break;
    case WSAEMSGSIZE:
        msgText = "Message is too long ";
        break;
    case WSAEPROTOTYPE:
        msgText = "Wrong protocol type to socket";
        break;
    case WSAENOPROTOOPT:
        msgText = "Error in protocol option";
        break;
    case WSAEPROTONOSUPPORT:
        msgText = "Protocol is not supported";
        break;
    case WSAESOCKTNOSUPPORT:
        msgText = "Socket type is not supported";
        break;
    case WSAEOPNOTSUPP:
        msgText = "Operation is not supported";
        break;
    case WSAEPFNOSUPPORT:
        msgText = "Protocol type is not supported";
        break;
    case WSAEAFNOSUPPORT:
        msgText = "Addresses type is not supported by protocol";
        break;
    case WSAEADDRINUSE:
        msgText = "Address is already used";
        break;
    case WSAEADDRNOTAVAIL:
        msgText = "Requested address cannot be used";
        break;
    case WSAENETDOWN:
        msgText = "Network disconnected";
        break;
    case WSAENETUNREACH:
        msgText = "Network is unttainable";
        break;
    case WSAENETRESET:
        msgText = "Network dropped the connection";
        break;
    case WSAECONNABORTED:
        msgText = "Connection aborted";
        break;
    case WSAECONNRESET:
        msgText = "Connection restored";
        break;
    case WSAENOBUFS:
        msgText = "Not enough memory for buffers";
        break;
    case WSAEISCONN:
        msgText = "Socket has already connected";
        break;
    case WSAENOTCONN:
        msgText = "Socket has not connected";
        break;
    case WSAESHUTDOWN:
        msgText = "Send cannot be performed: socket was shutdowned";
        break;
    case WSAETIMEDOUT:
        msgText = "Alloted time interval has ended";
        break;
    case WSAECONNREFUSED:
        msgText = "Connection was rejected";
        break;
    case WSAEHOSTDOWN:
        msgText = "Host was shotdowned";
        break;
    case WSAEHOSTUNREACH:
        msgText = "Has not way for host";
        break;
    case WSAEPROCLIM:
        msgText = "Too many processes";
        break;
    case WSASYSNOTREADY:
        msgText = "Network is unavailable";
        break;
    case WSAVERNOTSUPPORTED:
        msgText = "Version is not supported";
        break;
    case WSANOTINITIALISED:
        msgText = "WS2_32.dll is not initialised";
        break;
    case WSAEDISCON:
        msgText = "Connection in progress";
        break;
    case WSATYPE_NOT_FOUND:
        msgText = "Type is not found";
        break;
    case WSAHOST_NOT_FOUND:
        msgText = "Host is not found";
        break;
    case WSATRY_AGAIN:
        msgText = "Try again";
        break;
    case WSANO_RECOVERY:
        msgText = "Unknown error";
        break;
    case WSANO_DATA:
        msgText = "Has not data type";
        break;
    case WSAEINVALIDPROCTABLE:
        msgText = "Invalid provider";
        break;
    case WSAEINVALIDPROVIDER:
        msgText = "Error in provider version";
        break;
    case WSAEPROVIDERFAILEDINIT:
        msgText = "Failed provider initialization";
        break;
    case WSASYSCALLFAILURE:
        msgText = "Abnormal termination of a system call";
        break;
    default:
        msgText = "Unknown error";
        break;
    }
    return msgText;
}