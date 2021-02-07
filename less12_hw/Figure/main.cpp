#include"Figure.h"

int main()
{
	Figure* mas[4] = { new Rectangle(2.5,3.5), new Circle(4.5), new Rtriangle(3.3, 4.6), new Trapezoid(6.6,5.2, 1.8) };
	cout << "Rectangle S=" << mas[0]->square() << endl;
	cout << "Circle S=" << mas[1]->square() << endl;
	cout << "Right triangle S=" << mas[2]->square() << endl;
	cout << "Trapezoid S=" << mas[3]->square() << endl;
}