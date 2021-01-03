#pragma once
#include"Phone.h"

class Abonent
{
	char Fio[30];
	Phone* numbers=nullptr;
	short count_number=0;
	char Note[50];
public:
	void Add();
	char* Get_Fio() { return Fio; }
	void Show();
};


