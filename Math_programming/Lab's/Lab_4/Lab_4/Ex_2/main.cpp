#include <iostream>
#include "LCS.h"
int main()
{
    setlocale(LC_ALL, "rus");
    clock_t t1 = 0, t2 = 0, t3 = 0, t4 = 0;
    t1 = clock();
    char X[] = "QVTWNHO", Y[] = "RQTWYK";
    std::cout << std::endl << "-- вычисление длины LCS для X и Y(рекурсия)";
    std::cout << std::endl << "-- последовательность X: " << X;
    std::cout << std::endl << "-- последовательность Y: " << Y;

    int s = lcs(
        sizeof(X) - 1,  // длина   последовательности  X   
        "QVTWNHO",       // последовательность X
        sizeof(Y) - 1,  // длина   последовательности  Y
        "RQTWYK"       // последовательность Y
    );
    std::cout << std::endl << "-- длина LCS: " << s << std::endl;
    t2 = clock();



    /// <summary>
    
    /// </summary>
    t3 = clock();
    char z[100] = "";
    char x[] = "QVTWNHO",
        y[] = "RQTWYK";
    int l = lcsd(x, y, z);

    std::cout << std::endl
        << "-- наибольшая общая подпоследовательость - LCS(динамическое "
        << "программирование)" << std::endl;
    t4 = clock();
    std::cout << std::endl << "последовательость X: " << x;
    std::cout << std::endl << "последовательость Y: " << y;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          длина LCS: " << l;
    std::cout << std::endl;

    std::cout << '\n' << "Время выполнения рекурсивно: " << t2 - t1;
    std::cout << '\n' << "Время выполнения динамичически: " << t4 - t3 << '\n' << std::endl;
    system("pause");
    return 0;
}
