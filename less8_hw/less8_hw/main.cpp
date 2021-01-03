#include"list.h"

int main()
{
	List newlist;
	newlist.addFirst(10);
	newlist.addFirst(30);
	newlist.addFirst(50);
	newlist.addFirst(70);
	newlist.addLast(9);
	newlist.addLast(8);
	newlist.addLast(7);
	newlist.addLast(6);
	newlist.Print();
	cout << "The index of the element with value " << 50 << " is " << newlist.Find(50) << endl;
	newlist.insertAt(2, 40);
	newlist.Print();
	newlist.removeFirst();
	newlist.removeLast();
	newlist.removeAt(2);
	newlist.Print();
	newlist.Clear();
	newlist.Print();
}