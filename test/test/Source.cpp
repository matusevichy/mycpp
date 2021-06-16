#define _CRT_SECURE_NO_WARNINGS
#include<iostream>
using namespace std;

struct Exam
{
	char Fio[50];
	char Group[10];
	unsigned rezult : 1;
};

Exam* Read(Exam* mas, int& n)
{
	FILE* fp = fopen("students.txt", "r");
	if (fp)
	{
		fread(&n, sizeof(n), 1, fp);
		mas = (Exam*)malloc(n * sizeof(Exam));
		fread(mas, sizeof(mas[0]), n, fp);
		fclose(fp);
	}
	else
	{
		cout << "File not found!";
	}
	return mas;
}

void Write(Exam* mas, int n)
{
	FILE* fp = fopen("students.txt", "w");
	if (fp)
	{
		fwrite(&n, sizeof(n), 1, fp);
		fwrite(mas, sizeof(mas[0]), n, fp);
		fclose(fp);
	}
	else
	{
		cout << "Error open file!";
	}
}

Exam* Sort(Exam* mas, int n)
{
	Exam tmp;
	for (int i = 0; i < n; i++)
	{
		for (int j = n - 1; j >= 0; j--)
		{
			if (strcmp(mas[j].Fio, mas[j - 1].Fio) < 0)
			{
				tmp = mas[j];
				mas[j] = mas[j - 1];
				mas[j - 1] = tmp;
			}
		}
	}
	for (int i = 0; i < n; i++)
	{
		for (int j = n - 1; j >= 0; j--)
		{
			if (strcmp(mas[j].Group, mas[j - 1].Group) == -1)
			{
				tmp = mas[j];
				mas[j] = mas[j - 1];
				mas[j - 1] = tmp;
			}
		}
	}
	return mas;
}

Exam* Add(Exam* mas, int& n)
{
	unsigned tmp;
	mas = (Exam*)realloc(mas, (n + 1) * sizeof(Exam));
	cout << "Enter FIO: ";
	gets_s(mas[n].Fio, 50);
	cout << "Enter group name: ";
	gets_s(mas[n].Group, 10);
	cout << "Enter exam result: ";
	cin >> tmp;
	mas[n].rezult = tmp;
	n++;
	mas = Sort(mas, n);
	Write(mas, n);
	return mas;
}

void Show(Exam* mas, int n, char op)
{
	for (int i = 0; i < n; i++)
	{
		if (mas[i].rezult == op)
		{
			cout << mas[i].Fio << "\t" << mas[i].Group << "\t" << mas[i].rezult << endl;
		}
	}
}

int main()
{
	int act, n = 0;
	Exam* mas = nullptr;
	mas = Read(mas, n);
	do
	{
		do
		{
			cout << "Select action:\n";
			cout << "1 - Add;\n";
			cout << "2 - Show list of good students;\n";
			cout << "3 - Show list of bad students;\n";
			cout << "0 - Exit.\n";
			cin >> act;
			getchar();
		} while (act < 0 || act>3);
		switch (act)
		{
		case 1:
		{
			mas = Add(mas, n);
			break;
		}
		case 2:
		{
			Show(mas, n, 1);
			break;
		}
		case 3:
		{
			Show(mas, n, 0);
			break;
		}
		default:
			break;
		}
	} while (act != 0);
}