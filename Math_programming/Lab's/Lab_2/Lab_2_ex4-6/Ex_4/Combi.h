#pragma once
#include "Perestanovka.h";
#include "Sochetania.h";
namespace combi
{
    struct  accomodation  // ��������� ���������� 
    {
        short  n,      // ���������� ��������� ��������� ���������  
            m,      // ���������� ��������� � ���������� 
            * sset;      // ������ ������� �������� ����������  
        sochetan::xcombination* cgen;   // ��������� �� ��������� ���������
        perestan::permutation* pgen;   // ��������� �� ��������� ������������
        accomodation(short n = 1, short m = 1);  // �����������  
        void reset();     // �������� ���������, ������ ������� 
        short getfirst();     // ������������ ������ ������ ��������   
        short getnext();      // ������������ ��������� ������ ��������  
        short ntx(short i);   // �������� i-� ������� ������� ��������  
        unsigned __int64 na;  // ����� ���������� 0, ..., count()-1 
        unsigned __int64 count() const;  // ����� ���������� ���������� 
    };
}
