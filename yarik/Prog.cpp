#include <time.h>
#include <stdio.h>
#include <ctype.h>
#include "String.h"


int main()
{
	setlocale(LC_ALL, "rus");
	String one("hello world!");
	String two(" my name is djob!");
	String free;
	free = one + two;
	free.print();
	return 0;
}
