#include"Students.h"
#include<time.h>

int main()
{
	srand(time(0));
	Students newStudents;
	newStudents.loadData();
	newStudents.fill(10);
	newStudents.print();
	newStudents.sortByFirstName();
	cout << endl;
	newStudents.print();
	newStudents.sortByLastName();
	cout << endl;
	newStudents.print();
	newStudents.sortByCourse(3);
	cout << endl;
	newStudents.print();
}