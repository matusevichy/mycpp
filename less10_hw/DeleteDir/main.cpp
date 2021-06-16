#include"App.h"

int main(int argc, char* argv[])
{
	App newApp;
	if (argc != 2)
	{
		cout << "MoveDir.exe [path]\n";
		return 0;
	}
	newApp.deleteDir(argv[1]);
}