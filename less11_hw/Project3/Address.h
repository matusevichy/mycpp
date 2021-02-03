#pragma once
#include <iostream>
#include <string>
using namespace std;

enum StreetType {
	Undef,		//�� ��������
	Avenue,		//��������
	Lane,		//��������
	Boulevard	//�������
};

class Address
{
	string street;		//�������� �����
	int houseNum;			//����� ����
	int roomNum;			//����� ��������
	StreetType type;		//��� �����
public:
	Address();
	Address(string, int, int, StreetType);
	bool operator==(Address);
	friend ostream& operator << (ostream& os, const Address& obj);
	inline friend istream& operator >> (istream& is, StreetType& obj);
	friend istream& operator >> (istream& is, Address& obj);
};

