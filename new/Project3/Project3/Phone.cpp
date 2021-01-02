#include "Phone.h"

void Phone::Set()
{
	char flag = 0;
	do
	{
		cout << "Enter type of phone:\n";
		cout << "1 - mobile; 2 - work; 3 - home.\n";
		this->type=getchar();
		getchar();
	} while (this->type < '1' || this->type > '3');
	do
	{
		cout << "Enter the phone number (10 digits):\n";
		gets_s(this->number, 11);
		for (short i = 0; i < 10; i++)
		{
			if (!isdigit(this->number[i]))
			{
				flag = 1;
				cout << "Incorrect number!\n";
				break;
			}
			else flag = 0;
		}
	} while (flag != 0);
}

void Phone::Get()
{
	if (this->type == '1') cout << "Mobile number\t";
	else if (this->type == '2') cout << "Work number\t";
	else if (this->type == '3') cout << "Home number\t";
	cout << this->number << "\n";
}
