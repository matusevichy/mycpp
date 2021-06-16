#pragma once
#include"Field.h"

#define WINDOW_COLOR Color::Green

class Application
{
	Text mainMenu;
	Font menuFont;
public:
	void start();
	void createMenu();
};

