#pragma once
#include<iostream>
#include<time.h>
using namespace std;

class Drum
{
	int charcount;
	char* drum;
	char firstchar;
	char current;
public:
	Drum();
	Drum(int, char);
	bool Roll();
	char Show() {return current;}
	~Drum();
};

