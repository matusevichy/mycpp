#include "Time.h"


char* Time::Gets()
{
	char* tmp=nullptr;
	char ch;
	int n = 0;
	tmp = (char*)malloc(n + 1);
	while ((ch = getchar()) != '\n')
	{
		tmp=(char*)realloc(tmp, n + 1);
		tmp[n] = ch;
		n++;
	}
	tmp=(char*)realloc(tmp, n + 1);
	tmp[n] = 0;
	return tmp;
}

Time::Time()
{
	hour = 0;
	minets = 0;
	ext = 0;
}

void Time::setTime()
{	
	char* str;
	bool flag = false;
	char h[3], m[3];
	char ext[3];
	char* tmp;
	Time time;
	while (!flag)
	{
		cout << "Enter time: ";
		str = Gets();
		if ((tmp = strchr(str, ':')) != 0)
		{
			strncpy_s(h, str, tmp - str);
			time.hour = atoi(h);
			str = tmp + 1;
			if ((tmp = strpbrk(str, "ap")) != nullptr)
			{
				strncpy_s(m, str, tmp - str);
				if (strcmp(tmp, "am") == 0)
				{
					time.ext = am;
				}
				else if (strcmp(tmp, "pm") == 0)
				{
					time.ext = pm;
				}
			}
			else
			{
				strncpy_s(m, str, strlen(str));
				time.ext = 0;
			}
			time.minets = atoi(m);
			if (!(flag = check(time)))
			{
				cout << "Time is uncorrect!";
				Sleep (1000);
				system("cls");
			}
			else
			{
				*this = time;
			}
		}
	}
}

bool Time::check(const Time& t)
{
	if (t.minets < 0 || t.minets >= 60) return false;
	if (t.ext == 0 && t.hour >= 0 && t.hour < 24) return true;
	if ((t.ext == t.am || t.ext == t.pm) && t.hour > 0 && t.hour <= 12) return true;
	return false;
}

Time Time::convert()
{
	Time tmp;
	tmp.minets = this->minets;
	if (this->ext == 0)
	{
		if (this->hour >= 0 && this->hour < 12)
		{
			tmp.hour = this->hour;
			tmp.ext = tmp.am;
			return tmp;
		}
		else if (this->hour == 12)
		{
			tmp.hour = this->hour;
			tmp.ext = tmp.pm;
			return tmp;
		}
		else
		{
			tmp.hour = this->hour - 12;
			tmp.ext = tmp.pm;
			return tmp;
		}
	}
	else
	{
		tmp.ext = 0;
		tmp.hour = this->hour;
		if (this->ext == this->pm && this->hour != 12)
		{
			tmp.hour += 12;
			return tmp;
		}
		else if(this->ext == this->am && this->hour==12)
		{
			tmp.hour -= 12;
			return tmp;
		}
	}
	return tmp;
}

Time Time::operator+(Time t)
{
	Time tmp;
	if ((tmp.minets = this->minets + t.minets) >= 60)
	{
		tmp.hour++;
		tmp.minets -= 60;
	}
	if (this->ext != t.ext)
	{
		t = t.convert();
	}
		if (this->ext == 0)
		{
			if ((tmp.hour += this->hour + t.hour) > 23)
			{
				tmp.hour -= 24;
			}
		}
		else
		{
			Time tmp1, tmp2;
			tmp1 = this->convert();
			tmp2 = t.convert();
			tmp = tmp1 + tmp2;
			return tmp.convert();
		}
	return tmp;
}

Time Time::operator-(Time t)
{
	Time tmp;
	if ((tmp.minets = this->minets - t.minets) < 0)
	{
		tmp.hour--;
		tmp.minets += 60;
	}
	if (this->ext != t.ext)
	{
		t = t.convert();
	}
	if (this->ext == 0)
	{
		if ((tmp.hour += this->hour - t.hour) < 0)
		{
			tmp.hour += 24;
		}
	}
	else
	{
		Time tmp1, tmp2;
		tmp1 = this->convert();
		tmp2 = t.convert();
		tmp = tmp1 - tmp2;
		return tmp.convert();
	}
	return tmp;
}

void Time::compare(Time t)
{
	Time tmp1,tmp2;
	if (this->ext != 0)
	{
		tmp1 = this->convert();
	}
	else
	{
		tmp1 = *this;
	}
	if (t.ext != 0)
	{
		tmp2 = t.convert();
	}
	else
	{
		tmp2 = t;
	}
	if (tmp1.hour > tmp2.hour)
	{
		cout << *this << " > " << t << endl;
	}
	else if (tmp2.hour > tmp1.hour)
	{
		cout << t << " > " << *this << endl;
	}
	else
	{
		if (tmp1.minets > tmp2.minets)
		{
			cout << *this << " > " << t << endl;
		}
		else if (tmp2.minets > tmp1.minets)
		{
			cout << t << " > " << *this << endl;
		}
		else
		{
			cout << *this << " = " << t << endl;
		}

	}
}

ostream& operator<<(ostream& os, const Time& t)
{
	if (t.hour < 10)
	{
		os << 0 << t.hour<< ':';
	}
	else
	{
		os << t.hour<< ':';
	}
	if (t.minets < 10)
	{
		os << 0 << t.minets;
	}
	else
	{
		os << t.minets;
	}
	if (t.ext == t.am)
	{
		os << "am";
	}
	else if (t.ext == t.pm)
	{
		os << "pm";
	}
	return os;
}


