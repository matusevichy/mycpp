#include "Flat.h"

Flat::Flat()
{
	mas = nullptr;
	count = 0;
}

void Flat::Add()
{
	Human tmp;
	char flag=0;
	tmp.Add();
	for (int i = 0; i < count; i++)
	{
		if (strcmp(mas[i].GetFio(), tmp.GetFio()) == 0)
		{
			flag = 1;
			break;
		}
	}
	if (flag == 0)
	{
		mas = (Human*)realloc(mas, (count + 1) * sizeof(Human));
		mas[count] = tmp;
		count++;
		cout << "Human added.\n";
	}
	else
	{
		cout << "This human exist.\n";
	}
}

void Flat::Delete()
{
	char* str;
	cout << "Enter human`s Fio:\n";
	str = Human::Gets();
	for (short i = 0; i < count; i++)
	{
		if (strcmp(str, mas[i].GetFio()) == 0)
		{
			for (short j = i; j < count-1; j++)
			{
				mas[j] = mas[j + 1];
			}
			count--;
			mas = (Human*)realloc(mas, (count + 1) * sizeof(Human));
		}
	}
}

void Flat::Show()
{
	for (short i = 0; i < count; i++)
	{
		mas[i].Show();
	}
}
