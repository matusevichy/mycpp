#include"Queue.h"

int main()
{
	Queue<int> q1(10);
	q1.Add(10);
	q1.Add(20);
	q1.Add(30);
	q1.Add(40);
	q1.Add(50);
	q1.Print();
	q1.Extract();
	q1.Extract();
	q1.Print();
	q1.Add(60);
	q1.Add(70);
	q1.Add(80);
	q1.Add(90);
	q1.Add(100);
	q1.Add(110);
	q1.Add(120);
	q1.Add(130);
	q1.Print();
}