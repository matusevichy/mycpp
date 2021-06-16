#include "App.h"

void App::Start()
{
	int act;
	while (true)
	{
		system("cls");
		mainMenu();
		cin >> act;
		cin.ignore();
		switch (act)
		{
		case OPEN:
			if(Open()) Run();
			break;
		case EXIT:
			exit(0);
		default:
			break;
		}
	}
}

void App::mainMenu()
{
	cout << "1 - Open phonebook;\n";
	cout << "0 - Exit.\n";
}

void App::secondMenu()
{
	cout << "select option:\n";
	cout << "1 - Add abonent;\n";
	cout << "2 - Delete abonent;\n";
	cout << "3 - Edit abonent;\n";
	cout << "4 - Find abonent(s);\n";
	cout << "5 - Print the list of abonents;\n";
	cout << "6 - Save the phonebook to file;\n";
	cout << "0 - Exit.\n";
}

bool App::Open()
{
	char name[20];
	char ch;
	cout << "Enter phonebook`s name: ";
	gets_s(name, 20);
	NewBook = new Phonebook(name);
	if (!NewBook->loadFromFile())
	{
		while (true)
		{
			system("cls");
			cout << name << " phonebook not found. Do you want create new book? (y/n)";
			ch = getchar();
			switch (ch)
			{
			case 'y':
				NewBook->saveToFile(nullptr,nullptr,0);
				return true;
			case 'n':
				delete NewBook;
				return false;
			default:
				break;
			}
		}
	}
	return true;
}

bool App::Run()
{
	int act;
	while (true)
	{
		system("cls");
		secondMenu();
		cin >> act;
		cin.ignore();
			switch (act)
			{
			case ADD:
			{
				NewBook->Add();
				break;
			}
			case DELETE:
			{
				NewBook->Delete();
				break;
			}
			case EDIT:
			{
				NewBook->Edit();
				break;
			}
			case FIND:
			{
				Find();
				break;
			}
			case PRINT:
			{
				Print();
				break;
			}
			case SAVE:
			{
				NewBook->saveToFile(nullptr, nullptr, 0);
				break;
			}
			case EXIT:
			{
				return false;
			}
			default:
				break;
			}
	}
	return false;
}

void App::findMenu()
{
	cout << "1 - Find by number;\n";
	cout << "2 - Find by Fio\n";
	cout << "0 - Exit;\n";
}

bool App::Find()
{	
	int act;
	while (true)
	{
		system("cls");
		findMenu();
		cin >> act;
		cin.ignore();
		switch (act)
		{
		case BYNUM:
		{
			int i;
			if ((i = NewBook->findByNum()) != -1)
			{
				(*NewBook)[i].Show();
				_getch();
			}
			break;
		}
		case BYFIO:
		{
			int i;
			if ((i=NewBook->findByFio()) != -1)
			{
				(*NewBook)[i].Show();
				_getch();
			}
			break;
		}
		case EXIT:
			return true;
		default:
			break;
		}
	}

}

bool App::Print()
{
	int act;
	while (true)
	{
		Abonent* tmpmas=nullptr;
		int tmpcount=0;
		system("cls");
		findMenu();
		cin >> act;
		cin.ignore();
		switch (act)
		{
		case BYNUM:
		{
			NewBook->findByNums(tmpmas, tmpcount);
			Sort(tmpmas, tmpcount);
			showResult(tmpmas, tmpcount);
			break;
		}
		case BYFIO:
		{
			NewBook->findByFios(tmpmas,tmpcount);
			Sort(tmpmas, tmpcount);
			showResult(tmpmas, tmpcount);
			break;
		}
		case EXIT:
			delete[] tmpmas;
			return true;
		default:
			break;
		}
	}

}

bool App::showResult(Abonent*& mas, int& count) const
{
	char ch;
	for (int i = 0; i < count; i++)
	{
		mas[i].Show();
	}
	cout << "Do you want save this to file? (y/n)\n";
	while (true)
	{
		ch = getchar();
		getchar();
		if (ch == 'y')
		{
			char name[20];
			cout << "Enter file name: ";
			gets_s(name, 20);
			NewBook->saveToFile(mas, name, count);
			return true;
		}
		else if (ch == 'n')
		{
			return false;
		}
	}

}

void App::Sort(Abonent*& mas, int& count)
{
	for (int i = 0; i < count; i++)
	{
		for (int j = count; j > 0; j--)
		{
			Abonent tmp;
			if (strcmp(mas[j].getFio(), mas[j - 1].getFio()) < 0)
			{
				tmp = mas[j];
				mas[j] = mas[j - 1];
				mas[j - 1] = tmp;
			}
		}
	}
}
