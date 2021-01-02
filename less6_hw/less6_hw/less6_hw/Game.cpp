#include "Game.h"


Game::Game()
{

}

Game::Game(int n): deck(n)
{
	deck.Generate();
}

bool Game::Start()
{
	int act;
	Player tmp;
	myplayer = tmp;
	bankir = tmp;
	bool playerisPassed = false, bankirisPassed = false;;
	addCard(myplayer);
	addCard(myplayer);
	addCard(bankir);
	addCard(bankir);
	while (true)
	{
		system("cls");
		wcout << "Bankir\t\t" << "Score: " << bankir.getScore() << endl;
		bankir.showHand();
		wcout << endl << endl;
		wcout << "MyPlayer\t\t" << "Score: " << myplayer.getScore() << endl << endl;
		myplayer.showHand();
		if (deck.getRealsize() <= 10)
		{
			deck.Refresh();
		}
		if (myplayer.getScore() > 21)
		{
			showLose();
			return true;
		}
		else if(bankir.getScore()>21)
		{
			showWon();
			return true;
		}
		if (myplayer.getScore() == 21)
		{
			playerisPassed = true;
			bankirRun();
			bankirisPassed = true;
		}
		if (playerisPassed && bankirisPassed) {
			if (myplayer.getScore() > bankir.getScore())
			{
				showWon();
				return true;
			}
			else if (myplayer.getScore() < bankir.getScore())
			{
				showLose();
				return true;
			}
			else
			{
				showPush();
				return true;
			}
		}
		if (!playerisPassed)
		{
			menu();
		}
		cin >> act;
		switch (act)
		{
		case 1:
		{
			addCard(myplayer);
			break;
		}
		case 2:
		{
			playerisPassed = true;
			bankirRun();
			bankirisPassed = true;
			break;
		}
		case 0:
		{
			return false;
		}
		default:
			break;
		}
	}
}

void Game::menu()
{
	wcout << "1 - Get card;\n";
	wcout << "2 - Pass;\n";
	wcout << "0 - Exit.\n";
}

void Game::addCard(Player& obj)
{
	Card tmp;
	tmp = deck.Rand();
	obj.addCard(tmp);
}

void Game::showLose()
{
	wcout << "You lose!\n";
	wcout << "Press any key...";
	_getch();
}

void Game::showWon()
{
	wcout << "You won!\n";
	wcout << "Press any key...";
	_getch();
}

void Game::showPush()
{
	wcout << "PUSH\n";
	wcout << "Press any key...";
	_getch();
}

void Game::bankirRun()
{
	while (bankir.getScore()<17)
	{
		addCard(bankir);
	}
}

