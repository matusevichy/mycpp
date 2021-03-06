#include "Base.h"

int main()
{
	Base newbase;
	newbase.Add("1","1 1",1.1);
	newbase.Add("8", "8 1", 81.1);
	newbase.Add("9", "9 1", 91.1);
	newbase.Add("7", "7 1", 71.1);
	newbase.Add("4", "4 1", 41.1);
	newbase.Add("8", "8 2", 82.1);
	newbase.Add("8", "8 3", 83.1);
	newbase.Add("5", "5 1", 51.1);
	newbase.Add("2", "2 1", 21.1);
	newbase.Add("3", "3 1", 31.1);
	newbase.Add("6", "6 1", 61.1);
	newbase.Add("0", "0 1", 0.1);
	cout << "Origin:\n" << endl;
	newbase.Print(newbase.getRoot());
	cout << "Auto with number 8:\n" << endl;
	newbase.Print("8");
	cout << "Auto with number between 2 and 7:\n" << endl;
	newbase.Print("2","7", newbase.getRoot());
	newbase.Delete("4");
	cout << "After delete 4:\n";
	newbase.Print(newbase.getRoot());
	newbase.DeleteAll(newbase.Find("5", newbase.getRoot()));
	cout << "After delete from 5:\n";
	newbase.Print(newbase.getRoot());
	newbase.DeleteAll(newbase.getRoot());
	cout << "After delete All:\n";
	newbase.Print(newbase.getRoot());
}