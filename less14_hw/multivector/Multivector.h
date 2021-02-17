#pragma once
#include<iostream>
#include<vector>
#include<iomanip>
using namespace std;

class Multivector
{
	vector<vector<int>> multiTable;
public:
	void fill(int);
	friend ostream& operator<<(ostream& os, const Multivector& obj);
};

