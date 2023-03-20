#include <iostream>
#include "LCS.h"
int main()
{
    setlocale(LC_ALL, "rus");
    clock_t t1 = 0, t2 = 0, t3 = 0, t4 = 0;
    t1 = clock();
    char X[] = "QVTWNHO", Y[] = "RQTWYK";
    std::cout << std::endl << "-- ���������� ����� LCS ��� X � Y(��������)";
    std::cout << std::endl << "-- ������������������ X: " << X;
    std::cout << std::endl << "-- ������������������ Y: " << Y;

    int s = lcs(
        sizeof(X) - 1,  // �����   ������������������  X   
        "QVTWNHO",       // ������������������ X
        sizeof(Y) - 1,  // �����   ������������������  Y
        "RQTWYK"       // ������������������ Y
    );
    std::cout << std::endl << "-- ����� LCS: " << s << std::endl;
    t2 = clock();



    /// <summary>
    
    /// </summary>
    t3 = clock();
    char z[100] = "";
    char x[] = "QVTWNHO",
        y[] = "RQTWYK";
    int l = lcsd(x, y, z);

    std::cout << std::endl
        << "-- ���������� ����� �������������������� - LCS(������������ "
        << "����������������)" << std::endl;
    t4 = clock();
    std::cout << std::endl << "����������������� X: " << x;
    std::cout << std::endl << "����������������� Y: " << y;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          ����� LCS: " << l;
    std::cout << std::endl;

    std::cout << '\n' << "����� ���������� ����������: " << t2 - t1;
    std::cout << '\n' << "����� ���������� �������������: " << t4 - t3 << '\n' << std::endl;
    system("pause");
    return 0;
}
