#pragma once
#include <iostream>
#include<fstream>
#include "Abonent.h"


class Handbook
{
	Abonent* abonents;		//список абонентов
	int count;				//фактическое кол-во
	int capacity;			//общее кол-во
public:
	Handbook();
	~Handbook();
	void add();
	void find(Option);
	void save();
	void load();
};

