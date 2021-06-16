#pragma once
#include <iostream>
using namespace std;

class SequenceIsEmptyException:public exception
{
	const char* message = "";
public:
	SequenceIsEmptyException(const char* msg) :exception(msg) 
	{
		message = msg;
	}
	const char* what() const override
	{
		return message;
	}
};

