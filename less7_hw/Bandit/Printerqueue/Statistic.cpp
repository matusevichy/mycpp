#include "Statistic.h"

Statistic::Statistic()
{
}

Statistic::Statistic(Client& obj)
{
	cl = obj;
	time_t tmp=time(NULL);
	localtime_s(&runtime, &tmp);
}

void Statistic::Show()
{
	char tmp[40];
	cl.Show();
	asctime_s(tmp,sizeof(tmp),&runtime);
	cout << tmp << endl;
}
