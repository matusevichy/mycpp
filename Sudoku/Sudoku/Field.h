#pragma once
#include<iostream>
using namespace std;

class Field
{
	int size;
	int** field;
	int currentCellNum;
public:
	Field();
	Field(int);
	void loadField(string);
	bool checkRow(int, int);
	bool checkCol(int, int);
	bool checkRect(int, int, int);
	void exportField();
	bool setCell(int, int);
	void print();
	void printBorder();
	void getNextCell(int&, int&);
	~Field();
};

