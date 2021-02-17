#pragma once
#include<iostream>
#include<string>
#include<regex>
using namespace std;

class Calcstring
{
	string str;
	string numExp = "\\d+\\.*\\d*";
	string allOperationExp = "[+-/*]";
	string sumdifExp = "[+-]";
	string proddivExp = "[/*]";
public:
	void set();
	void calculateString();
	void openBrackets(const string&, const string&);
	void parseStr(string&, const string&, const string&);
	void calcAndReplace(string&, string, regex);
	string getStr() { return str; }
};

