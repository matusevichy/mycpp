#pragma once
#include<conio.h>
#include "Phonebook.h"

class App
{
	enum mainmenu
	{
		EXIT,
		OPEN
	};
	enum secondmenu
	{
		ADD=1,
		DELETE,
		EDIT,
		FIND,
		PRINT,
		SAVE
	};
	enum findby
	{
		BYNUM=1,
		BYFIO
	};
	Phonebook* NewBook;
public:
	void Start();
	void mainMenu();
	void secondMenu();
	bool Open();
	bool Run();
	void findMenu();
	bool Find();
	bool Print();
	bool showResult(Abonent*&, int&) const;
	void Sort(Abonent*&, int&);
};

