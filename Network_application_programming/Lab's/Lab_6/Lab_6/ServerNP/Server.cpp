#include <iostream>
#include <Windows.h>
#include <string>
using namespace std;

string SetPipeError(string msgText, int code);
string GetPipeError(int code);

void main()
{
	HANDLE hPipe;
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	try
	{

        //create and connect
		if ((hPipe = CreateNamedPipe(TEXT("\\\\.\\pipe\\Tube"),  /*экранирование*/
			PIPE_ACCESS_DUPLEX,
			PIPE_TYPE_MESSAGE | PIPE_WAIT,
			1,
			NULL, NULL,
			INFINITE,
			NULL)) == INVALID_HANDLE_VALUE)
		{
			throw SetPipeError("create: ", GetLastError());
		}
		else
		{
			cout << "Именнованный канал создан..." << endl;
		}

		if (!ConnectNamedPipe(hPipe, NULL))
		{
			throw SetPipeError("connect: ", GetLastError());
		}
        else
        {
            cout << "Клиент к экземпляру именованного канала подключён..." << endl;
        }

        //read and write message
        char buf[200];
        DWORD byteSize = sizeof(buf)*2;
        int i = 0;
        char bufWr[] = "Hello from server: ";
        DWORD byteSize2 = sizeof(bufWr) * 2;

        while (true)
        {
            if (!ReadFile(hPipe, buf, sizeof(buf), &byteSize, NULL))
            {
                throw SetPipeError("read: ", GetLastError());
            }
            else
            {
                if (strcmp(buf, "end") == 0)
                {
                    break;
                }

                cout << buf <<": " << i << endl;
            }

            if (!WriteFile(hPipe, bufWr, sizeof(bufWr), &byteSize2, NULL))
            {
                throw SetPipeError("write: ", GetLastError());
            }
           
            i++;
        }
        

        //char bufWr[] = "Hello, client! You are connected to the server!";
        //char buf[200];
        //DWORD byteSize = sizeof(buf);
        //if (!ReadFile(hPipe, buf, sizeof(buf), &byteSize, NULL))
        //{
        //    throw SetPipeError("read: ", GetLastError());
        //}
        //else
        //{
        //    cout << "Сообщение от клиента канала: ";
        //    for (int i = 0; i < byteSize; i++)
        //    {
        //        cout << buf[i];
        //    }
        //    cout << endl;
        //}

        //DWORD byteSize2 = sizeof(bufWr);
        //if (!WriteFile(hPipe, bufWr, sizeof(bufWr), &byteSize2, NULL))
        //{
        //    throw SetPipeError("write: ", GetLastError());
        //}
        //else
        //{
        //    cout << "Сообщение отправлено серверу!" << endl;
        //}

        //disconnect and remove
        if (!DisconnectNamedPipe(hPipe))
        {
            throw SetPipeError("disconnect: ", GetLastError());
        }

        if (!CloseHandle(hPipe))
        {
            throw SetPipeError("close: ", GetLastError());
        }
	}

	catch (string ErrorPipeText)
	{
		cout << "\nОшибка: " << ErrorPipeText;
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
