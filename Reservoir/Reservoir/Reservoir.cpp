#include "Reservoir.h"

char* Reservoir::Gets()
{
	char* tmp=nullptr;
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

Reservoir::Reservoir()
{
	Name = NULL;
	type = 0;
	width = 0;
	length = 0;
	depth = 0;
}

Reservoir::Reservoir(const char* name, char type, float width, float length, float depth):Reservoir()
{
	strcpy_s(this->Name, strlen(name) + 1, name);
	this->type = type;
	this->width = width;
	this->length = length;
	this->depth = depth;
}

Reservoir::Reservoir(Reservoir& obj)
{
	this->Name = (char*)realloc(this->Name, strlen(obj.Name) + 1);
	strcpy_s(this->Name, strlen(obj.Name) + 1, obj.Name);
	this->type = obj.type;
	this->width = obj.width;
	this->length = obj.length;
	this->depth = obj.depth;
}

void Reservoir::operator=(Reservoir& obj)
{
	this->Name = (char*)realloc(this->Name, strlen(obj.Name) + 1);
	strcpy_s(this->Name, strlen(obj.Name) + 1, obj.Name);
	this->type = obj.type;
	this->width = obj.width;
	this->length = obj.length;
	this->depth = obj.depth;
}

void Reservoir::PrintType()
{
	switch (type)
	{
	case '1':
	{
		cout << "Sea";
		break;
	}
	case '2':
	{
		cout << "Pool";
		break;
	}
	case '3':
	{
		cout << "Lake";
		break;
	}
	}
}

float Reservoir::Square()
{
	return width * length;
}

float Reservoir::Volume()
{
	return width * length * depth;
}

void Reservoir::CompareSQ(Reservoir& obj)
{
	if (this->type == obj.type)
	{
		cout << this->Name << ": " << this->Square() << " - " << obj.Name << ": " << obj.Square() << "\n";
	}
	else
	{
		cout << "Differen types of reservoirs.\n";
	}
}

void Reservoir::CompareType(Reservoir& obj)
{	
	this->PrintType();
	cout << " - ";
	obj.PrintType();
	cout << "\n";
}

void Reservoir::Set()
{
	char* tmp;
	char type;
	float tmpf;
	cout << "Enter name:\n";
	tmp = Gets();
	if (tmp[0]!=0)
	{
		this->Name = (char*)malloc(strlen(tmp) + 1);
		strcpy_s(this->Name, strlen(tmp) + 1, tmp);
	}
	else
	{
		this->Name = NULL;
	}
	cout << "Enter type: (1 - Sea; 2 - Pool; 3 - Lake):\n";
	cin >> type;
	this->type = type;
	cout << "Enter width:\n";
	cin >> tmpf;
	this->width = tmpf;
	tmpf = NULL;
	cout << "Enter length:\n";
	cin >> tmpf;
	this->length = tmpf;
	tmpf = NULL;
	cout << "Enter depth:\n";
	cin >> tmpf;
	this->depth = tmpf;
	getchar();
}

char* Reservoir::Getname()
{
	return Name;
}

void Reservoir::Show()
{
	cout << Name << "\n";
	PrintType();
	cout << "\n" << width << "\n" << length << "\n" << depth << "\n";
}
