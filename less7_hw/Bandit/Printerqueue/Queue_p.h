#pragma once
#include"Task.h"
using namespace std;
template <class T> class Queue_p
{
	int maxcount;
	int currcount;
	T* mas;
	int* masp;
public:
	Queue_p();
	Queue_p(int);
	Queue_p(Queue_p&);
	void Add(T);
	T Extract();
	void Print();
	bool isFull();
	bool isEmpty();
	~Queue_p();
};

template<class T>
inline Queue_p<T>::Queue_p()
{
	mas = new T[10];
	masp = new int[20];
}

template<class T>
inline Queue_p<T>::Queue_p(int n)
{
	maxcount = n;
	mas = new T[maxcount];
	masp = new int[maxcount];
	currcount = 0;
}

template<class T>
inline Queue_p<T>::Queue_p(Queue_p& obj)
{
	this->maxcount = obj.maxcount;
	this->currcount = obj.currcount;
	for (int i = 0; i < this->curcount; i++)
	{
		this->mas[i] = obj.mas[i];
		this->masp[i] = obj.masp[i];
	}
}

template<class T>
Queue_p<T>::~Queue_p()
{
	delete[] mas;
	delete[] masp;
}

template<class T>
void Queue_p<T>::Add(T obj)
{
	mas[currcount] = obj;
	masp[currcount++] = obj.getPriority();
}

template<class T>
void Queue_p<T>::Print()
{
	for (int i = 0; i < currcount; i++)
	{
		cout << "Eltement [" << i << "]:\n";
		mas[i].Show();
	}
}

template<class T>
bool Queue_p<T>::isFull()
{
	return currcount == maxcount;
}

template<class T>
T Queue_p<T>::Extract()
{
	int maxi = 0;
	T tmp;
	for (int i = 1; i < currcount; i++)
	{
		if (masp[i] > masp[maxi])
		{
			maxi = i;
		}
	}
	tmp = mas[maxi];
	for (int i = maxi + 1; i < currcount; i++)
	{
		mas[i - 1] = mas[i];
		masp[i - 1] = masp[i];
	}
	currcount--;
	return tmp;
}

template<class T>
bool Queue_p<T>::isEmpty()
{
	return currcount == 0;
}
