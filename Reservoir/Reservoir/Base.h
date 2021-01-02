#pragma once
#include"Reservoir.h"

class Base
{
	Reservoir* mas;
	int size;
	char* Gets();
public:
	Base();
	void Add();
	void Delete();
	void Print();
	Reservoir& Get(int);
};

