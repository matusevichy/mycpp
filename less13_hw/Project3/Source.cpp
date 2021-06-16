#include <iostream>
#include"Vector.h"
using namespace std;

int main() {
	Vector<int> v(0);
	Vector<int> v1(2);
	try
	{
		v.pushBack(5);
	}
	catch (const OutOfMemoryException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v.pushFront(5);
	}
	catch (const OutOfMemoryException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v.pushAt(5, 1);
	}
	catch (const OutOfMemoryException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const IndexOutOfRangeException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v1.pushAt(5, 0);
		v1.pushAt(5, 2);
	}
	catch (const OutOfMemoryException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const IndexOutOfRangeException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v.getAt(0);
	}
	catch (const IndexOutOfRangeException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}
	try
	{
		v1.getAt(2);
	}
	catch (const IndexOutOfRangeException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v1.remove(6);
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const SequenceDoesNotContainItemException* ex)
	{
		cout << ex->what() << endl;
	}

	Vector<int> v3(3);
	v3.pushBack(5);
	v3.pushBack(5);

	try
	{
		v3.removeAll(6);
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const SequenceDoesNotContainItemException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v3.removeAt(4);
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const IndexOutOfRangeException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v3.resize(1);
	}
	catch (const DataLossException* ex)
	{
		cout << ex->what() << endl;
	}

	try
	{
		v.clear();
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}
	int* tmp;
	try
	{
		tmp=v1.subItems(1, 1);
	}
	catch (const SequenceIsEmptyException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const IndexOutOfRangeException* ex)
	{
		cout << ex->what() << endl;
	}
	catch (const OutOfMemoryException* ex)
	{
		cout << ex->what() << endl;
	}
}