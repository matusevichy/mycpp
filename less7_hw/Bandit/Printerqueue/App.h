#pragma once
#include"Base.h"
#include"Queue_p.h"
#include"Queue.h"
#include"Task.h"
#include"Statistic.h"
#include<conio.h>

class App
{
	Base newbase;
	Queue_p<Task> qt;
	Queue<Statistic> qs;
public:
	App(int n): qt(n),qs(n)
	{
	};
	void Start();
	void addTask();
	void runTask();
	void menu();
	void Wait();
};

