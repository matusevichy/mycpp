#include "Application.h"

Application::~Application()
{
	delete game;
}

void Application::start()
{
	game = new Game("vasya",1);

	int action;
	while (true) {
		system("cls");
		menu();
		std::cin >> action;
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
			game->start();
			break;
		case Exit:
			exit(0);
			break;
	}
}
