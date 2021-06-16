#pragma once
#include <iostream>
using namespace std;

class DataLossException :
    public exception
{
	const char* message = "";
public:
	DataLossException(const char* msg) :exception(msg)
	{
		message = msg;
	}
	const char* what() const override
	{
		return message;
	}
};

