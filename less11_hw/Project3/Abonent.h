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
	string companyName;			//�������� �����
	string owner;				//��������
	string phone;				//����� ��������
	string occupation;			//��� ������������
	Address* address;			//�����
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