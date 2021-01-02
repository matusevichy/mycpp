#pragma once
#include"Human.h"
class Flat
{
	Human* mas;
	short count;
public:
	Flat();
	void Add();
	void Delete();
	void Show();
	~Flat() { free(mas); }
};

