#pragma once
#include<iostream>
#include<Windows.h>
using namespace std;

class Time
{
	enum { am = 1, pm = 2 };
	int hour;
	int minets;
	int ext;
	char* Gets();
public:
	Time();
	void setTime();
	bool check(const Time&);
	Time& getTime() { return *this; }
	Time convert();
	Time operator+(Time);
	Time operator-(Time);
	void compare(Time);
	friend ostream& operator<<(ostream& os, const Time& t);
};

