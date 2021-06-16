#include "Phonebook.h"

Phonebook::Phonebook(const char* name)
{
	mas = nullptr;
	strcpy_s(this->Name, name);
	curr_count = 0;
}

void Phonebook::Add()
{
	if (!mas)
	{
		mas = (Abonent*)malloc(sizeof(Abonent));
	}
	else
	{
		mas = (Abonent*)realloc(mas, (curr_count + 1) * sizeof(Abonent));
	}
	//Abonent tmp;
	//tmp.Add();
	mas[curr_count].Add();
	curr_count++;
}

void Phonebook::Print(Abonent* mas)
{
	for (int i = 0; i < curr_count; i++)
	{
		mas[i].Show();
	}
}

void Phonebook::Delete()
{
	int i;
	if ((i=findByFio()) != -1)
	{
		for (int j = i; j < this->curr_count - 1; j++)
		{
			mas[j] = mas[j + 1];
		}
		this->curr_count--;
		mas = (Abonent*)realloc(mas, curr_count * sizeof(Abonent));
	}
}

int Phonebook::findByFio()
{
	char tmp[30];
	cout << "Enter Fio:\n";
	gets_s(tmp, 30);
	for (int i = 0; i < this->curr_count; i++)
	{
		if (strcmp(tmp, mas[i].getFio()) == 0) return i;
	}
	return -1;
}

int Phonebook::findByNum()
{
	char tmp[11];
	cout << "Enter the phone number (10 digits):\n";
	gets_s(tmp, 11);
	for (int i = 0; i < this->curr_count; i++)
	{
		if (strcmp(tmp, mas[i].getNumber()) == 0) return i;
	}
	return -1;
}

void Phonebook::findByFios(Abonent*& tmp, int& count)
{
	char start[30], end[30];
	cout << "Enter start value:\n";
	gets_s(start, 30);
	cout << "Enter end value:\n";
	gets_s(end, 30);
	for (int i = 0; i < this->curr_count; i++)
	{
		if (strcmp(start, mas[i].getFio()) < 0 && strcmp(end, mas[i].getFio()) > 0)
		{
			addToMas(tmp, count, mas[i]);
		}
	}
}

void Phonebook::findByNums(Abonent*& tmp, int& count)
{
	char start[11], end[11];
	cout << "Enter start value:\n";
	gets_s(start, 11);
	cout << "Enter end value:\n";
	gets_s(end, 11);
	for (int i = 0; i < this->curr_count; i++)
	{
		if (strcmp(start, mas[i].getNumber()) < 0 && strcmp(end, mas[i].getNumber()) > 0)
		{
			addToMas(tmp, count, mas[i]);
		}
	}
}

bool Phonebook::loadFromFile()
{
	FILE* file;
	int n;
	fopen_s(&file, Name, "r");
	if (file)
	{
		fread(&n, sizeof(n), 1, file);
		mas = (Abonent*)realloc(mas, n * sizeof(Abonent));
		fread(mas, sizeof(mas[0]), n, file);
		curr_count = n;
	}
	else
	{
		return false;
	}
	fclose(file);
	return true;
}

void Phonebook::Edit()
{
	int i;
	if ((i= findByFio())!=-1)
	{
		mas[i].Edit();
	} 
}

void Phonebook::saveToFile(Abonent* mas, char* fname, int count)
{
	FILE* file;
	if (mas)
	{
		fopen_s(&file, fname, "w");
		fwrite(&count, sizeof(curr_count), 1, file);
		fwrite(mas, sizeof(mas[0]), curr_count, file);
	}
	else
	{
		fopen_s(&file, Name, "w");
		fwrite(&curr_count, sizeof(curr_count), 1, file);
		fwrite(this->mas, sizeof(this->mas[0]), curr_count, file);
	}
	fclose(file);
}

Abonent& Phonebook::operator[](int n)
{
	return this->mas[n];
}

void Phonebook::addToMas(Abonent*& mas,int& n, Abonent obj)
{
	if (!mas)
	{
		mas = (Abonent*)malloc(sizeof(Abonent));
	}
	else
	{
		mas = (Abonent*)realloc(mas, (n + 1) * sizeof(Abonent));
	}
	mas[n++] = obj;
}

Phonebook::~Phonebook()
{
	delete[] mas;
}
