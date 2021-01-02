#include "Drum.h"

Drum::Drum()
{
	charcount = 0;
	firstchar = 0;
	current = 0;
	drum = nullptr; 
}

Drum::Drum(int n, char first)
{
	charcount = n;
	firstchar = first;
	drum = new char[n];
	for (int i = 0; i < n; i++)
	{
		drum[i] = i + firstchar;
	}
	current = drum[rand() % n];
}

bool Drum::Roll()
{
	int rollcount = rand() % 500;
	current = drum[rollcount % charcount];
	return true;
}


Drum::~Drum()
{
	delete[] drum;
}
