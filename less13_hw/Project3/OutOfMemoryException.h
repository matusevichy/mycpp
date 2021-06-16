#pragma once
#include <iostream>
using namespace std;

class OutOfMemoryException:public exception
{
	const char* message="";
public:
	OutOfMemoryException(const char* msg) :exception(msg)
	{
		message = msg;
	}
	const char* what() const override
	{
		return message;
	}
};

