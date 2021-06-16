#include"Application.h"
#include<time.h>

int main()
{
	srand(time(0));
	Application* newApplication = new Application;
	newApplication->start();
}