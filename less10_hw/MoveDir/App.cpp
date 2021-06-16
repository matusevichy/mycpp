#include "App.h"

bool App::moveDir(char pathFrom[], char pathTo[])
{
	bool doRewrite = false, doDelete = false;
	_finddata_t* findResultFrom = new _finddata_t, * findResultTo = new _finddata_t;
	char pathFind[_MAX_PATH], newPathFrom[_MAX_PATH], newPathTo[_MAX_PATH];
	strcpy_s(pathFind, pathFrom);
	_mkdir(pathTo);
	strcat_s(pathFind, "\\*.*");
	long findListFrom = _findfirst(pathFind, findResultFrom), findListTo;
	int isExist = findListFrom;
	while (isExist != -1)
	{
		strcpy_s(newPathFrom, pathFrom);
		strcpy_s(newPathTo, pathTo);
		if (strcmp(findResultFrom->name, ".") != 0 && strcmp(findResultFrom->name, "..") != 0)
		{
			strcat_s(newPathFrom, "\\");
			strcat_s(newPathFrom, findResultFrom->name);
			strcat_s(newPathTo, "\\");
			strcat_s(newPathTo, findResultFrom->name);
			if (findResultFrom->attrib & _A_SUBDIR)
			{
				if (!moveDir(newPathFrom, newPathTo))
				{
					return false;
				}
			}
			else
			{
				findListTo = _findfirst(newPathTo, findResultTo);
				if (!rewriteForAll && findListTo != -1)
				{
					switch (rewriteMenu(newPathTo))
					{
					case CANCEL:
						return false;
					case REWRITE:
						doRewrite = true;
						break;
					case SKIP:
						break;
					case REWRITEFORALL:
						rewriteForAll = true;
					default:
						break;
					}
				}
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
				if (findListTo == -1 || (findListTo != -1 && (doRewrite || rewriteForAll)))
				{
					if (!(findResultFrom->attrib & _A_RDONLY) || doDelete || deleteForAll)
					{
						_chmod(newPathFrom, _S_IWRITE);
						remove(newPathTo);
						rename(newPathFrom, newPathTo);
					}
					else
					{
						copyFile(newPathFrom, newPathTo);
					}
				}
				_findclose(findListTo);
			}
		}
		isExist = _findnext(findListFrom, findResultFrom);		
	}
	_findclose(findListFrom);
	_rmdir(pathFrom);
	return true;
}

void App::copyFile(char output[], char input[])
{
	FILE* inputFile, * outputFile;
	fopen_s(&outputFile, output, "r");
	fopen_s(&inputFile, input, "w");
	char buffer[255];
	if (outputFile && inputFile)
	{
		while (!feof(outputFile))
		{
			fgets(buffer, 255, outputFile);
			fputs(buffer, inputFile);
		}
	}
}

int App::rewriteMenu(char fileName[])
{
	int act;
	do
	{
		cout << "File " << fileName << " is exist. Do you want to do?\n";
		cout << "0 - Cancel;\n";
		cout << "1 - Rewrite;\n";
		cout << "2 - Skip;\n";
		cout << "3 - Rewrite all next file.\n";
		cin >> act;
	} while (act < 0 || act>3);
	return act;
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
