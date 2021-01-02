#include "Human.h"

char* Human::Gets()
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

Human::Human()
{
	Fio = nullptr;
}

Human::Human(Human& obj)
{
	if (this->Fio == nullptr)
	{
		this->Fio = (char*)malloc(strlen(obj.Fio) + 1);
	}
	strcpy_s(this->Fio, strlen(obj.Fio)+1, obj.Fio);
	this->Age = obj.Age;
}

void Human::operator=(Human& obj)
{
	this->Fio = (char*)malloc(strlen(obj.Fio) + 1);
	strcpy_s(this->Fio, strlen(obj.Fio) + 1, obj.Fio);
	this->Age = obj.Age;

}

void Human::Add()
{
	char* tmp;
	cout << "Enter FIO:\n";
	tmp = Gets();
	Fio = (char*)malloc(strlen(tmp)+1);
	strcpy_s(Fio, strlen(tmp) + 1, tmp);
	cout << "Enter age:";
	cin >> Age;
}

void Human::Show()
{
	cout << "Fio: " << Fio << "\n";
	cout << "Age: " << Age << "\n";
}
