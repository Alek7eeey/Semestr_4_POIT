#include "stdafx.h"
#include "CApp.h"
CApp App;
BOOL CApp::InitInstance()
{
	m_pMainWnd = new CMainWin; // создать класс окна
	m_pMainWnd->ShowWindow(5); // Показать окно
	m_pMainWnd->UpdateWindow(); // Обновить окно
	return TRUE;
}
