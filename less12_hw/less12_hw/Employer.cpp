#include "Employer.h"

void President::print()
{
	cout << name << " the grant employer in the country.\n";
}

void Manager::print()
{
	cout << name << " the grant employer in the company.\n";
}

void Worker::print()
{
	cout << name << " the employer in the company.\n";
}

Employer::Employer(string name)
{
	this->name = name;
}
