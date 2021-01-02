#include<io.h>
#include<fcntl.h>
#include<Windows.h>
#include"app.h"

int main()
{
	fflush(stdout); 
	_setmode(_fileno(stdout), _O_U16TEXT);
	srand(time(0));
	//Deck tmp(52);
	//tmp.Generate();
	App newapp;
	newapp.Start();
}