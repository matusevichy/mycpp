#pragma once
#include "Abonent.h"

class Phonebook
{
	char Name[20];
	Abonent mas[100];
	short curr_count;
public:
	Phonebook(const char*);
	void Add();
	void Print();
	void Delete();
	void Find_by_Fio();
};

