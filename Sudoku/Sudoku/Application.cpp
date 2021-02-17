#include "Application.h"

void Application::start()
{
	int act;
	while (true)
	{
		system("cls");
		mainMenu();
		cin >> act;
		switch (act)
		{
		case LOAD:
		{
//			selectFile();
			break;
		}
		case CREATE:
		{
			create();
			break;
		}
		case EXIT:
			exit(0);
		default:
			break;
		}
	}
	
}

void Application::mainMenu()
{
	cout << "1 - Load Sudoku from file;\n";
	cout << "2 - Create new Sudoku;\n";
	cout << "0 - Exit.\n";
}

void Application::create()
{
	int size;
	cout << "Enter size:\n";
	cin >> size;
	newField = new Field(size);
	if (newField->setCell(0, 0))
	{
		newField->print();
	}
}
