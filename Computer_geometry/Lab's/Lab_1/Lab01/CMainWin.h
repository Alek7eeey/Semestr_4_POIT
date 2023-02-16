#pragma once
#include "stdafx.h"
#include "resource.h"

class CMainWin : public CFrameWnd
{
	int The_Value_Menu = 0; // ѕеременна€ обрабатывающа€с€ switch-ом
	// дл€ запуска определЄнной функции, выбранной пользователем

public:
	CMainWin();//  онструктор CMainWin объ€вленный в библеотеке дл€ взаимодействи€ с окном W
	
	void OnPaint();
	// ќбъ€вление функций отвечающих за обработку событий
	void F_C1();
	void F_C2();
	void F_D();
	void F_Q();
	void F_P();
	void F_V_Mult();
	void F_Sc_Mult();
	void F_MOD_V();
  void F_COs_V1_V2();
	void F_SP_T_Cart();

	DECLARE_MESSAGE_MAP()//ќбъ€вл€ет, что виртуальной схемы сообщений будет использоватьс€ в классе 
	//дл€ сопоставлени€ сообщений к функци€м
};
