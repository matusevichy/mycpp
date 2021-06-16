#include "Abonent.h"

Abonent::Abonent()
{
	address = nullptr;
}

Abonent::Abonent(string companyName, string owner, string phone, string occupation, Address* address)
{
	this->companyName = companyName;
	this->owner = owner;
	this->phone = phone;
	this->occupation = occupation;
	this->address = address;
}

Abonent::~Abonent()
{
	delete address;
}

void Abonent::set()
{
	cout << "Enter company name:\n";
	getline(cin, companyName);
	cout << "Enter owner:\n";
	getline(cin, owner);
	cout << "Enter phone:\n";
	getline(cin, phone); 
	cout << "Enter company occupation:\n";
	getline(cin, occupation);
	cout << "Enter street name:\n";
	string streetName;
	getline(cin, streetName);
	cout << "Enter street type (Avenue, Lane, Boulevard):\n";
	string type;
	getline(cin, type);
	cout << "Enter house number:\n";
	int houseNum;
	cin >> houseNum;
	cout << "Enter room number:\n";
	int roomNum;
	cin >> roomNum;
	address = new Address(streetName, houseNum, roomNum, strToEnum(type));
}

void Abonent::print()
{
	cout << "Company name: " << companyName << endl
		<< "Owner: " << owner << endl
		<< "Phone: " << phone << endl
		<< "Occupation: " << occupation << endl
		<< "Address: " << *address << endl;
}

bool Abonent::check(Option option, string search)
{
	switch (option)
	{
	case BYNAME:
		return (companyName == search) ? true : false;
	case BYOWNER:
		return (owner == search) ? true : false;
	case BYPHONE:
		return (phone == search) ? true : false;
	case BYOCCUPATION:
		return (occupation == search) ? true : false;
	default:
		break;
	}
	return false;
}

StreetType Abonent::strToEnum(string type)
{
	if (type == "Avenue")
	{
		return Avenue;
	}
	else if (type == "Lane")
	{
		return Lane;
	}
	else if (type == "Boulevard")
	{
		return Boulevard;
	}
	else
	{
		return Undef;
	}
}

ostream& operator<<(ostream& os, Abonent& obj)
{
	os << obj.companyName << " " << obj.owner << " " << obj.phone << " " << obj.occupation << " " << *obj.address;
	return os;
}

 istream& operator>>(istream& is, Abonent& obj)
{
	 is >> obj.companyName;
	 is >> obj.owner;
	 is >> obj.phone;
	 is >> obj.occupation;
	 obj.address = new Address;
	 is >> *obj.address;
	 return is;
}
