#pragma once
#include<vector>
#include<fstream>
#include<algorithm>
#include"Student.h"

class Students
{
	struct 
	{
		bool operator()(Student s1, Student s2)
		{
			return (s1.getFirstName() < s2.getFirstName());
		}
	} compareFirstName;
	struct 
	{
		bool operator()(Student s1, Student s2)
		{
			return (s1.getLastName() < s2.getLastName());
		}
	} compareLastName;
	struct 
	{
		bool operator()(Student s1, Student s2)
		{
			return (s1.getCourse() < s2.getCourse());
		}
	} compareByCourse;
	vector<Student> studentsArr;
	vector<string> firstNames;
	vector<string> lastNames;
public:
	void fill(int);
	void print();
	void loadData();
	void sortByFirstName();
	void sortByLastName();
	void sortByCourse(int);
};

