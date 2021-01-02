#pragma once
#include"player.h"
#include"deck.h"
#include<conio.h>

class Game
{
	Player myplayer, bankir;
	Deck deck;
public:
	Game();
	Game(int n);
	bool Start();
	void menu();
	void addCard(Player&);
	void showLose();
	void showWon();
	void showPush();
	void bankirRun();
};

