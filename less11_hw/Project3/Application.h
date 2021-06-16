#pragma once
#include"Handbook.h"

class Application
{
	enum
	{
		EXIT,
		ADD,
		FIND,
		SAVE
	};
	Handbook* newHandbook;
public:
	void start();
	void mainMenu();
	void findMenu();
	bool find();
};