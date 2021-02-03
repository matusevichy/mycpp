#pragma once
#include <iostream>
#include <string>
#include "Address.h"

enum Option
{
	EXIT,
	BYNAME,
	BYOWNER,
	BYPHONE,
	BYOCCUPATION,
	ALL
};

class Abonent
{
	string companyName;			//название фирмы
	string owner;				//владелец
	string phone;				//номер телефона
	string occupation;			//род деятельности
	Address* address;			//адрес
public:
	Abonent();
	Abonent(string, string, string, string, Address*);
	~Abonent();
	void set();
	void print();
	bool check(Option, string);
	StreetType strToEnum(string);
	friend ostream& operator<<(ostream& os, Abonent& obj);
	friend istream& operator>>(istream& is, Abonent& obj);
};