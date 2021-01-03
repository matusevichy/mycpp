#pragma once
#include<iostream>
#include"Node.h"
using namespace std;

class List
{
	Node* first;
	Node* last;
	int count;
public:
	List();
	~List();
	void addFirst(int);
	void addLast(int);
	void insertAt(int, int);
	void removeFirst();
	void removeLast();
	void removeAt(int);
	int Find(int);
	bool isEmpty();
	void Clear();
	void Print();
};

