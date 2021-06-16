#pragma once
#include<iostream>
using namespace std;

struct Offence
{
	char name[50];
	float sum;
	Offence* next;
};

class List
{
	Offence* first, * last;
	int count;
public:
	List();
	~List();
	void Add();
	void Add(const char*, float);
	void Clear();
	void Print();
};

