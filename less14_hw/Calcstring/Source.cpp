#include"Calcstring.h"

int main()
{
	Calcstring calc;
	calc.set();
	calc.calculateString();
	cout << calc.getStr();
}