#include "Game.h"

Game::Game(int count, int first):	d1(count, first), d2(count, first), d3(count, first)
{
	
}

bool Game::Start()
{
	while (true)
	{	
		char key;
		if (newplayer.Get() <= 0)
		{
			system("cls");
			cout << "You lose...\nPress any key...\n";
			_getch();
			return true;
		}
		system("cls");
		cout << "You score: " << newplayer.Get() << endl;
		cout << d1.Show() << "\t" << d2.Show() << "\t" << d3.Show() << endl;
		cout << "Press Enter for roll...\nPress Space for exit...\n" << endl;
		while ((key=_getch())==13)
		{
			--newplayer;
			Roll_all();
			if (isWin()) ++newplayer;
			break;
		}
		if (key == 32)
		{
			return true;
		}
	}
}

void Game::Roll_all()
{
	d1.Roll();
	d2.Roll();
	d3.Roll();
}

bool Game::isWin()
{
	return d1.Show() == d2.Show() && d1.Show() == d3.Show();
}
