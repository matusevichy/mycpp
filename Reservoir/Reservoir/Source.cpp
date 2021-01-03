#include"Base.h"

int main()
{
	Base newbase;
	newbase.Add();
	newbase.Add();
	newbase.Print();
	Reservoir obj1,obj2;
	obj1.Set();
	obj2 = obj1;
	obj2.Show();
	obj2.CompareType(newbase.Get(0));
	obj1.CompareSQ(newbase.Get(1));
	cout<<newbase.Get(0).Square();
	cout << newbase.Get(1).Volume();
	newbase.Delete();
}