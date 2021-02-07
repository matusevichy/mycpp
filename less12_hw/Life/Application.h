#pragma once
#include"Area.h"
class Application
{
	Area* newarea;
public:
	Application();
	~Application();
	void start();
	bool runApp();
};

