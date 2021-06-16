#include "List.h"

List::List()
{
	first = last = nullptr;
	count = 0;
}

List::~List()
{
	Clear();
}

void List::Add()
{
	Offence* newoff = new Offence;
	cout << "Enter the text of offence:\n";
	gets_s(newoff->name, 50);
	cout << "Enter sum:\n";
	cin >> newoff->sum;
	newoff->next = nullptr;
	cin.ignore();
	if (!this->first)
	{
		this->first = this->last = newoff;
	}
	else
	{
		last->next = newoff;
		last = newoff;
	}
	count++;
}

void List::Add(const char* name, float sum)
{
	Offence* newoff = new Offence;
	newoff->next = nullptr;
	newoff->sum = sum;
	strcpy_s(newoff->name, name);
	if (!this->first)
	{
		this->first = this->last = newoff;
	}
	else
	{
		last->next = newoff;
		last = newoff;
	}
	count++;
}

void List::Clear()
{
	Offence* tmp;
	while (first)
	{
		tmp = first;
		first = first->next;
		delete tmp;
	}
}

void List::Print()
{
	Offence* tmp;
	tmp = first;
	while (tmp)
	{
		cout << tmp->name << " ; Sum = " << tmp->sum << endl;
		tmp = tmp->next;
	}
}
