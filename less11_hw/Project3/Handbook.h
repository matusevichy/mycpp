#pragma once
#include <iostream>
#include<fstream>
#include "Abonent.h"


class Handbook
{
	Abonent* abonents;		//������ ���������
	int count;				//����������� ���-��
	int capacity;			//����� ���-��
public:
	Handbook();
	~Handbook();
	void add();
	void find(Option);
	void save();
	void load();
};

