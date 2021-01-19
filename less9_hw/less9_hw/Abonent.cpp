#include "Abonent.h"


void Abonent::Add()
{
	system("cls");
	cout << "Enter Fio:\n";
	gets_s(Fio, 30);
	setNumber();
}

void Abonent::Show()
{
	cout << this->Fio << endl;
	cout << this->number << endl;
}

void Abonent::Edit()
{
	system("cls");
	cout << Fio << endl;
	if(changeThis())
	{
		cout << "Enter Fio:\n";
			gets_s(Fio, 30);
	}
	cout << number << endl;
	if (changeThis())
	{
		setNumber();
	}
}

bool Abonent::changeThis()
{
	char ch;
	cout << "Do you want change this? (y/n)\n";
	while (true)
	{
		ch = getchar();
		getchar();
		if (ch == 'y') return true;
		else if (ch == 'n') return false;
	}
}

void Abonent::setNumber()
{
	char flag = 0;
	do
	{
		cout << "Enter the phone number (10 digits):\n";
		gets_s(this->number, 11);
		for (int i = 0; i < 10; i++)
		{
			if (!isdigit(this->number[i]))
			{
				flag = 1;
				cout << "Incorrect number!\n";
				break;
			}
			else flag = 0;
		}
	} while (flag != 0);
	this->number[10] = 0;
}
