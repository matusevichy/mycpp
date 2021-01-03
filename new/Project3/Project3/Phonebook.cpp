#include "Phonebook.h"

Phonebook::Phonebook(const char* name)
{
	strcpy_s(this->Name, name);
	curr_count = 0;
}

void Phonebook::Add()
{
	if (curr_count < 100)
	{
		mas[this->curr_count].Add();
		curr_count++;
	}
	else
	{
		cout << "Phonebook is full!";
	}
}

void Phonebook::Print()
{
	cout << this->Name << "\n";
	for (int i = 0; i < curr_count; i++)
	{
		mas[i].Show();
	}
}

void Phonebook::Delete()
{
	char tmp[30];
	cout << "Enter Fio for delete from the phonebook:\n";
	gets_s(tmp, 30);
	for (short i = 0; i < this->curr_count; i++)
	{
		if (strcmp(tmp, mas[i].Get_Fio()) == 0)
		{
			for (short j = i; j < this->curr_count - 1; j++)
			{
				mas[j] = mas[j + 1];
			}
			this->curr_count--;
			break;
		}
	}
}

void Phonebook::Find_by_Fio()
{
	char tmp[30];
	cout << "Enter Fio:\n";
	cin >> tmp;
	for (short i = 0; i < this->curr_count; i++)
	{
		if (strcmp(tmp, mas[i].Get_Fio()) == 0) mas[i].Show();
	}

}
