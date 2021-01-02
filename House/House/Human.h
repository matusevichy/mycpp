#pragma once
#include<iostream>
using namespace std;

class Human
{
	char* Fio;
	short Age;
public:
	static char* Gets();
	Human();
	Human(Human&);
	void operator=(Human&);
	void Add();
	void Show();
	char* GetFio() { return Fio; }
	~Human() { free(Fio); }
};

