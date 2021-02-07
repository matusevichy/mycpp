#include "Life.h"

Life::Life()
{
	maxAge = 0;
	age = 0;
	level = 0;
	increment=0;
}

Life::Life(int maxAge)
{
	this->maxAge = maxAge;
	this->age = rand() % maxAge + 1;
}

bool Life::setAge()
{
	if (age<maxAge)
	{
		this->age++;
		return true;
	}
	else
	{
		return false;
	}
}

int Life::getIncrement()
{
	return increment;
}
