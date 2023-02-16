#include "stdafx.h"
#include "CMainWin.h"
#include "CMatrix.h"
#include<string.h>
#include <string>

CMainWin::CMainWin()
{
	this->Create(0, (LPCTSTR)L"First lab", WS_OVERLAPPEDWINDOW, rectDefault, 0, (LPCTSTR)IDR_MENU1);

	MenuClick = -1; 
}
void CMainWin::OnPaint()
{
	CPaintDC dc(this);
	CMatrix A(3, 3), B(3, 3), V1(3), V2(3);
	for (int i = 0; i < A.rows(); i++)
	{
		for (int j = 0; j < A.cols(); j++)
		{
			A(i, j) = i + j;
			B(i, j) = i + j + 1;
		}
		V1(i) = i;
		V2(i) = i + 1;
	}
	CMatrix V3 = VectorMult(V1, V2);
	CMatrix V4(3);
	V4(0) = 11;
	V4(1) = 30;
	V4(2) = 10;
	double scalar = ScalarMult(V1, V2),
		modvec = ModVec(V1),
		cosv1v2 = CosV1V2(V1, V2);
	std::string strScalarMult = std::to_string(scalar),
		strModVec = std::to_string(modvec),
		strCosV1V2 = std::to_string(cosv1v2);
	char *str1, *str2, *str3;
	switch (MenuClick)
	{
	case  ID_CMATRIX_C1:
		dc.TextOutW(110, 100, CString("A"));
		PrintMatrix(dc, 100, 120, A);
		dc.TextOutW(360, 100, CString("B"));
		PrintMatrix(dc, 350, 120, B);
		dc.TextOutW(610, 100, CString("C1 = A + B"));
		PrintMatrix(dc, 600, 120, A+B);
		break;
	case ID_CMATRIX_C2:
		dc.TextOutW(110, 100, CString("A"));
		PrintMatrix(dc, 100, 120, A);
		dc.TextOutW(360, 100, CString("B"));
		PrintMatrix(dc, 350, 120, B);
		dc.TextOutW(600, 100, CString("C1 = A * B"));
		PrintMatrix(dc, 600, 120, A * B);
		break;
	case ID_CMATRIX_D:
		dc.TextOutW(110, 100, CString("A"));
		PrintMatrix(dc, 100, 120, A);
		dc.TextOutW(360, 100, CString("V1"));
		PrintMatrix(dc, 350, 120, V1);
		dc.TextOutW(455, 100, CString("D = A * V1"));
		PrintMatrix(dc, 450, 120, A * V1);
		break;
	case ID_CMATRIX_Q:
		dc.TextOutW(110, 100, CString("V1"));
		PrintMatrix(dc, 100, 120, V1);
		dc.TextOutW(210, 100, CString("V1^T"));
		PrintMatrix(dc, 200, 120, V1.Transp());
		dc.TextOutW(460, 100, CString("V2"));
		PrintMatrix(dc, 450, 120, V2);
		dc.TextOutW(560, 100, CString("q = V1^T * V2"));
		PrintMatrix(dc, 550, 120, V1.Transp() * V2);
		break;
	case ID_CMATRIX_P:
		dc.TextOutW(110, 100, CString("V1"));
		PrintMatrix(dc, 100, 120, V1);
		dc.TextOutW(210, 100, CString("V1^T"));
		PrintMatrix(dc, 200, 120, V1.Transp());
		dc.TextOutW(460, 100, CString("A"));
		PrintMatrix(dc, 450, 120, A);
		dc.TextOutW(710, 100, CString("V2"));
		PrintMatrix(dc, 700, 120, V2);
		dc.TextOutW(810, 100, CString("q = V1^T * A * V2"));
		PrintMatrix(dc, 800, 120, V1.Transp() * A * V2);
		break;
	case ID_FUNCTIONS_VECTORMULT:
		dc.TextOutW(100, 100, CString("V1"));
		PrintMatrix(dc, 100, 120, V1);
		dc.TextOutW(200, 100, CString("V2"));
		PrintMatrix(dc, 200, 120, V2);
		dc.TextOutW(300, 100, CString("VectorMult"));
		PrintMatrix(dc, 300, 120, V3);
		break;
	case ID_FUNCTIONS_SCALARMULT:
		dc.TextOutW(100, 100, CString("V1"));
		PrintMatrix(dc, 100, 120, V1);
		dc.TextOutW(200, 100, CString("V2"));
		PrintMatrix(dc, 200, 120, V2);
		dc.TextOutW(300, 100, CString("ScalarMult"));
		str1 = (char*)strScalarMult.c_str();
		dc.TextOutW(300, 120, CString(str1));
		break;
	case ID_FUNCTIONS_MODVEC:
		dc.TextOutW(100, 100, CString("V1"));
		PrintMatrix(dc, 100, 120, V1);
		dc.TextOutW(200, 100, CString("ModVec"));
		str2 = (char*)strModVec.c_str();
		dc.TextOutW(200, 120, CString(str2));

		dc.TextOutW(100, 400, CString("V2"));
		PrintMatrix(dc, 100, 420, V2);
		dc.TextOutW(200,400, CString("ModVec"));
		str2 = (char*)strModVec.c_str();
		dc.TextOutW(200, 420, CString(str2));
		break;
	case ID_FUNCTIONS_COSV1V2:
		dc.TextOutW(100, 100, CString("V1"));
		PrintMatrix(dc, 100, 120, V1);
		dc.TextOutW(200, 100, CString("V2"));
		PrintMatrix(dc, 200, 120, V2);
		dc.TextOutW(300, 100, CString("CosV1V2"));
		str3 = (char*)strCosV1V2.c_str();
		dc.TextOutW(300, 120, CString(str3));
		break;
	case ID_FUNCTIONS_SPHERETOCART:
		dc.TextOutW(100, 100, CString("V4"));
		PrintMatrix(dc, 100, 120, V4);
		dc.TextOutW(200, 100, CString("SphereToCart"));
		PrintMatrix(dc, 200, 120, SphereToCart(V4));
		break;
	}
}

void CMainWin::CalcC1()
{
	MenuClick = ID_CMATRIX_C1;
	InvalidateRect(0);
}
void CMainWin::CalcC2()
{
	MenuClick = ID_CMATRIX_C2;
	InvalidateRect(0);
}


void CMainWin::CalcD()
{
	MenuClick = ID_CMATRIX_D;
	InvalidateRect(0);
}
void CMainWin::CalcQ()
{
	MenuClick = ID_CMATRIX_Q;
	InvalidateRect(0);
}
void CMainWin::CalcP()
{
	MenuClick = ID_CMATRIX_P;
	InvalidateRect(0);
}
void CMainWin::Clear()
{
	MenuClick = -1;
	InvalidateRect(0);
}
void CMainWin::VEctorMult()
{
	MenuClick = ID_FUNCTIONS_VECTORMULT;
	InvalidateRect(0);
}
void CMainWin::SCalarMult()
{
	MenuClick = ID_FUNCTIONS_SCALARMULT;
	InvalidateRect(0);
}
void CMainWin::MOdVec()
{
	MenuClick = ID_FUNCTIONS_MODVEC;
	InvalidateRect(0);
}
void CMainWin::COsV1V2()
{
	MenuClick = ID_FUNCTIONS_COSV1V2;
	InvalidateRect(0);
}
void CMainWin::SPhereToCart()
{
	MenuClick = ID_FUNCTIONS_SPHERETOCART;
	InvalidateRect(0);
}
                 //класс окна класс-предок
BEGIN_MESSAGE_MAP(CMainWin, CFrameWnd) //обработчике событий
	ON_COMMAND(ID_CMATRIX_C1, &CMainWin::CalcC1)
	ON_COMMAND(ID_CMATRIX_C2, &CMainWin::CalcC2)
	ON_COMMAND(ID_CMATRIX_D, &CMainWin::CalcD)
	ON_COMMAND(ID_CMATRIX_Q, &CMainWin::CalcQ)
	ON_COMMAND(ID_CMATRIX_P, &CMainWin::CalcP)
	ON_COMMAND(ID_FUNCTIONS_VECTORMULT, &CMainWin::VEctorMult)
	ON_COMMAND(ID_FUNCTIONS_SCALARMULT, &CMainWin::SCalarMult)
	ON_COMMAND(ID_FUNCTIONS_MODVEC, &CMainWin::MOdVec)
	ON_COMMAND(ID_FUNCTIONS_COSV1V2, &CMainWin::COsV1V2)
	ON_COMMAND(ID_FUNCTIONS_SPHERETOCART, &CMainWin::SPhereToCart)
	ON_COMMAND(ID_CLEAR, &CMainWin::Clear)
	ON_WM_PAINT()
END_MESSAGE_MAP()