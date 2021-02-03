#include "Handbook.h"

Handbook::Handbook()
{
	capacity = 0;
	count = 0;
	abonents = nullptr;
}

Handbook::~Handbook()
{
	delete[] abonents;
}

void Handbook::add()
{
	if (count<capacity)
	{
		abonents[count++].set();
	}
	else
	{
		cout << "This handbook is full!\n";
	}
}

void Handbook::find(Option option)
{
	string search;
	switch (option)
	{
	case BYNAME:
		cout << "Enter search name:\n";
		getline(cin, search);
		break;
	case BYOWNER:
		cout << "Enter search owner:\n";
		getline(cin, search);
		break;
	case BYPHONE:
		cout << "Enter search phone:\n";
		getline(cin, search);
		break;
	case BYOCCUPATION:
		cout << "Enter search occupation:\n";
		getline(cin, search);
		break;
	default:
		break;
	}
	for (int i = 0; i < count; i++)
	{
		if (option != ALL)
		{
			bool isTrue = false;
			if (abonents[i].check(option, search))
			{
				abonents[i].print();
			}
		}
		else
		{
			abonents[i].print();
		}
	}
}

void Handbook::save()
{
	ofstream out("handbook.bin", ios::binary);
	out << count << " ";
	out << capacity << " ";
	for (int i = 0; i < count; i++)
	{
		out << abonents[i];
	}
	out.close();
}

void Handbook::load()
{
	ifstream in("handbook.bin", ios::binary);
	if (in.is_open())
	{
		in >> count;
		in >> capacity;
		abonents = new Abonent[capacity];
		for (int i = 0; i < count; i++)
		{
			in >> abonents[i];
		}
	}
	else
	{
		int size;
		cout << "Enter hanbook size:\n";
		cin >> size;
		abonents = new Abonent[size];
		count = 0;
		capacity = size;
	}
	in.close();
}
