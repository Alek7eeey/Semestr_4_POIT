#include "stdafx.h"
#include "CMainWin.h"
#include "CMatrix.h"
#include <string.h>
#include <string>

CMainWin::CMainWin()
{
	this->Create(0, (LPCTSTR)L"KGIG", WS_OVERLAPPEDWINDOW, rectDefault, 0, (LPCTSTR)IDR_MENU1);
}

void CMainWin::OnPaint()
{
	CPaintDC DC(this);

	CMatrix A(3, 3), 
		    B(3, 3),
		    V1(3),V2(3);

	for (int i = 0; i < A.rows(); i++)
	{
		for (int j = 0; j < A.cols(); j++)
		{
			A(i, j) = i + j*2;
			B(i, j) = i + j + 10;
		}
		V1(i) = i + 10;
		V2(i) = i * 2;
	}

	CMatrix V3 = VectorMult(V1, V2);

	CMatrix V4(3);

	V4(0) = 3; V4(1) = 60; V4(2) = 90;

	double Scalar = ScalarMult(V1, V2),
		modvec = ModVec(V1),
		cosv1v2 = CosV1V2(V1, V2);

	std::string strScalarMult = std::to_string(Scalar),
		strModVec = std::to_string(modvec),
		strCosV1V2 = std::to_string(cosv1v2);

	char *str_scal, *str_mod, *str_cos;

	switch (The_Value_Menu)
	{
	case  C1:
		DC.TextOutW(100, 40, CString("A")); PrintMatrix(DC, 100, 60, A);
		
		DC.TextOutW(300, 40, CString("B")); PrintMatrix(DC, 300, 60, B);
		
		DC.TextOutW(550, 40, CString("C1 = A + B")); PrintMatrix(DC, 550, 60, A+B);
		break;
	case C2:
		DC.TextOutW(100, 40, CString("A")); PrintMatrix(DC, 100, 60, A);
		
		DC.TextOutW(300, 40, CString("B")); PrintMatrix(DC, 300, 60, B);
		
		DC.TextOutW(550, 40, CString("C1 = A * B")); PrintMatrix(DC, 550, 60, A * B);
		break;
	case D:
		DC.TextOutW(100, 40, CString("A")); PrintMatrix(DC, 100, 60, A);
		
		DC.TextOutW(300, 40, CString("V1")); PrintMatrix(DC, 300, 60, V1);
		
		DC.TextOutW(450, 40, CString("D = A * V1")); PrintMatrix(DC, 450, 60, A * V1);
		break;
	case Q:
		DC.TextOutW(50, 100, CString("V1")); PrintMatrix(DC, 50, 120, V1);
		
		DC.TextOutW(150, 100, CString("V1^T")); PrintMatrix(DC, 150, 120, V1.Transp());
		
		DC.TextOutW(500, 100, CString("V2")); PrintMatrix(DC, 500, 120, V2);
		
		DC.TextOutW(630, 100, CString("q = V1^T * V2")); PrintMatrix(DC, 630, 120, V1.Transp() * V2);
		break;
	case P:
		DC.TextOutW(100, 100, CString("V1")); PrintMatrix(DC, 100, 120, V1);
		
		DC.TextOutW(200, 100, CString("V1^T")); PrintMatrix(DC, 200, 120, V1.Transp());
		
		DC.TextOutW(425, 100, CString("A")); PrintMatrix(DC, 425, 120, A);
		
		DC.TextOutW(630, 100, CString("V2")); PrintMatrix(DC, 630, 120, V2);
		
		DC.TextOutW(720, 100, CString("q = V1^T * A * V2"));PrintMatrix(DC, 720, 120, V1.Transp() * A * V2);
		break;
	case VECTORMULT:
		DC.TextOutW(100, 100, CString("V1")); PrintMatrix(DC, 100, 120, V1);
		
		DC.TextOutW(200, 100, CString("V2")); PrintMatrix(DC, 200, 120, V2);
		
		DC.TextOutW(300, 100, CString("VectorMult")); PrintMatrix(DC, 300, 120, V3);
		break;
	case SCALARMULT:
		DC.TextOutW(100, 100, CString("V1")); PrintMatrix(DC, 100, 120, V1);
		
		DC.TextOutW(200, 100, CString("V2")); PrintMatrix(DC, 200, 120, V2);
		
		DC.TextOutW(300, 100, CString("ScalarMult"));
		
		str_scal = (char*)strScalarMult.c_str();
		DC.TextOutW(300, 120, CString(str_scal));
		break;
	case MODVEC:
		DC.TextOutW(100, 100, CString("V1")); PrintMatrix(DC, 100, 120, V1);
		DC.TextOutW(200, 100, CString("ModVec"));
		
		str_mod = (char*)strModVec.c_str();
		DC.TextOutW(200, 120, CString(str_mod));
		break;
	case COSV1V2:
		DC.TextOutW(100, 100, CString("V1")); PrintMatrix(DC, 100, 120, V1);
		
		DC.TextOutW(200, 100, CString("V2")); PrintMatrix(DC, 200, 120, V2);
		
		DC.TextOutW(300, 100, CString("CosV1V2"));
		
		str_cos = (char*)strCosV1V2.c_str();
		DC.TextOutW(300, 120, CString(str_cos));
		break;
	case SPHERETOCART:
		DC.TextOutW(100, 100, CString("V4")); PrintMatrix(DC, 100, 120, V4);
		
		DC.TextOutW(200, 100, CString("SphereToCart"));PrintMatrix(DC, 200, 120, SphereToCart(V4));
		break;
	}
}
void CMainWin::F_C1()
{
	The_Value_Menu = C1;
	InvalidateRect(0);
}
void CMainWin::F_C2()
{
	The_Value_Menu = C2;
	InvalidateRect(0);
}
void CMainWin::F_D()
{
	The_Value_Menu = D;
	InvalidateRect(0);
}
void CMainWin::F_Q()
{
	The_Value_Menu = Q;
	InvalidateRect(0);
}
void CMainWin::F_P()
{
	The_Value_Menu = P;
	InvalidateRect(0);
}

void CMainWin::F_V_Mult()
{
	The_Value_Menu = VECTORMULT;
	InvalidateRect(0);
}
void CMainWin::F_Sc_Mult()
{
	The_Value_Menu = SCALARMULT;
	InvalidateRect(0);
}
void CMainWin::F_MOD_V()
{
	The_Value_Menu = MODVEC;
	InvalidateRect(0);
}
void CMainWin::F_COs_V1_V2()
{
	The_Value_Menu = COSV1V2;
	InvalidateRect(0);
}
void CMainWin::F_SP_T_Cart()
{
	The_Value_Menu = SPHERETOCART;
	InvalidateRect(0);
}
                
BEGIN_MESSAGE_MAP(CMainWin, CFrameWnd)// таблица откликов на сообщения
	ON_COMMAND(C1, &CMainWin::F_C1)// реакция на нажатие кнопки в меню 
	ON_COMMAND(C2, &CMainWin::F_C2)
	ON_COMMAND(D, &CMainWin::F_D)
	ON_COMMAND(Q, &CMainWin::F_Q)
	ON_COMMAND(P, &CMainWin::F_P)
	ON_COMMAND(VECTORMULT, &CMainWin::F_V_Mult)
	ON_COMMAND(SCALARMULT, &CMainWin::F_Sc_Mult)
	ON_COMMAND(MODVEC, &CMainWin::F_MOD_V)
	ON_COMMAND(COSV1V2, &CMainWin::F_COs_V1_V2)
	ON_COMMAND(SPHERETOCART, &CMainWin::F_SP_T_Cart)
	ON_WM_PAINT()
END_MESSAGE_MAP()