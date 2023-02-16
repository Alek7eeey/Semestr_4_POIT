#pragma once
#include "stdafx.h"
#include "resource.h"
class CMainWin : public CFrameWnd
{
private:
	int MenuClick;
public:
	CMainWin();
	afx_msg void OnPaint(); //функция, которая обработает вызов меню, в класс рамки окна
	afx_msg void CalcC1();
	afx_msg void CalcC2();
	afx_msg void CalcD();
	afx_msg void CalcQ();
	afx_msg void CalcP();
	afx_msg void VEctorMult();
	afx_msg void SCalarMult();
	afx_msg void MOdVec();
	afx_msg void COsV1V2();
	afx_msg void SPhereToCart();
	afx_msg void Clear();
	DECLARE_MESSAGE_MAP()
};
