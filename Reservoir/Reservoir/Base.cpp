#include "Base.h"

char* Base::Gets()
{
	char* tmp = nullptr;
	int n = 0;
	char ch;
	while ((ch = getchar()) != '\n')
	{
		tmp = (char*)realloc(tmp, n + 1);
		tmp[n] = ch;
		n++;
	}
	tmp = (char*)realloc(tmp, n + 1);
	tmp[n] = 0;
	return tmp;
}

Base::Base()
{
	mas = nullptr;
	size = 0;
}

void Base::Add()
{
	mas = (Reservoir*)realloc(mas, (size + 1) * sizeof(Reservoir));
	mas[size].Set();
	size++;
}

void Base::Delete()
{
	char* tmp;
	cout << "Enter name of the reservoir for delete:\n";
	tmp = Gets();
	for (int i = 0; i < size; i++)
	{
		if (strcmp(tmp, mas[i].Getname()) == 0)
		{
			for (int j = i; j < size-1; j++)
			{
				mas[j] = mas[j + 1];
			}
			size--;
			mas = (Reservoir*)realloc(mas, (size + 1) * sizeof(Reservoir));
		}
	}
}

void Base::Print()
{
	for (int i = 0; i < size; i++)
	{
		mas[i].Show();
	}
}

Reservoir& Base::Get(int n)
{
	return mas[n];
}
