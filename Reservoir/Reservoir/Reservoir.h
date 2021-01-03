#pragma once
#include<iostream>
using namespace std;

class Reservoir
{
	char* Name;
	char type;
	float width;
	float length;
	float depth;
	char* Gets();
public:
	Reservoir();
	Reservoir(const char*,char,float,float,float);
	Reservoir(Reservoir&);
	void operator=(Reservoir&);
	void PrintType();
	float Square();
	float Volume();
	void CompareSQ(Reservoir&);
	void CompareType(Reservoir&);
	void Set();
	char* Getname();
	void Show();
	Reservoir Get() { return *this; }
	~Reservoir() { delete[] Name; }
};

