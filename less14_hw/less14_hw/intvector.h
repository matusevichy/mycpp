#pragma once
#include<iostream>
#include<vector>
#include<time.h>
using namespace std;

class Intvector
{
	vector<int> newVector;
public:
	void set(int);
	friend ostream& operator<<(ostream& os, const Intvector&);
};


