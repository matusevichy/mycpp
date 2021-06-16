#include "intvector.h"

void Intvector::set(int count)
{
	for (int i = 0; i < count; i++)
	{
		newVector.push_back(pow(rand() % 10 + 1, 2));
	}
}

ostream& operator<<(ostream& os, const Intvector& obj)
{
	auto iter = obj.newVector.begin();
	while (iter != obj.newVector.end())
	{
		os << (*iter) << " ";
		iter++;
	}
	return os;
}
