#pragma once
#include<iostream>
#include"Time_Math.h"
using namespace std;

class Time
{
	enum { am = 1, pm = 2 };
	int hour;
	int minets;
	int ext;
public:
	Time();
	void setTime();
	Time& getTime() { return *this; }
	friend class Time_Math;
	friend istream& operator>>(istream& is, Time t);
};

istream& operator>>(istream& is, Time t)
{

}
