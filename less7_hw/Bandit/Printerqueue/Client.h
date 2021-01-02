#pragma once
#include<iostream>
using namespace std;

class Client
{
	char name[20];
	int priority;
public:
	Client();
	Client(const char*, int);
	Client(Client&);
	Client operator=(Client&);
	int getPrioirity() { return priority; }
	void Show();
};

