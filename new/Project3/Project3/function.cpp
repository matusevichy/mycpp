#include<iostream>
using namespace std;
//��������  ���������  ���  ��������  �  �������  ����  ����������  �  ������������  ����������.����� - ���: ������ AT � 0, ATX � 1; ����� �� ����� � 0, ����� � 1 � ��� �����.

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