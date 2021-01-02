#pragma once
#include"Drum.h"
#include"Player.h"
#include<conio.h>

class Game
{
	Player newplayer;
	Drum d1, d2, d3;
public:
	Game(int, int);
	bool Start();
	void Roll_all();
	bool isWin();
};

