#pragma once
#include<iostream>
using namespace std;

class SequenceDoesNotContainItemException :
    public exception
{
    const char* message = "";
public:
    SequenceDoesNotContainItemException(const char* msg) :exception(msg)
    {
        message = msg;
    }
    const char* what() const override
    {
        return message;
    }
};

