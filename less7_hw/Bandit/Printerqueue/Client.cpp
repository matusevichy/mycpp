#include "Client.h"

Client::Client()
{
	strcpy_s(name, 20, "Unknown");
	priority = 0;
}

Client::Client(const char* name, int p)
{
	strcpy_s(this->name, name);
	this->priority = p;
}

Client::Client(Client& obj)
{
	strcpy_s(this->name, obj.name);
	this->priority = obj.priority;
}

Client Client::operator=(Client& obj)
{
	strcpy_s(this->name, obj.name);
	this->priority = obj.priority;
	return *this;
}

void Client::Show()
{
	cout << "Name: " << this->name << endl;
	cout << "Priority: " << this->priority << endl;
}
