#include "stdafx.h"
#include "CApp.h"
CApp App;
BOOL CApp::InitInstance()
{
	m_pMainWnd = new CMainWin; // ������� ����� ����
	m_pMainWnd->ShowWindow(5); // �������� ����
	m_pMainWnd->UpdateWindow(); // �������� ����
	return TRUE;
}
