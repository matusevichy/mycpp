#pragma once
#include <iostream>
#include "Game.h"

class Application
{
	enum MenuAction {
		NewGame = 1,
		Exit = 2
	};

public:
	~Application();
	void start();
private:
	Game* game;
	const int firstmap = 1;
	const int lastmap = 3;
	void menu();
	void runMenuAction(int action);
};