#pragma once
#include<iostream>
#include<cmath>
using namespace std;

class Equation
{
protected:
	double a, b;
public:
	Equation(double, double);
	virtual void root() = 0;
};

class Qequation :public Equation
{
	double c;
public:
	Qequation(double a, double b, double c): Equation(a,b), c(c){}
	// Унаследовано через Equation
	virtual void root() override;
};

class Lequation :public Equation
{
public:
	Lequation(double a, double b) : Equation(a, b) {}
	// Унаследовано через Equation
	virtual void root() override;
};
