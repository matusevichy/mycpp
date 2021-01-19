#pragma once
#include<iostream>
using namespace std;

class Abonent
{
	char Fio[30];
	char number[11];
public:
	void Add();
	char* getFio() { return Fio; }
	char* getNumber() { return number; }
	void Show();
	void Edit();
	bool changeThis();
	void setNumber();
};
