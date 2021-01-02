#include<iostream>
using namespace std;
//Ќаписать  программу  дл€  хранени€  в  битовом  поле  информации  о  конфигурации  компьютера.Ќапри - мер:  орпус AT Ч 0, ATX Ч 1; ¬идео на борту Ч 0, карта Ч 1 и так далее.

enum Cases
{
	AT,
	ATX,
};

enum Core
{

};

struct Config
{
	unsigned Case : 1;
	unsigned Core : 2;
	unsigned Video : 2;
	unsigned Memory : 2;
};

int main()
{
	Config mas[1];
	unsigned tmp;
	cout << "Enter 4 element of computer configuration:\n";
	cout << "Case (AT or ATX)";
	cin >> tmp;
	mas[0].Case = tmp;
	cout << mas[0].Case;
}