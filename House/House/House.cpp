#include "House.h"


House::House(int count)
{
	size = count;
	mas = new Flat[count];
}

void House::Add()
{
	int n;
	do
	{
		cout << "Enter the number of the flat (1 to " << size << "):\n";
		cin >> n;
		cin.ignore();
	} while (n <= 0 || n > size);
	mas[n - 1].Add();
}

void House::Delete()
{
	int n;
	do
	{
		cout << "Enter the number of the flat (1 to " << size << "):\n";
		cin >> n;
		cin.ignore();
	} while (n <= 0 || n > size);
	mas[n - 1].Delete();
}

void House::ShowAll()
{
	for (int i = 0; i < size; i++)
	{
		cout << "Flat n." << i + 1 << "\n";
		mas[i].Show();
	}
}
