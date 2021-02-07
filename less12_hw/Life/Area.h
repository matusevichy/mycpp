#pragma once
#include"Life.h"
class Area
{
	Fox* foxes;
	Rabbit* rabbits;
	Herb* herbs;
	int countFox, countRabbit, countHerb;
	int maxEntity;
	int year;
public:
	Area(int);
	bool addYear();
	void setAge(Life*, int&);
	void del(Life*, int&, int);
	void print();
	~Area();
};

