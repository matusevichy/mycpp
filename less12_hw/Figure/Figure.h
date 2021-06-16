#pragma once
#define _USE_MATH_DEFINES
#include<iostream>
#include<cmath>
#include<math.h>
using namespace std;

class Figure
{
protected:
	double a, b;
public:
	Figure();
	Figure(double, double);
	virtual double square() = 0;
};

class Rectangle:public Figure
{
public:
	Rectangle(double a, double b):Figure(a,b){}
	// Унаследовано через Figure
	virtual double square() override;
};

class Circle :public Figure
{
	double radius;
public:
	Circle(double);
	// Унаследовано через Figure
	virtual double square() override;
};

class Rtriangle : public Figure
{
public:
	Rtriangle(double a, double b) : Figure(a, b) {}
	// Унаследовано через Figure
	virtual double square() override;
};

class Trapezoid :public Figure
{
	double h;
public:
	Trapezoid(double a, double b, double h) : Figure(a, b), h(h) {}
	// Унаследовано через Figure
	virtual double square() override;
};