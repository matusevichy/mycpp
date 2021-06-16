#include "Equation.h"

Equation::Equation(double a, double b)
{
	this->a = a;
	this->b = b;
}

void Qequation::root()
{
	double d,x1,x2;
	d = pow(b, 2) - 4 * a * c;
	if (d<0)
	{
		cout << "This equation has no roots\n";
	}
	else if (d>0)
	{
		x1 = (-b + sqrt(d)) / (2 * a);
		x2 = (-b - sqrt(d)) / (2 * a);
		cout << "x1=" << x1 << "; x2=" << x2 << endl;
	}
	else
	{
		x1 = (-b + sqrt(d)) / (2 * a);
		cout << "x1=" << x1 << endl;
	}
}

void Lequation::root()
{
	cout << a << "x" << "=" << b << endl;
	cout << "x=" << b / a << endl;
}
