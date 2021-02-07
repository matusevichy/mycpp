#pragma once
#include<iostream>
using namespace std;

class IndexOutOfRangeException :public exception
{
	const char* message = "";
public:
	IndexOutOfRangeException(const char* msg):exception(msg)
	{
		message = msg;
	}
	const char* what() const override
	{
		return message;
	}
};

