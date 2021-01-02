#pragma once
#include"Client.h"
#include<time.h>

class Statistic
{
	Client cl;
	struct tm runtime;
public:
	Statistic();
	Statistic(Client&);
	void Show();
};

