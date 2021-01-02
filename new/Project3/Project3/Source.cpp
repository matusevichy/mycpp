#include "Phonebook.h"

int main()
{
	short act;
	Phonebook book("My_phonebook");
	do
	{
		do
		{
			cout << "select option:\n";
			cout << "1 - Add abonent;\n";
			cout << "2 - Delete abonent;\n";
			cout << "3 - Find abonent by Fio;\n";
			cout << "4 - Show all abonent;\n";
			cout << "0 - Exit.\n";
			cin >> act;
			getchar();
		} while (act < 0 || act>4);
		switch (act)
		{
		case 1:
		{
			book.Add();
			break;
		}
		case 2:
		{
			book.Delete();
			break;
		}
		case 3:
		{
			book.Find_by_Fio();
			break;
		}
		case 4:
		{
			book.Print();
			break;
		}
		default:
			break;
		}
	} while (act != 0);
}