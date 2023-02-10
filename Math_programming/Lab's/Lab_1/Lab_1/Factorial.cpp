#include "Factorial.h"
#include <iostream>
using namespace std;

long double factorial(int num)
{
	int sum = 0;
	while (num!= 0)
	{
		sum += num;
		num--;
	}

	return sum;
}