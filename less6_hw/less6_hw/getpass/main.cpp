#include"Getpass.h"

int main()
{
	Getpass gp;
	cout << gp.getPass("C", "Program Files","Adobe","bin","adobe.exe",0);
	return 0;
}