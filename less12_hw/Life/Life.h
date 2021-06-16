#pragma once
#include<iostream>
using namespace std;

class Life
{
protected:
	int maxAge, age;
	int level;
	int increment;
public:
	Life();
	Life(int);
	bool setAge();
	int getIncrement();
};

class Fox :public Life
{
public:
	Fox():Life(){}
	Fox(int age):Life(age)
	{
		level = 0;
		increment = 1;
	}
};

class Rabbit :public Life
{
public:
	Rabbit():Life(){}
	Rabbit(int age) :Life(age)
	{
		level = 1;
		increment = 2;
	}
};

class Herb :public Life
{
public:
	Herb():Life(){}
	Herb(int age) : Life(age)
	{
		level = 2;
		increment = 4;
	}
};
