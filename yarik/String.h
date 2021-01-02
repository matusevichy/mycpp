#include <iostream>
using namespace std;

class String
{
	char* mas;
	int size;
public:
	String();
	String(const int&);
	String(const char*);
	String(const String&);
	~String();
	String operator+(const String&);
	void operator=(const char*);
	void operator=(const String&);
	void print();
};

