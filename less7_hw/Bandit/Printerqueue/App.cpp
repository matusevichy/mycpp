#include "App.h"

void App::Start()
{
	int act;
	while (true)
	{
		system("cls");
		menu();
		cin >> act;
		cin.ignore();
		switch (act)
		{
		case 1:
		{
			newbase.Set();
			break;
		}
		case 2:
		{
			newbase.Delete();
			break;
		}
		case 3:
		{
			newbase.Print();
			Wait();
			break;
		}
		case 4:
		{
			addTask();
			break;
		}
		case 5:
		{
			qt.Print();
			Wait();
			break;
		}
		case 6:
		{
			qs.Print();
			Wait();
			break;
		}
		case 7:
		{
			runTask();
			break;
		}
		case 0:
		{
			exit(0);
			break;
		}
		default:
			break;
		}
	}
}

void App::addTask()
{
	if (!qt.isFull())
	{
		cout << "Enter ClientID: ";
		int cid;
		cin >> cid;
		cin.ignore();
		cout << "Enter task:\n";
		char str[100];
		gets_s(str, 100);
		Task tmp(newbase.Get(cid), str);
		qt.Add(tmp);
	}
	else
	{
		cout << "Queue is full!";
		Wait();
	}
}

void App::runTask()
{
	if(qt.isEmpty())
	{
		cout << "Task queue is empty.\n";
		Wait();
	}
	else
	{
		Statistic tmp(qt.Extract().getClient());
		if (qs.isFull())
		{
			while (true)
			{
				char act;
				cout << "The queue of the statistic is full.\nDelete the oldest record? y/n";
				act = getchar();
				if (act == 'y')
				{
					qs.Extract();
					qs.Add(tmp);
				}
				else
				{
					cout << "Task not saved in the statistic queue.";
					Wait();
				}
			}
		}
		else
		{
			qs.Add(tmp);
		}
	}
}

void App::menu()
{
	cout << "1 - Add client;\n";
	cout << "2 - Delete client;\n";
	cout << "3 - Show base;\n";
	cout << "4 - Add task;\n";
	cout << "5 - Print task queue;\n";
	cout << "6 - Print statistic queue;\n";
	cout << "7 - Run task;\n";
	cout << "0 - Exit.\n";
}

void App::Wait()
{
	cout << "Press any key...";
	_getch();
}

