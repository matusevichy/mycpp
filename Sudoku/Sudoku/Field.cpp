#include "Field.h"

Field::Field()
{
	size = 0;
	field = nullptr;
	currentCellNum = 0;
}

Field::Field(int size)
{
	this->size = size;
	field = new int* [size];
	for (int i = 0; i < size; i++)
	{
		field[i] = new int[size];
		for (int j = 0; j < size; j++)
		{
			field[i][j] = NULL;
		}
	}
	currentCellNum = 0;
}

void Field::loadField(string filename)
{
	if (filename == "")
	{

	}
	else
	{

	}
}

bool Field::checkRow(int num, int value)
{
	for (int i = 0; i < size; i++)
	{
		if (field[num][i] == value)
		{
			return true;
		}
	}
	return false;
}

bool Field::checkCol(int num, int value)
{
	for (int i = 0; i < size; i++)
	{
		if (field[i][num] == value)
		{
			return true;
		}
	}
	return false;
}

bool Field::checkRect(int row, int col, int value)
{
	int countRect = sqrt(size);
	int numRowRect = row / countRect;
	int numColRect = col / countRect;
	for (int i = numRowRect*countRect + 0; i < numRowRect * countRect + countRect; i++)
	{
		for (int j = numColRect * countRect + 0; j < numColRect * countRect + countRect; j++)
		{
			if (field[i][j] == value)
			{
				return true;
			}
		}
	}
	return false;
}

bool Field::setCell(int row, int col)
{
	currentCellNum++;
	int nextRow=row, nextCol=col;
	if (!field[row][col])
	{
		for (int i = 1; i <= size; i++)
		{
			if (checkRow(row, i))
			{
				continue;
			}
			else if (checkCol(col, i))
			{
				continue;
			}
			else if (checkRect(row, col, i))
			{
				continue;
			}
			else
			{
				field[row][col] = i;
				if (currentCellNum < pow(size, 2))
				{
					getNextCell(nextRow, nextCol);
					if (setCell(nextRow, nextCol))
					{
						return true;
					}
					else
					{
						currentCellNum--;
						nextRow = row, nextCol = col; 
						field[row][col] = NULL;
						continue;
					}
				}
				else
				{
					return true;
				}
			}
		}
	}
	else
	{
		getNextCell(nextRow, nextCol);
		if (setCell(nextRow, nextCol))
		{
			return true;
		}
		else
		{
			currentCellNum--;
			return false;
		}

	}
//	system("pause");
	return false;
}

void Field::print()
{
	system("cls");
	printBorder();
	for (int i = 0; i < size; i++)
	{
	cout << "|";
		for (int j = 0; j < size; j++)
		{
			if (field[i][j])
			{
				if (field[i][j]<10)
				{
					cout << " " << field[i][j] << "|";
				}
				else
				{
					cout << field[i][j] << "|";
				}
			}
			else
			{
				cout << "  |";
			}
		}
		cout << endl;
		printBorder();
	}
	cout << endl;
	system("pause");
}

void Field::printBorder()
{
	cout << "|";
	for (int i = 0; i < size; i++)
	{
		cout << "--|";
	}
	cout << endl;
}

void Field::getNextCell(int& row, int& col)
{
	if (row < size - 1)
	{
		row++;
	}
	else if (row==size-1 && col<size-1)
	{
		row = 0;
		col++;
	}

}

Field::~Field()
{
	for (int i = 0; i < size; i++)
	{
		delete field[i];
	}
	delete[] field;
}
