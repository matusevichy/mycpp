#include <iostream>
using namespace std;


//-= Дружественные функции и классы =-
/*
	friend - получение доступа к private/protected полям
*/

class Point {
private:
	int x;
	int y;
public:
	Point() : x(0), y(0) {}
	Point(int x, int y) : x(x), y(y) {}

	void setX(int x) {
		this->x = x;
	}
	int getX() {
		return x;
	}

	void setY(int y) {
		this->y = y;
	}
	int getY() {
		return y;
	}

	//дружественная функция
	friend void movement(Point&, int, int);
	//перегрузка оператора вывода
	friend ostream& operator <<(ostream& os, const Point& p);
	//перегрузка оператора ввода
	friend istream& operator >>(istream& is, Point& p);
};

ostream& operator <<(ostream& os, const Point& p) {
	os << "x: " << p.x << " y: " << p.y;
	return os;
}

istream& operator >>(istream& is, Point& p) {
	is >> p.x;
	is >> p.y;
	return is;
}

void movement(Point& point, int x = 0, int y = 0) {
	point.x += x;
	point.y += y;
}


int main() {

	Point point(10, 5);

	movement(point, 1);

	/*cout << "x: " << point.getX() << endl;
	cout << "y: " << point.getY() << endl;*/

	cout << point << endl;

	Point p2;

	cin >> p2;
	cout << p2 << endl;


	return 0;
}