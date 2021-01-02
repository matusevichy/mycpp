#pragma once
#include"Task.h"
#include"Statistic.h"
template <class T> class Queue
{
	int maxcount;
	int currcount;
	T* mas;
public:
	Queue();
	Queue(int);
	Queue(Queue&);
	void Add(T&);
	T Extract();
	bool isFull();
	bool isEmpty();
	void Print();
	~Queue();
};

template<class T>
inline Queue<T>::Queue()
{
	mas = new T[10];
}

template<class T>
inline Queue<T>::Queue(int n)
{
	maxcount = n;
	mas = new T[maxcount];
	currcount = 0;
}

template<class T>
inline Queue<T>::Queue(Queue& obj)
{
	this->maxcount = obj.maxcount;
	this->currcount = obj.currcount;
	for (int i = 0; i < this->curcount; i++)
	{
		this->mas[i] = obj.mas[i];
	}
}

template<class T>
Queue<T>::~Queue()
{
	delete[] mas;
}

template<class T>
void Queue<T>::Add(T& obj)
{
	mas[currcount++] = obj;
}

template<class T>
T Queue<T>::Extract()
{
	T tmp;
	tmp = mas[0];
	for (int i = 1; i < currcount; i++)
	{
		mas[i - 1] = mas[i];
	}
	currcount--;
	return tmp;
}

template<class T>
bool Queue<T>::isFull()
{
	return currcount == maxcount;
}

template<class T>
bool Queue<T>::isEmpty()
{
	return currcount == 0;
}

template<class T>
void Queue<T>::Print()
{
	for (int i = 0; i < currcount; i++)
	{
		cout << "Eltement [" << i << "]:\n";
		mas[i].Show();
	}
}
