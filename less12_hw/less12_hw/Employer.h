#pragma once
#include<iostream>
#include<string>

using namespace std;

class Employer
{
protected:
	string name;
public:
	Employer(string name);
	virtual void print() = 0;
};

class President:public Employer
{
public:
	President(string name) :Employer(name) {}
	// Унаследовано через Employer
	virtual void print() override;
};

class Manager:public Employer
{
public:
	Manager(string name) :Employer(name) {}
	// Унаследовано через Employer
	virtual void print() override;
};

class Worker :public Employer
{
public:
	Worker(string name):Employer(name){}
	// Унаследовано через Employer
	virtual void print() override;
};