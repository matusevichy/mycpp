#include "Area.h"
#define F_MAXAGE 10
#define R_MAXAGE 4
#define H_MAXAGE 2
Area::Area(int maxEntity)
{
	this->year = 0;
	this->maxEntity = maxEntity;
	this->countFox = rand()%this->maxEntity+1;
	this->countHerb = rand() % this->maxEntity+1;
	this->countRabbit = rand() % this->maxEntity+1;
	foxes = new Fox[maxEntity];
	rabbits = new Rabbit[maxEntity];
	herbs = new Herb[maxEntity];
	for (int i = 0; i < countFox; i++)
	{
		foxes[i] = Fox(F_MAXAGE);
	}
	for (int i = 0; i < countRabbit; i++)
	{
		rabbits[i] = Rabbit(R_MAXAGE);
	}
	for (int i = 0; i < countHerb; i++)
	{
		herbs[i] = Herb(H_MAXAGE);
	}
}

bool Area::addYear()
{
	cout << "Year " << year << endl;
	cout << "State of area on start year\n";
	print();
	int tmp;
	if (countFox>1&&countFox<5)
	{
		tmp = countFox;
		for (int i = tmp; i < tmp+foxes[0].getIncrement()&&countFox<maxEntity; i++)
		{
			foxes[i] = Fox(F_MAXAGE);
			countFox++;
		}
	}
	else if(!countFox)
	{
		cout << "All the foxes are dead\n";
		return false;
	}
	if (countRabbit>1)
	{
		tmp = countRabbit;
		for (int i = tmp; i < tmp + rabbits[0].getIncrement() && countRabbit < maxEntity; i++)
		{
			rabbits[i] = Rabbit(R_MAXAGE);
			countRabbit++;
		}
	}
	else
	{
		cout << "All the rabbits are dead\n";
		return false;
	}
	if (countHerb>1)
	{
		tmp = countHerb;
		for (int i = tmp; i < tmp + herbs[0].getIncrement() && countHerb < maxEntity; i++)
		{
			herbs[i] = Herb(H_MAXAGE);
			countHerb++;
		}
	}
	setAge(foxes, countFox);
	setAge(rabbits, countRabbit);
	setAge(herbs, countHerb);
	if (countFox>countRabbit)
	{
		countRabbit--;
	}
	if (countRabbit > countHerb)
	{
		countHerb = 0;
	}

	cout << endl << "State of area on end year\n";
	print();
	system("pause");
	this->year++;
	return true;
}

void Area::setAge(Life* mas, int& count)
{
	int tmp = count;
	for (int i = 0; i < tmp; i++)
	{
		if (!mas[i].setAge())
		{
			del(mas, count, i);
		}
	}
}

void Area::del(Life* mas,int& count, int index)
{
	for (int i = index; i < count-1; i++)
	{
		mas[i] = mas[i + 1];
	}
	count--;
}

void Area::print()
{
	cout << "Count of foxes in the area: " << this->countFox << endl;
	cout << "Count of rabbits in the area: " << countRabbit << endl;
	cout << "Count of herbs in the area: " << countHerb << endl;
}

Area::~Area()
{
	delete[] foxes;
	delete[] rabbits;
	delete[] herbs;
}

