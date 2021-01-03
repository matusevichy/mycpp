#pragma once
#include"Flat.h"
class House
{
	int size;
	Flat* mas;
public:
	House(int);
	void Add();
	void Delete();
	void ShowAll();
	~House() { free(mas); }
};

