#pragma once
#include<iostream>
template <typename T>
struct Node
{
	T value;
	Node* next;
	Node* prev;

	Node();
};

template <typename T>
Node<T>::Node()
{
	value = NULL;
	next = prev = nullptr;
}
