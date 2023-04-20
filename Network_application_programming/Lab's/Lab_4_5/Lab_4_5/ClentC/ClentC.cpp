#pragma comment(lib, "WS2_32.lib") 
#pragma warning(disable: 4996)
#include "Winsock2.h"
#include <string>
#include <algorithm>
#include <iostream>

using namespace std;

string SetErrorMsgText(string msgText, int code);
string GetErrorMsgText(int code);
bool  GetServerByName(const char* name, const char* call, struct sockaddr* from, int* flen);

void main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	SOCKET cS;
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		//............................................................
		if ((cS = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());
		//.............................................................	

		sockaddr from;
		int length = sizeof(from);
		GetServerByName("Petya1", "Hello", &from, &length);

		if (closesocket(cS) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket:", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << "WSAGetLastError: " << errorMsgText;
	}
}

bool  GetServerByName(const char* name, const char* call, struct sockaddr* from, int* flen)
{
	SOCKET sS = socket(AF_INET, SOCK_DGRAM, NULL);

	auto host = gethostbyname(name);
	if (!host)
		throw SetErrorMsgText("gethostbyname:", WSAGetLastError());

	char* ip_addr = inet_ntoa(*(in_addr*)(host->h_addr));
	cout << "\n��� �����: " << host->h_name;
	cout << "\nIP �������: " << ip_addr;

	SOCKADDR_IN server;
	server.sin_family = AF_INET;
	server.sin_port = htons(2000);
	server.sin_addr.s_addr = inet_addr(ip_addr);
	char message[10];

	if (sendto(sS, call, strlen(call), NULL, (const sockaddr*)&server, *flen) == SOCKET_ERROR)
		throw SetErrorMsgText("sendto:", WSAGetLastError());
	int buf = 0;

	if ((buf = recvfrom(sS, message, sizeof(message), NULL, (sockaddr*)&server, flen)) == SOCKET_ERROR)
		throw SetErrorMsgText("recvfrom:", WSAGetLastError());

	message[buf] = 0x00;
	cout << "\n��������� �� �������: " << message << "\n";
	*from = *((sockaddr*)&server);
	closesocket(sS);
	return true;
}
string  SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
}

string  GetErrorMsgText(int code)    // c����������� ����� ������ 
{

	string msgText;
	switch (code)
	{
	case WSAEINTR:         msgText = "������ ������� ��������\n";              break;
	case WSAEACCES:         msgText = "���������� ����������\n";              break;
	case WSAEFAULT:         msgText = "��������� �����\n";                  break;
	case WSAEINVAL:         msgText = "������ � ���������\n";                break;
	case WSAEMFILE:         msgText = "������� ����� ������ �������\n";          break;
	case WSAEWOULDBLOCK:     msgText = "������ �������� ����������\n";            break;
	case WSAEINPROGRESS:     msgText = "�������� � �������� ��������\n";          break;
	case WSAEALREADY:        msgText = "�������� ��� �����������\n";            break;
	case WSAENOTSOCK:        msgText = "����� ����� �����������\n";              break;
	case WSAEDESTADDRREQ:     msgText = "��������� ����� ������������\n";          break;
	case WSAEMSGSIZE:         msgText = "��������� ������� �������\n";              break;
	case WSAEPROTOTYPE:       msgText = "������������ ��� ��������� ��� ������\n";      break;
	case WSAENOPROTOOPT:     msgText = "������ � ����� ���������\n";            break;
	case WSAEPROTONOSUPPORT:   msgText = "�������� �� ��������������\n";            break;
	case WSAESOCKTNOSUPPORT:   msgText = "��� ������ �� ��������������\n";          break;
	case WSAEOPNOTSUPP:       msgText = "�������� �� ��������������\n";            break;
	case WSAEPFNOSUPPORT:     msgText = "��� ���������� �� ��������������\n";        break;
	case WSAEAFNOSUPPORT:     msgText = "��� ������� �� �������������� ����������\n";    break;
	case WSAEADDRINUSE:       msgText = "����� ��� ������������\n";              break;
	case WSAEADDRNOTAVAIL:     msgText = "����������� ����� �� ����� ���� �����������\n";    break;
	case WSAENETDOWN:       msgText = "���� ���������\n";                  break;
	case WSAENETUNREACH:     msgText = "���� �� ���������\n";                break;
	case WSAENETRESET:       msgText = "���� ��������� ����������\n";            break;
	case WSAECONNABORTED:     msgText = "����������� ����� �����\n";              break;
	case WSAECONNRESET:       msgText = "����� �������������\n";                break;
	case WSAENOBUFS:       msgText = "�� ������� ������ ��� �������\n";          break;
	case WSAEISCONN:       msgText = "����� ��� ���������\n";                break;
	case WSAENOTCONN:       msgText = "����� �� ���������\n";                break;
	case WSAESHUTDOWN:       msgText = "������ ��������� send: ����� �������� ������\n";  break;
	case WSAETIMEDOUT:       msgText = "���������� ���������� ��������  �������\n";      break;
	case WSAECONNREFUSED:     msgText = "���������� ���������\n";              break;
	case WSAEHOSTDOWN:       msgText = "���� � ����������������� ���������\n";        break;
	case WSAEHOSTUNREACH:     msgText = "��� �������� ��� �����\n";              break;
	case WSAEPROCLIM:       msgText = "������� ����� ���������\n";              break;
	case WSASYSNOTREADY:     msgText = "���� �� ��������\n";                break;
	case WSAVERNOTSUPPORTED:   msgText = "������ ������ ����������\n";            break;
	case WSANOTINITIALISED:     msgText = "�� ��������� ������������� WS2_32.DLL\n";      break;
	case WSAEDISCON:       msgText = "����������� ����������\n";              break;
	case WSATYPE_NOT_FOUND:     msgText = "����� �� ������\n";                  break;
	case WSAHOST_NOT_FOUND:     msgText = "���� �� ������\n";                  break;
	case WSAEINVALIDPROCTABLE:   msgText = "��������� ������\n";                break;
	case WSAEINVALIDPROVIDER:   msgText = "������ � ������ �������\n";              break;
	case WSAEPROVIDERFAILEDINIT: msgText = "���������� ���������������� ������\n";        break;
	case WSASYSCALLFAILURE:     msgText = "��������� ���������� ���������� ������\n";      break;
	case WSATRY_AGAIN:       msgText = "������������������ ���� �� ������\n";        break;
	case WSANO_RECOVERY:     msgText = "�������������� ������\n";              break;
	case WSANO_DATA:       msgText = "��� ������ ������������ ����\n";          break;
	default:           msgText = "������ �� ����������\n";              break;
	}
	return msgText;
}