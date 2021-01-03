#include <iostream>
#include <Windows.h>

using namespace std;

//int counter = 0;

class Person {
	char firstName[30];
	char lastName[30];
	int age;
public:
	//объявление статической переменной
	static int counter;
	Person(const char* firstName, const char* lastName, int age) {
		counter++;
		strcpy_s(this->firstName, firstName);
		strcpy_s(this->lastName, lastName);
		this->age = age;
	}
};

class Math {
public:
	static int sum(int a, int b) {
		return a + b;
	}
	static int diff(int a, int b) {
		return a - b;
	}
};

class FileHelper {
public:
	static void write(char* filename, char* content) {
		//логика сохранения данных в файл
		cout << "Данные успешно сохранены в файл \"" << filename << "\"" << endl;
	}
	static char* read(char* filename) {
		cout << "Данные успешно считаны" << endl;
		char buff[100] = "Какие-то данные из файла...";
		return buff;
	}
};
//инициализация статической переменной
int Person::counter = 0;

class ConsoleWriter {
public:
	static void write(const char* str) {
		for (int i = 0; i < strlen(str); i++)
		{
			cout << str[i];
			Sleep(50);
		}
		cout << endl;
	}
	static void write(int arr[3][3]) {
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				cout << arr[i][j] << " ";
				Sleep(50);
			}
			cout << endl;
		}
	}
};

int main() {

	/*for (int i = 0; i < 10; i++)
	{
		static int a = 0;
		cout << a << endl;
		a++;
	}*/

	/*Person p1("Vasya", "Pupkin", 20);
	Person p2("Petya", "Ivanov", 25);

	cout << "Counter = " << Person::counter << endl;*/

	
	cout << Math::sum(10, 20) << endl;

	char str[] = "Hello world";
	ConsoleWriter::write(str);

	int arr[3][3] = {
		{1, 2, 3},
		{4, 5, 6},
		{7, 8, 9}
	};

	ConsoleWriter::write(arr);

	return 0;
}