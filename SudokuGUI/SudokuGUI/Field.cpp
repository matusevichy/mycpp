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
	field = new Cell* [size];
	for (int i = 0; i < size; i++)
	{
		field[i] = new Cell[size];
		for (int j = 0; j < size; j++)
		{
			field[i][j].setPosition(j * CELL_SIZE.y + 2 * j, i * CELL_SIZE.x + 2 * i+30);
		}
	}
	currentCellNum = 0;
}

void Field::loadField(string fileName)
{
	size = 0;
	field = nullptr;
	currentCellNum = 0;
	ifstream file(fileName, ios::binary);
	int size;
	file >> size;
	if (ceil(sqrt(size) == sqrt(size)))
	{
		this->size = size;
		field = new Cell * [size];
		for (int i = 0; i < size; i++)
		{
			string tmpStr;
			field[i] = new Cell[size];
			for (int j = 0; j < size; j++)
			{
				field[i][j].setPosition(j * CELL_SIZE.y + 2 * j, i * CELL_SIZE.x + 2 * i + 30);
				file >> tmpStr;
				if (tmpStr != '*')
				{
					field[i][j].setValue(atoi(tmpStr.c_str()));
				}
			}
		}
	}
	else
	{
		throw "Incorrect file format";
	}
}

bool Field::checkRow(int num, int value)
{
	for (int i = 0; i < size; i++)
	{
		if (field[num][i].getValue() == value)
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
		if (field[i][num].getValue() == value)
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
	for (int i = numRowRect * countRect + 0; i < numRowRect * countRect + countRect; i++)
	{
		for (int j = numColRect * countRect + 0; j < numColRect * countRect + countRect; j++)
		{
			if (field[i][j].getValue() == value)
			{
				return true;
			}
		}
	}
	return false;
}

bool Field::setCell(int row, int col)
{
	if (size==0)
	{
		throw "Sudoku not loaded!";
	}
	currentCellNum++;
	int nextRow = row, nextCol = col;
	if (!field[row][col].getValue())
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
				field[row][col].setValue(i);
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
						field[row][col].setValue(NULL);
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
	else if (row==size-1 && col==size-1)
	{
		return true;
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

void Field::print(RenderWindow& window)
{
	system("cls");
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			field[i][j].show(window);
		}
		cout << endl;
	}
	cout << endl;
}

void Field::getNextCell(int& row, int& col)
{
	if (row < size - 1)
	{
		row++;
	}
	else if (row == size - 1 && col < size - 1)
	{
		row = 0;
		col++;
	}

}

Field::~Field()
{
	for (int i = 0; i < size; i++)
	{
		delete[] field[i];
	}
	delete[] field;
}
