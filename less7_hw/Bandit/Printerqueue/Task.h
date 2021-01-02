#pragma once
#include"Client.h"

class Task
{
	Client cl;
	char texttask[100];
public:
	Task();
	Task(Client&,char*);
	Client& getClient();
	void Show();
	int getPriority();
};

