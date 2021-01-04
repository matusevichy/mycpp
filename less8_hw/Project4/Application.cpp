#include "Application.h"

Application::~Application()
{
	delete game;
}

void Application::start()
{

	int action;
	while (true) {
		system("cls");
		menu();
		std::cin >> action;
		cin.ignore();
		system("cls");
		runMenuAction(action);
	}
}

void Application::menu()
{
	std::cout << "[1] New game" << std::endl;
	std::cout << "[2] Exit" << std::endl;
}

void Application::runMenuAction(int action)
{
	switch (action) {
		case NewGame:
			char name[20];
			cout << "Enter player name:";
			gets_s(name,20);
			int n;
			do
			{
				cout << "Enter number of map (" << firstmap << "-" << lastmap << "):";
				cin >> n;
				cin.ignore();
			} while (n < firstmap || n > lastmap);
			game = new Game(name,n);
			game->start();
			break;
		case Exit:
			exit(0);
			break;
	}
}
