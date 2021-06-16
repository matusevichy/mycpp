#pragma once
#include <iostream>
#include"OutOfMemoryException.h"
#include"IndexOutOfRangeException.h"
#include"SequenceDoesNotContainItemException.h"
#include"SequenceIsEmptyException.h"
#include"DataLossException.h"

template<typename T>
class Vector
{
	T* items;				//������
	int count;				//����������� ���-��
	int capacity;			//����� ������
public:
	Vector() {
		items = nullptr;
		count = capacity = 0;
	}
	Vector(int capacity) : Vector() {
		this->capacity = capacity;
		items = new T[capacity];
	}


	//���������� � �����
	void pushBack(T item);
	//���������� � ������
	void pushFront(T item);
	//��������� � �������� �������
	void pushAt(T item, int position);
	//��������� �������� �� �������� �������
	T getAt(int position);
	//�������� ��������� ��������
	void remove(T item);
	//�������� ���� �������� ���������
	void removeAll(T item);
	//�������� �� �������
	void removeAt(int position);
	//����������������� ������
	void resize(int count);
	//�������
	void clear();
	//��������� ��������������������� (���������� ������� ������ + ���-�� ���������� ��-��)
	//������������ ����� ������������������ �������� � 'count' � ����������, ������� ����������
	//� ���������� ������� 
	T* subItems(int position, int count);

	int size();
	bool isEmpty();
	bool isFull();
	bool isOutOfRange(int);


	//����������� ����������
	/*
	*	  (SequenceDoesNotContainItemException)
		- ������������������ �� �������� ��������� ��������

		  (SequenceIsEmptyException)
		- ������������������ �����

		  (IndexOutOfRangeException)
		- ������ ��� ���������

		  (OutOfMemoryException)
		- ������������ �����
		- ���������, �� ���� ����������

	*/
};

template<typename T>
inline void Vector<T>::pushBack(T item)
{
	if (isFull())
	{
		throw new OutOfMemoryException("Out of memory in pushBack()");
	}
	items[count++] = item;
}

template<typename T>
inline void Vector<T>::pushFront(T item)
{
	if (isFull())
	{
		throw new OutOfMemoryException("Out of memory in pushFront()");
	}
	for (int i = count; i >0; i--)
	{
		items[i] = items[i - 1];
	}
	items[0] = item;
	count++;
}

template<typename T>
inline void Vector<T>::pushAt(T item, int position)
{
	if (isFull())
	{
		throw new OutOfMemoryException("Out of memory in pushAt()");
	}
	if (isOutOfRange(position))
	{
		throw new IndexOutOfRangeException("Index out of range in pushAt()");
	}
	for (int i = count; i > position; i--)
	{
		items[i] = items[i - 1];
	}
	items[position] = item;
	count++;
}

template<typename T>
inline T Vector<T>::getAt(int position)
{
	if (isEmpty())
	{
		throw new SequenceIsEmptyException("Sequence is empty in getAt()");
	}
	if (isOutOfRange(position))
	{
		throw new IndexOutOfRangeException("Index out of range in getAt()");
	}
	return items[position];
}

template<typename T>
inline void Vector<T>::remove(T item)
{
	int index=-1;
	if (isEmpty())
	{
		throw new SequenceIsEmptyException("Sequence is empty in remove()");
	}
	for (int i = 0; i < count; i++)
	{
		if (items[i] == item)
		{
			index = i;
			break;
		}
	}
	if (index != -1)
	{
		for (int i = index; i < count-1; i++)
		{
			items[i] = items[i + 1];
		}
		count--;
	}
	else
	{
		throw new SequenceDoesNotContainItemException("Sequence does not contain item in remove()");
	}
}

template<typename T>
inline void Vector<T>::removeAll(T item)
{
	int counter = 0;
	if (isEmpty())
	{
		throw new SequenceIsEmptyException("Sequence is empty in removeAll()");
	}
	for (int i = 0; i < count; i++)
	{
		if (items[i] == item)
		{
			removeAt(i);
			i--;
			counter++;
		}
	}
	if (counter == 0)
	{
		throw new SequenceDoesNotContainItemException("Sequence does not contain item in removeAll()");
	}
}

template<typename T>
inline void Vector<T>::removeAt(int position)
{
	if (isEmpty())
	{
		throw new SequenceIsEmptyException("Sequence is empty in removeAt()");
	}
	if (isOutOfRange(position))
	{
		throw new IndexOutOfRangeException("Index out of range in removeAt()");
	}
	for (int i = position; i < count - 1; i++)
	{
		items[i] = items[i + 1];
	}
	count--;
}

template<typename T>
inline void Vector<T>::resize(int count)
{
	if (count < this->count)
	{
		throw new DataLossException("Data will be lost when resized");
	}
	T* tmp = new T[count];
	for (int i = 0; i < this->count; i++)
	{
		tmp[i] = items[i];
	}
	capacity = count;
	items = tmp;
}

template<typename T>
inline void Vector<T>::clear()
{
	if (isEmpty())
	{
		throw new SequenceIsEmptyException("Sequence is empty in clear()");
	}
	count = 0;
}

template<typename T>
inline T* Vector<T>::subItems(int position, int count)
{
	if (isEmpty())
	{
		throw new SequenceIsEmptyException("Sequence is empty in subItems()");
	}
	if (isOutOfRange(position))
	{
		throw new IndexOutOfRangeException("Index out of range in subItems()");
	}
	if (position+count >=size())
	{
		throw new OutOfMemoryException("Out of memory in subItems()");
	}
	T* tmp = new T[count];
	for (int i = 0; i < count; i++)
	{
		tmp[i] = items[i + position];
	}
	return tmp;
}

template<typename T>
inline int Vector<T>::size()
{
	return capacity;
}

template<typename T>
inline bool Vector<T>::isEmpty()
{
	return count == 0;
}

template<typename T>
inline bool Vector<T>::isFull()
{
	return count == capacity;
}

template<typename T>
inline bool Vector<T>::isOutOfRange(int position)
{
	return position < 0 || position >= size();
}
