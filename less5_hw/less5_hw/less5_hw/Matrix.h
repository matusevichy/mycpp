#pragma once
#include<iostream>
#include<Windows.h>
#include<time.h>
using namespace std;

class Matrix
{
	int** mas;
	int rowcount;
	int colcount;
public:
	Matrix();
	Matrix(int,int);
	Matrix(const Matrix&);
	Matrix Rand();
	Matrix Transpon();
	Matrix operator+(const Matrix&);
	Matrix operator*(const Matrix&);
	Matrix operator=(const Matrix&);
	int* operator[](const int index);
	friend ostream& operator<<(ostream& os, const Matrix& m);
	~Matrix();
};