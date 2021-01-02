#include "App.h"
#include<Windows.h>
#include <conio.h>

void App::start()
{
	int act;
	while (true)
	{
		main_menu();
		cin >> act;
		switch (act)
		{
		case time:
		{
			runapp(time);
			break;
		}
		case 2:
		{
			runapp(matrix);
			break;
		}
		case 0:
		{
			exit(0);
			break;
		}
		default:
		{
			cout << "Uncorrect value!";
			Sleep(1000);
			system("cls");
			break;
		}
		}
	}
}

void App::main_menu()
{
	system("cls");
	cout << "1 - Work of time;\n";
	cout << "2 - Work of matrix;\n";
	cout << "0 - Exit.\n";
}

void App::time_menu()
{
	cout << "1 - Set time1;\n";
	cout << "2 - Set time2;\n";
	cout << "3 - Get time1 + time2;\n";
	cout << "4 - Get time1 - time2;\n";
	cout << "5 - Compare time1 and time2;\n";
	cout << "0 - Exit.\n";
}

void App::matrix_menu()
{
	cout << "1 - Set matrix1;\n";
	cout << "2 - Set matrix2;\n";
	cout << "3 - Transpon matrix1;\n";
	cout << "4 - Transpon matrix2;\n";
	cout << "5 - Get matrix1 + matrix2;\n";
	cout << "6 - Get matrix1 * matrix2;\n";
	cout << "7 - Set element's value;\n";
	cout << "8 - Get element's value;\n";
	cout << "0 - Exit.\n";
}

bool App::runapp(int type)
{
	switch (type)
	{
	case time:
	{
		runtime();
		break;
	}
	case matrix:
	{
		runmatrix();
		break;
	}
	default:
		break;
	}
	return true;
}

bool App::runtime()
{
	Time t1, t2;
	int act;
	while (true)
	{
		system("cls");
		cout << "t1 = " << t1 << "\t\tt2 = " << t2 << endl;
		time_menu();
		cin >> act;
		cin.ignore();
		switch (act)
		{
		case set1:
		{
			t1.setTime();
			break;
		}
		case set2:
		{
			t2.setTime();
			break;
		}
		case sum:
		{
			cout << t1 + t2 << endl;
			cout << "Press any key...";
			_getch();
			break;
		}
		case diff:
		{
			cout << t1 - t2 << endl;
			cout << "Press any key...";
			_getch();
			break;
		}
		case compare:
		{
			t1.compare(t2);
			cout << "Press any key...";
			_getch();
			break;
		}
		case 0:
		{
			return true;
		}
		default:
			cout << "Uncorrect value!";
			Sleep(1000);
			system("cls");
			break;
		}
	}
}

bool App::runmatrix()
{
	Matrix m1(3,3), m2(3,3);
	int act;
	while (true)
	{
		system("cls");
		cout << "Matrix1:\n" << m1 << "Matrix2:\n" << m2;
		matrix_menu();
		cin >> act;
		switch (act)
		{
		case set1:
		{
			m1.Rand();
			break;
		}
		case set2:
		{
			m2.Rand();
			break;
		}
		case transpon1:
		{
			m1.Transpon();
			break;
		}
		case transpon2:
		{
			m2.Transpon();
			break;
		}
		case sum_m:
		{
			cout << m1 + m2;
			cout << "Press any key...";
			_getch();
			break;
		}
		case prod_m:
		{
			cout << m1 * m2;
			cout << "Press any key...";
			_getch();
			break;
		}
		case set_el:
		{
			int n, i, j, newval;
			cout << "Enter the numbers of matrix, row, column and new value" << endl;
			cin >> n >> i >> j >> newval;
			switch (n)
			{
			case 1:
			{
				m1[i][j] = newval;
				break;
			}
			case 2:
			{
				m2[i][j] = newval;
				break;
			}
			default:
				cout << "Uncorrect value!";
				Sleep(1000);
				system("cls");
				break;
			}
			break;
		}
		case get_el:
		{
			int n, i, j;
			cout << "Enter the numbers of matrix, row and column" << endl;
			cin >> n >> i >> j;
			switch (n)
			{
			case 1:
			{
				cout << m1[i][j] << endl;
				break;
			}
			case 2:
			{
				cout << m2[i][j] << endl;
				break;
			}
			default:
				cout << "Uncorrect value!";
				Sleep(1000);
				system("cls");
				break;
			}
			cout << "Press any key...";
			_getch();
			break;
		}
		case 0:
			return true;
		default:
			break;
		}
	}
	return false;
}
