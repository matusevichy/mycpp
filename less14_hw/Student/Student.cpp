#include "Student.h"

void Student::set(string firstName, string lastName, int course)
{
	this->firstName = firstName;
	this->lastName = lastName;
	this->course = course;
}

ostream& operator<<(ostream& os, const Student& obj)
{
	os << obj.firstName << " " << obj.lastName << ", course number " << obj.course;
	return os;
}
