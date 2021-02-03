#include "Address.h"

Address::Address()
{
	street = "";
	houseNum = 0;
	roomNum = 0;
	type = Undef;
}

Address::Address(string street, int houseNum, int roomNum, StreetType type)
{
	this->street = street;
	this->houseNum = houseNum;
	this->roomNum = roomNum;
	this->type = type;
}

bool Address::operator==(Address obj)
{
	if (this->street == obj.street && this->houseNum == obj.houseNum && this->roomNum == obj.roomNum && this->type == obj.type)
	{
		return true;
	}
	return false;
}

ostream& operator<<(ostream& os, const Address& obj)
{
	os << obj.street << " " << obj.type << " " << obj.houseNum << " " << obj.roomNum << " ";
	return os;
}

inline istream& operator>>(istream& is, StreetType& obj)
{
	int tmp;
	is >> tmp;
	obj = (StreetType)tmp;
	return is;
}

istream& operator>>(istream& is, Address& obj)
{
	is >> obj.street;
	is >> obj.type;
	is >> obj.houseNum;
	is >> obj.roomNum;
	return is;
}

