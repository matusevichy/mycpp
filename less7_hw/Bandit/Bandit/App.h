#pragma once
#include "Game.h"
class App
{
	enum {EXIT, NEW};
	Game* newgame;
public:
	void Start();
	void menu();
	~App() { delete newgame; }
};

