#include"Complex.h"

int main()
{
	Complex num1, num2;
	num1.Set();
	num2.Set();
	int act;
	do
	{
		do
		{
			cout << "Select action:\n";
			cout << "1 - '+'\n";
			cout << "2 - '-'\n";
			cout << "3 - '*'\n";
			cout << "4 - '/'\n";
			cout << "0 - Exit.\n";
			cin >> act;
		} while (act < 0 || act>4);
		switch (act)
		{
		case 1:
		{
			num1 + num2;
			break;
		}
		case 2:
		{
			num1 - num2;
			break;
		}
		case 3:
		{
			num1* num2;
			break;
		}
		case 4:
		{
			num1 / num2;
			break;
		}
		default:
			break;
		}
	} while (act != 0);
}

