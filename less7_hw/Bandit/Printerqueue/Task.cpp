#include "Task.h"

Task::Task()
{
	strcpy_s(this->texttask,"");
}

Task::Task(Client& obj, char* text)
{
	cl = obj;
	strcpy_s(texttask, text);
}

Client& Task::getClient()
{
	return cl;
}

void Task::Show()
{
	cl.Show();
	cout << "Task: " << texttask << endl;
}

int Task::getPriority()
{
	return cl.getPrioirity();
}
