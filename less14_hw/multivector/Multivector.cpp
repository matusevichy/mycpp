#include "Multivector.h"

void Multivector::fill(int count)
{
	vector<int> tmp;
	for (int i = 1; i <= count; i++)
	{
		for (int j = 1; j <= count; j++)
		{
			tmp.push_back(i * j);
		}
		multiTable.push_back(tmp);
		tmp.clear();
	}
}

ostream& operator<<(ostream& os, const Multivector& obj)
{
	string border = "---|---|---|---|---|---|---|---|---|---|---|\n";
	os << setw(3) << "   |";
	for (int i = 1; i <= obj.multiTable.size(); i++)
	{
		os << setw(3) << i << "|";
	}
	os << endl << border;
	auto iter = obj.multiTable.begin();
	int counter = 1;
	while (iter != obj.multiTable.end())
	{
		auto iter2 = (*iter).begin();
		os << setw(3) << counter++ << "|";
		while (iter2!=(*iter).end())
		{
			os << setw(3) << (*iter2) << "|";
			iter2++;
		}
		os << endl << border;
		iter++;
	}
	return os;
}
