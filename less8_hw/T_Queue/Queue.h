#pragma once
#include"Node.h"
#include<conio.h>
using namespace std;

template <class T> class Queue
{
	int maxcount;
	int currcount;
	Node<T>* first;
	Node<T>* last;
public:
	Queue();
	Queue(int);
	void Add(T);
	T Extract();
	bool isFull();
	bool isEmpty();
	void Print();
	void Wait();
	~Queue();
};

template<class T>
inline Queue<T>::Queue()
{
	maxcount = 0;
	currcount = 0;
	first = last = nullptr;
}

template<class T>
inline Queue<T>::Queue(int n)
{
	maxcount = n;
	currcount = 0;
	first = last = nullptr;
}

template<class T>
inline void Queue<T>::Add(T val)
{
	if (isFull())
	{
		cout << "Queue is full!\n";
		Wait();
	}
	else
	{
		Node<T>* node = new Node<T>;
		node->value = val;
		if (isEmpty())
		{
			first = last = node;
		}
		else
		{
			node->prev = last;
			last->next = node;
			last = node;
		}
		currcount++;
	}
}

template<class T>
inline T Queue<T>::Extract()
{
	if (isEmpty())
	{
		return 0;
	}
	else
	{
		Node<T>*& tmp = first;
		first = first->next;
	}
	currcount--;
	return T();
}

template<class T>
inline bool Queue<T>::isFull()
{
	return currcount==maxcount;
}

template<class T>
inline bool Queue<T>::isEmpty()
{
	return currcount==0;
}

template<class T>
inline void Queue<T>::Print()
{
	Node<T>* tmp = first;
	for (int i = 0; i < currcount; i++)
	{
		cout << tmp->value << " ";
		tmp = tmp->next;
	}
	cout << endl;
}

template<class T>
inline void Queue<T>::Wait()
{
	cout << "Press any key...\n";
	_getch();
}

template<class T>
inline Queue<T>::~Queue()
{
	while (!isEmpty())
	{
		Extract();
	}
}
