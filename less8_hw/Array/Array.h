#pragma once
#include<iostream>
using namespace std;

template <class T>
class Array
{
	T* arr;
	int size;
	int grow;
	int maxindex;
public:
	Array();
	Array(Array&);
	~Array();
	int GetSize();
	void SetSize(int, int);
	int GetUpperBound();
	bool IsEmpty();
	void FreeExtra();
	void RemoveAll();
	T GetAt(int);
	bool SetAt(int, T);
	T* operator[](int);
	void Add(T);
	Array& Append(Array&);
	Array& operator=(Array&);
	T* GetData();
	bool InsertAt(int, T);
	void RemoveAt(int);
};

template<class T>
inline Array<T>::Array()
{
	arr = nullptr;
	size = 0;
	grow = 0;
	maxindex = -1;
}

template<class T>
inline Array<T>::Array(Array& obj)
{
	this->maxindex = obj.maxindex;
	this->size = obj.size;
	this->grow = obj.grow;
	this->arr = (T*)malloc(this->size * sizeof(T));
	for (int i = 0; i <= this->maxindex; i++)
	{
		this->arr[i] = obj.arr[i];
	}
}

template<class T>
inline Array<T>::~Array()
{
	if (arr)
	{
		delete arr;
	}
}

template<class T>
inline int Array<T>::GetSize()
{
	return size;
}

template<class T>
inline void Array<T>::SetSize(int size, int grow)
{
	if (arr == nullptr)
	{
		arr = (T*)malloc(size * sizeof(T));
	}
	else
	{
		arr = (T*)realloc(arr, size * sizeof(T));
	}
	this->size = size;
	this->grow = grow;
	if (maxindex > this->size)maxindex = size;
}

template<class T>
inline int Array<T>::GetUpperBound()
{
	return maxindex;
}

template<class T>
inline bool Array<T>::IsEmpty()
{
	return maxindex==-1;
}

template<class T>
inline void Array<T>::FreeExtra()
{
	arr = (T*)realloc(arr, maxindex * sizeof(T));
	size = maxindex;
}

template<class T>
inline void Array<T>::RemoveAll()
{
	if (arr)
	{
		delete[] arr;
		arr = nullptr;
		size = 0;
		maxindex = -1;
		grow = 0;
	}
}

template<class T>
inline T Array<T>::GetAt(int n)
{
	Array tmp = *this;
	if (tmp[n])
	{
		return *tmp[n];
	}
	else return NULL;
}

template<class T>
inline bool Array<T>::SetAt(int n, T val)
{
	if (n < size)
	{
		Array tmp = *this;
		*tmp[n] = val;
		if (tmp.maxindex < n)tmp.maxindex = n;
		*this = tmp;
		return true;
	}
	return false;
}

template<class T>
inline T* Array<T>::operator[](int n)
{
	if (n < size)
	{
		return &arr[n];
	}
	else
	{
		return nullptr;
	}
}

template<class T>
inline void Array<T>::Add(T val)
{
	if ((maxindex + 1) == size)
	{
		size += grow;
		arr = (T*)realloc(arr, size * sizeof(T));
	}
		arr[++maxindex] = val;
}

template<class T>
inline Array<T>& Array<T>::Append(Array<T>& obj)
{
	this->maxindex = this->size + obj.maxindex;
	int newsize = this->size + obj.size;
	this->arr = (T*)realloc(this->arr, newsize * sizeof(T));
	for (int i = 0; i < obj.size; i++)
	{
		this->arr[size + i] = obj.arr[i];
	}
	this->size = newsize;
	return *this;
}

template<class T>
inline Array<T>& Array<T>::operator=(Array<T>& obj)
{
	this->maxindex = obj.maxindex;
	this->size = obj.size;
	this->grow = obj.grow;
	this->arr = (T*)realloc(this->arr,this->size * sizeof(T));
	for (int i = 0; i <= this->maxindex; i++)
	{
		this->arr[i] = obj.arr[i];
	}
	return *this;
}

template<class T>
inline T* Array<T>::GetData()
{
	return arr;
}

template<class T>
inline bool Array<T>::InsertAt(int n,T val)
{
	if ((maxindex + 1) < size)
	{
		if (n>maxindex)
		{
			arr[n] = val;
			maxindex = n;
		}
		else
		{
			for (int i = size - 2; i >=n; i--)
			{
				arr[i+1] = arr[i];
			}
			arr[n] = val;
			maxindex++;
		}
		return true;
	}
	return false;
}

template<class T>
inline void Array<T>::RemoveAt(int n)
{
	if (n<size)
	{
		for (int i = n; i < maxindex; i++)
		{
			arr[n] = arr[n + 1];
		}
		maxindex--;
	}
}

