#pragma once
#include <iostream>
#include <string>
using namespace std;

enum StreetType {
	Undef,		//не известно
	Avenue,		//проспект
	Lane,		//переулок
	Boulevard	//бульвар
};

class Address
{
	string street;		//название улицы
	int houseNum;			//номер дома
	int roomNum;			//номер квартиры
	StreetType type;		//тип улицы
public:
	Address();
	Address(string, int, int, StreetType);
	bool operator==(Address);
	friend ostream& operator << (ostream& os, const Address& obj);
	inline friend istream& operator >> (istream& is, StreetType& obj);
	friend istream& operator >> (istream& is, Address& obj);
};

