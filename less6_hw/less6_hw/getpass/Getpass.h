#pragma once
#include<iostream>
using namespace std;

class Getpass
{
	char* str;
public:
	Getpass();
	char* getPass(const char*,...);
	~Getpass();
};

