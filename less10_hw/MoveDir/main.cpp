#include"App.h"

int main(int argc, char* argv[])
{
	App newApp;
	if (argc != 3)
	{
		cout << "MoveDir.exe [pathFrom] [pathTo]\n";
		return 0;
	}
	newApp.moveDir(argv[1], argv[2]);
}