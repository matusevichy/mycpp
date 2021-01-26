#include "App.h"

bool App::deleteDir(char pathFrom[])
{
	bool doDelete = false;
	_finddata_t* findResultFrom = new _finddata_t;
	char pathFind[_MAX_PATH], newPathFrom[_MAX_PATH];
	strcpy_s(pathFind, pathFrom);
	strcat_s(pathFind, "\\*.*");
	long findList = _findfirst(pathFind, findResultFrom);
	int isExist = findList;
	while (isExist != -1)
	{
		strcpy_s(newPathFrom, pathFrom);
		if (strcmp(findResultFrom->name, ".") != 0 && strcmp(findResultFrom->name, "..") != 0)
		{
			strcat_s(newPathFrom, "\\");
			strcat_s(newPathFrom, findResultFrom->name);
			if (findResultFrom->attrib & _A_SUBDIR)
			{
				if (!deleteDir(newPathFrom))
				{
					return false;
				}
			}
			else
			{
				if (!deleteForAll && (findResultFrom->attrib & _A_RDONLY))
				{
					switch (deleteMenu(newPathFrom))
					{
					case CANCEL:
						return false;
					case DELETE:
						doDelete = true;
						break;
					case SKIP:
						break;
					case DELETEFORALL:
						deleteForAll = true;
					default:
						break;
					}
				}
				if (!(findResultFrom->attrib & _A_RDONLY) || doDelete || deleteForAll)
				{
					_chmod(newPathFrom, _S_IWRITE);
					remove(newPathFrom);
				}
			}
		}
		isExist = _findnext(findList, findResultFrom);
	}
	_findclose(findList);
	_rmdir(pathFrom);
	return true;
}

int App::deleteMenu(char fileName[])
{
	int act;
	do
	{
		cout << "File " << fileName << " is Read-Only. Do you want to do?\n";
		cout << "0 - Cancel;\n";
		cout << "1 - Delete;\n";
		cout << "2 - Skip;\n";
		cout << "3 - Delete all next file.\n";
		cin >> act;
	} while (act < 0 || act>3);
	return act;
}