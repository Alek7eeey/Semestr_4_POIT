#pragma once
#include "stdafx.h"
#include "resource.h"

class CMainWin : public CFrameWnd
{
	int The_Value_Menu = 0; // ���������� ���������������� switch-��
	// ��� ������� ����������� �������, ��������� �������������

public:
	CMainWin();// ����������� CMainWin ����������� � ���������� ��� �������������� � ����� W
	
	void OnPaint();
	// ���������� ������� ���������� �� ��������� �������
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

	DECLARE_MESSAGE_MAP()//���������, ��� ����������� ����� ��������� ����� �������������� � ������ 
	//��� ������������� ��������� � ��������
};
