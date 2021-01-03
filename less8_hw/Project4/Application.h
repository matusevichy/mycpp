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

	void menu();
	void runMenuAction(int action);
};