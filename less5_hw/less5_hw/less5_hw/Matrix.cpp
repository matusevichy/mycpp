#include "Matrix.h"

Matrix::Matrix()
{
	mas = nullptr;
	rowcount = 0;
	colcount = 0;
}

Matrix::Matrix(int i, int j)
{
	rowcount = i;
	colcount = j;
	mas = new int*[rowcount];
	for (int i = 0; i < rowcount; i++)
	{
		mas[i] = new int[colcount];
	}
}

Matrix::Matrix(const Matrix& m)
{
	rowcount = m.rowcount;
	colcount = m.colcount;
	mas = new int* [rowcount];
	for (int i = 0; i < rowcount; i++)
	{
		mas[i] = new int[colcount];
	}
	for (int i = 0; i < rowcount; i++)
	{
		for (int j = 0; j < colcount; j++)
		{
			mas[i][j] = m.mas[i][j];
		}
	}
}

Matrix Matrix::Rand()
{
	srand(time(0));
	for (int i = 0; i < rowcount; i++)
	{
		for (int j = 0; j < colcount; j++)
		{
			mas[i][j] = rand() % 25;
		}
	}
	return *this;
}

Matrix Matrix::Transpon()
{
	Matrix tmp(this->colcount, this->rowcount);
	for (int i = 0; i < rowcount; i++)
	{
		for (int j = 0; j < colcount; j++)
		{
			tmp.mas[j][i] = this->mas[i][j];
		}
	}
	*this = tmp;
	return *this;
}

Matrix Matrix::operator+(const Matrix& m)
{
	if (this->colcount == m.colcount && this->rowcount == m.rowcount)
	{
		Matrix tmp(rowcount,colcount);
		for (int i = 0; i < this->rowcount; i++)
		{
			for (int j = 0; j < this->colcount; j++)
			{
				tmp.mas[i][j] = this->mas[i][j] + m.mas[i][j];
			}
		}
		return tmp;
	}
	else
	{
		cout << "Uncompatible matrix!";
		return Matrix();
	}
}

Matrix Matrix::operator*(const Matrix& m)
{
	int sum;
	if (this->colcount == m.rowcount)
	{
		Matrix tmp(this->rowcount, m.colcount);
		for (int i = 0; i < tmp.rowcount; i++)
		{
			for (int j = 0; j < tmp.colcount; j++)
			{
				sum = 0;
				for (int k = 0; k < m.rowcount; k++)
				{
					sum += this->mas[i][k] * m.mas[k][j];
				}
				tmp.mas[i][j] = sum;
			}
		}
		return tmp;
	}
	return Matrix();
}

Matrix Matrix::operator=(const Matrix& m)
{
	if (rowcount != m.rowcount && colcount != m.colcount)
	{
		for (int i = 0; i < rowcount; i++)
		{
			delete[] mas[i];
		}
		delete[] mas;
		rowcount = m.rowcount;
		colcount = m.colcount;
		mas = new int* [rowcount];
		for (int i = 0; i < rowcount; i++)
		{
			mas[i] = new int[colcount];
		}
	}
	for (int i = 0; i < rowcount; i++)
	{
		for (int j = 0; j < colcount; j++)
		{
			mas[i][j] = m.mas[i][j];
		}
	}
	return *this;
}

int* Matrix::operator[](const int index)
{
	return mas[index];
}

Matrix::~Matrix()
{
	for (int i = 0; i < rowcount; i++)
	{
		delete[] mas[i];
	}
	delete mas;
}

ostream& operator<<(ostream& os, const Matrix& m)
{
	for (int i = 0; i < m.rowcount; i++)
	{
		for (int j = 0; j < m.colcount; j++)
		{
			os << m.mas[i][j] << " ";
		}
		os << endl;
	}
	return os;
}
