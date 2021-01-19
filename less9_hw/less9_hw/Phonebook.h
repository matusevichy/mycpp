#pragma once
#include "Abonent.h"

class Phonebook
{
	char Name[20];
	Abonent* mas;
	int curr_count;
public:
	Phonebook(const char*);
	void Add();
	void Print(Abonent*);
	void Delete();
	int findByFio();
	int findByNum();
	void findByFios(Abonent*&,int&);
	void findByNums(Abonent*&, int&);
	bool loadFromFile();
	void Edit();
	void saveToFile(Abonent* mas, char* fname, int count);
	Abonent& operator[](int);
	void addToMas(Abonent*&, int&, Abonent);
	~Phonebook();
};
