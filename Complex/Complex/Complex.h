#pragma once
#include<iostream>
using namespace std;

class Complex
{
	int real;
	int imag;
	char* Gets();
public:
	void Set();
	template <typename Type> void  Print(Type, Type);
	void operator+(const Complex&);
	void operator-(const Complex&);
	void operator*(const Complex&);
	void operator/(const Complex&);
};

