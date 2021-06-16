#include "Students.h"

void Students::fill(int count)
{
	Student tmp;
	for (int i = 0; i < count; i++)
	{
		tmp.set(firstNames.at(rand() % (firstNames.size() - 1)), lastNames.at(rand() % (lastNames.size() - 1)), rand() % 5 + 1);
		studentsArr.push_back(tmp);
	}
}

void Students::print()
{
	for (auto it=studentsArr.begin(); it != studentsArr.end(); it++)
	{
		cout << (*it) << endl;
	}
}

void Students::loadData()
{
	string tmp;
	ifstream fName("fname.bin", ios::binary);
	if (fName.is_open())
	{
		while (!fName.eof())
		{
			fName >> tmp;
			firstNames.push_back(tmp);
		}
	}
	ifstream lName("lname.bin", ios::binary);
	if (lName.is_open())
	{
		while (!lName.eof())
		{
			lName >> tmp;
			lastNames.push_back(tmp);
		}
	}
}

void Students::sortByFirstName()
{
	sort(studentsArr.begin(), studentsArr.end(), compareFirstName);
}

void Students::sortByLastName()
{
	stable_sort(studentsArr.begin(), studentsArr.end(), compareLastName);
}

void Students::sortByCourse(int count)
{
	partial_sort(studentsArr.begin(), studentsArr.begin() + count, studentsArr.end(), compareByCourse);
}

