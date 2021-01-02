#include "app.h"

App::App()
{
}

void App::Start()
{
	int act;
	while (true)
	{
		system("cls");
		main_menu();
		cin >> act;
		switch (act)
		{
		case new_game:
		{
			newGame();
			break;
		}
		case continue_game:
		{
			continueGame();
			break;
		}
		case exit_game:
		{
			exit(0);
		}
		default:
			cout << "Uncorrect value!";
			Sleep(1000);
			break;
		}
	}
}

void App::main_menu()
{
	wcout << "1 - New game;\n";
	if (isGame)
	{
		wcout << "2 - Continue game;\n";
	}
	wcout << "0 - Exit.\n";
}

void App::newGame()
{
	int count;
	wcout << "Enter count of deck for game: ";
	cin >> count;
	Game tmp(count * 52);
	this->game = tmp;
	isGame = true;
	game.Start();
}

void App::continueGame()
{
	game.Start();
}
