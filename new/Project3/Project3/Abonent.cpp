#include "Abonent.h"

void Abonent::Add()
{
	char ch;
	cout << "Enter Fio:\n";
	gets_s(Fio, 30);
	cout << "Enter note:\n";
	gets_s(this->Note);
	do
	{
		cout << "Do you want add the phone number (Y or N)?(Max count is 5, current count is " << this->count_number << "\n";
		ch=getchar();
		getchar();
		if (ch == 'Y')
		{
			this->numbers = (Phone*)realloc(this->numbers, (this->count_number + 1) * sizeof(Phone));
			this->numbers[this->count_number].Set();
			this->count_number++;
		}
		else if (ch == 'N') break;
	} while (this->count_number < 5);
}

void Abonent::Show()
{
	cout << this->Fio << "\n";
	for (short i = 0; i < this->count_number; i++)
	{
		this->numbers[i].Get();
	}
	cout << this->Note << "\n";
}
