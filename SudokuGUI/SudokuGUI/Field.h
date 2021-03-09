#pragma once
#include "Cell.h"
#include <fstream>

#define LEFT_TOP Vector2i(5,5)

class Field
{
	int size;
	Cell** field;
	int currentCellNum;
public:
	Field();
	Field(int);
	void loadField(string);
	bool checkRow(int, int);
	bool checkCol(int, int);
	bool checkRect(int, int, int);
	bool setCell(int, int);
	void print(RenderWindow&);
	void getNextCell(int&, int&);
	int getSize() { return size; }
	~Field();
};
