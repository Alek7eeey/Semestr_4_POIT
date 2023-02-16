//отвечает за работу программы
#pragma once
#include "stdafx.h"
#include "CMainWin.h"
class CApp : public CWinApp
{
public: //точка входа в приложение
	BOOL InitInstance(); 
};
