#include"House.h"

int main()
{
	short act, size;
	cout << "Enter the count of the flat:\n";
	cin >> size;
	House obj1(size);
	do {
		do {
			cout << "Select action:\n";
			cout << "1 - Add human;\n";
			cout << "2 - Delete human;\n";
			cout << "3 - Show all;\n";
			cout << "0 - Exit.\n";
			cin >> act;
			cin.ignore();
		} while (act < 0 || act>3);
		switch (act)
		{
		case 1:
		{
			obj1.Add();
			break;
		}
		case 2:
		{
			obj1.Delete();
			break;
		}
		case 3:
		{
			obj1.ShowAll();
			break;
		}
		default:
			break;
		}
	} while (act != 0);
}