#include "Complex.h"

char* Complex::Gets()
{
	char* tmp = nullptr;
	int n = 0;
	char ch;
	while ((ch = getchar()) != '\n')
	{
		tmp = (char*)realloc(tmp, n + 1);
		tmp[n] = ch;
		n++;
	}
	tmp = (char*)realloc(tmp, n + 1);
	tmp[n] = 0;
	return tmp;
}

void Complex::Set()
{
	char* str;
	cout << "Enter complex number: ";
	str = Gets();
	real = 1;
	imag = 1;
	char* chtmp = nullptr;
	int n;
	if (str[0] == '-')
	{
		real *= -1;
		str++;
	}
	if (strchr(str, '+'))
	{
		n = strlen(str) - strlen(strchr(str, '+'));
		chtmp = (char*)realloc(chtmp, n);
		strncpy_s(chtmp, n + 1, str, n);
		real *= atoi(chtmp);
		str += n;
	}
	else if (strchr(str, '-'))
	{
		n = strlen(str) - strlen(strchr(str, '-'));
		chtmp = (char*)realloc(chtmp, n);
		strncpy_s(chtmp, n + 1, str, n);
		str += n;
		real *= atoi(chtmp);
		imag *= -1;
	}
	else
	{
		cout << "Error number!";
	}
	strncpy_s(chtmp, sizeof(str) - 1, ++str, strlen(str) - 1);
	imag *= atoi(chtmp);
}

template<typename Type>
inline void Complex::Print(Type sum1, Type sum2)
{
	cout << sum1;
	if (sum2 >= 0)cout << "+";
	cout << sum2 << "i\n";
}

void Complex::operator+(const Complex& obj)
{
	Complex::Print(this->real + obj.real, this->imag + obj.imag);	
}

void Complex::operator-(const Complex& obj)
{
	Complex::Print(this->real - obj.real,this->imag - obj.imag);
}

void Complex::operator*(const Complex& obj)
{
	Complex::Print(this->real * obj.real - this->imag * obj.imag, this->imag * obj.real + this->real * obj.imag);
}

void Complex::operator/(const Complex& obj)
{
	double sum1, sum2;
	sum1 = (double)(this->real * obj.real + this->imag * obj.imag) / (obj.real * obj.real + obj.imag * obj.imag);
	sum2 = (double)(this->imag * obj.real - this->real * obj.imag) / (obj.real * obj.real + obj.imag * obj.imag);
	Complex::Print(sum1, sum2);
}
