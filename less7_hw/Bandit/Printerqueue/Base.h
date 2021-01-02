#pragma once
#include"Client.h"

class Base
{
	Client* mas;
	int count;
	static char* Gets();
public:
	Base();
	Base(Base&);
	void Set();
	Client& Get(int);
	void Print();
	void Delete();
	~Base() { delete[] mas; }
};

