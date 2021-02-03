#include "Application.h"

void Application::start()
{
	newHandbook = new Handbook;
	newHandbook->load();
	int action;
	while (true)
	{
		system("cls");
		mainMenu();
		cin >> action;
		cin.ignore();
		switch (action)
		{
		case EXIT:
			exit(0);
		case ADD:
			newHandbook->add();
			break;
		case FIND:
			find();
			break;
		case SAVE:
			newHandbook->save();
			break;
		default:
			break;
		}
	}
}

void Application::mainMenu()
{
	cout << "Select action:\n";
	cout << "1 - Add record;\n";
	cout << "2 - Find record(s);\n";
	cout << "3 - Save to file;\n";
	cout << "0 - Exit.\n";
}

void Application::findMenu()
{
	cout << "Select action:\n";
	cout << "1 - Find by name;\n";
	cout << "2 - Find by owner;\n";
	cout << "3 - Find by phone;\n";
	cout << "4 - Find by occupation;\n";
	cout << "5 - Print all records;\n";
	cout << "0 - Exit.\n";
}

bool Application::find()
{
	int action;
	while (true)
	{
		system("cls");
		findMenu();
		cin >> action;
		cin.ignore();
		switch (action)
		{
		case BYNAME:
			newHandbook->find(BYNAME);
			system("pause");
			break;
		case BYOWNER:
			newHandbook->find(BYOWNER);
			system("pause");
			break;
		case BYPHONE:
			newHandbook->find(BYPHONE);
			system("pause");
			break;
		case BYOCCUPATION:
			newHandbook->find(BYOCCUPATION);
			system("pause");
			break;
		case ALL:
			newHandbook->find(ALL);
			system("pause");
			break;
		case EXIT:
			return false;
		default:
			break;
		}
	}
	return true;
}
