#define _CRT_SECURE_NO_WARNINGS
#include "String.h"

String::String()
{
	mas = new char[81];
	size = 80;
}

String::String(const int& a)
{
	mas = new char[a + 1];
	size = a;
}

String::String(const char* a)
{
	size = strlen(a);
	mas = new char[size + 1];
	strcpy(mas, a);
}

String::String(const String& a)
{
	this->size = a.size;
	this->mas = new char[this->size];
	strcpy(this->mas, a.mas);
}

String::~String()
{
//	delete[]mas;
//	mas = nullptr;
}

String String::operator+(const String& OK)
{
	int d;
	d = ((int)(this->size) + (int)(OK.size));
	char* TE = new char[d];
	strcpy(TE, this->mas);
	strcat(TE, OK.mas);
	String tmp(TE);
	return tmp;
}

void String::operator=(const char* a)
{
	if (this->mas != nullptr)
		delete[]mas;
	this->mas = new char[strlen(a) + 1];
	this->size = strlen(a);
	strcpy(this->mas, a);
}

void String::operator=(const String& a)
{
	if (this->mas != nullptr)
	{
		mas = nullptr;
	}
	this->size = a.size;
	this->mas = new char[this->size + 1];
	strcpy(this->mas, a.mas);
}

void String::print()
{
	cout << mas << "\n";
}

