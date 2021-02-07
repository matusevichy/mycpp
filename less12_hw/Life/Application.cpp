#include "Application.h"

Application::Application()
{
	newarea = nullptr;
}

Application::~Application()
{
	delete newarea;
}

void Application::start()
{
	char ch;
	while (true)
	{
		cout << "New game? (y/n)\n";
		ch = getchar(); 
		switch (ch)
		{
		case 'y':
		{
			newarea = new Area(10);
			runApp();
			break;
		}
		case 'n': 
			exit(0);
		default:
			break;
		}
	}
}

bool Application::runApp()
{
	while (true)
	{
		if (!newarea->addYear())
		{
			cout << "End of the game!";
			break;
		}
	}
	return false;
}
