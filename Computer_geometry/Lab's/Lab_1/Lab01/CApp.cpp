#include "stdafx.h"
#include "CApp.h"

CApp App; //�����, ��������������� ��� �������� ����������

bool CApp::InitInstance()// ��������� ���������� 
{
	m_pMainWnd = new CMainWin;
	m_pMainWnd->ShowWindow(sw_restore);// ���������
	m_pMainWnd->UpdateWindow();// ������ ��� ��������
	return true;
}
