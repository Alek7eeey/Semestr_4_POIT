#include "stdafx.h"
#include "CApp.h"

CApp App; //класс, предназначенный дл€ создани€ приложени€

bool CApp::InitInstance()// «апускаем приложение 
{
	m_pMainWnd = new CMainWin;
	m_pMainWnd->ShowWindow(sw_restore);// открываем
	m_pMainWnd->UpdateWindow();// ƒелаем его активным
	return true;
}
