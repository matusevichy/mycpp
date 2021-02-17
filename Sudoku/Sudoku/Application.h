#pragma once
#include"Field.h"

class Application
{
	enum 
	{
		EXIT,
		LOAD,
		CREATE
	};
	Field* newField;
public:
	void start();
	void mainMenu();
	void selectFile();
	void create();
	bool runApp();
};

