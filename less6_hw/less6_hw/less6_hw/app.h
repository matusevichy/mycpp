#pragma once
#include"Game.h"

class App
{
	enum {exit_game, new_game, continue_game};
	Game game;
	int isGame = false;
public:
	App();
	void Start();
	void main_menu();
	void newGame();
	void continueGame();
};

