#include "Base.h"

char* Base::Gets()
{
	char* tmp = nullptr;
	char ch;
	int n = 0;
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
	count = 0;
}

Base::Base(Base& obj)
{
	for (int i = 0; i < count; i++)
	{
		this->mas[i] = obj.mas[i];
	}
	this->count = obj.count;
}

void Base::Set()
{
	char* tmp;
	int pr;
	mas = (Client*)realloc(mas, (count + 1) * sizeof(Client));
	cout << "Enter the name of the client: ";
	tmp = Gets();
	cout<<"Enter the priority for client:";
	cin >> pr;
	Client newclient(tmp, pr);
	mas[count] = newclient;
	count++;
}

Client& Base::Get(int n)
{
	return mas[n];
}

void Base::Print()
{
	for (int i = 0; i < count; i++)
	{
		cout << "ClientID: " << i << endl;
		mas[i].Show();
	}
}

void Base::Delete()
{
	int index;
	cout << "Enter the index of the client: ";
	cin >> index;
	for (int i = index+1; i < count; i++)
	{
		mas[i - 1] = mas[i];
	}
	count--;
	mas = (Client*)realloc(mas, count * sizeof(Client));
}
