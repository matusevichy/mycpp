#pragma once
#include<iostream>
#include<string>
using namespace std;

class Student
{
	string firstName;
	string lastName;
	int course;
public:
	void set(string, string, int);
	string getFirstName() { return firstName; }
	string getLastName() { return lastName; }
	int getCourse() { return course; }
	friend ostream& operator<<(ostream& os, const Student& obj);
};

