#include "Drob.h"

Drob::Drob()
{
	this->chisl = 0;
	this->znam = 1;
}

void Drob::Set()
{
	do
	{
		cout << "Enter chisl (>=0): ";
		cin >> this->chisl;
	} while (this->chisl < 0);
	do
	{
		cout << "Enter znam (> 0): ";
		cin >> this->znam;
	} while (this->znam <= 0);
}

void Drob::Sum(Drob num)
{
	cout << "Summa is:\n" << this->chisl * num.znam + num.chisl*this->znam << "/" << this->znam * num.znam << "\n";
}

void Drob::Razn(Drob num)
{
	cout << "Razn is :\n" << this->chisl * num.znam - num.chisl * this->znam << "/" << this->znam * num.znam << "\n";
}

void Drob::Prod(Drob num)
{
	cout << "Production is :\n" << this->chisl * num.chisl << "/" << this->znam * num.znam << "\n";
}

void Drob::Div(Drob num)
{
	cout << "Razn is :\n" << this->chisl * num.znam  << "/" << this->znam * num.chisl << "\n";
}
