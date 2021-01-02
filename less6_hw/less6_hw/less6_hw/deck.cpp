#include "deck.h"

Deck::Deck()
{
	size = 0;
	mas = nullptr;
}

Deck::Deck(int size)
{
	this->size = size;
	this->realsize = size;
	mas = new Card [size];
}

Deck::Deck(const Deck& obj)
{
	this->size = obj.size;
	this->realsize = obj.realsize;
	this->mas = new Card[size];
	for (int i = 0; i < this->size; i++)
	{
		this->mas[i] = obj.mas[i];
	}
}


Deck Deck::Generate()
{
	for (int i = 0; i < this->size/52; i++)
	{
		for (int j = 2; j < 15; j++)
		{
			for (int k = 0; k < 4; k++)
			{
				int num = i * 52 + (j - 2) * 4 + k;
				if (j > 10 && j < 14)
				{
					this->mas[num].Set(j, k, 10);
				}
				else if (j==14)
				{
					this->mas[num].Set(j, k, 11);
				}
				else
				{
					this->mas[num].Set(j, k, j);
				}
			}
		}
	}
	return *this;
}

void Deck::Refresh()
{
	for (int i = 0; i < this->size; i++)
	{
		this->mas[i].setUnsed();
	}
	this->realsize = this->size;
}

Card Deck::Rand()
{
	int tmp;
	while (!this->mas[(tmp=rand() % 52)].isUsed())
	{		
		this->mas[tmp].setUsed();
//		this->mas[tmp].Show();
		this->realsize--;
		return this->mas[tmp];
	}
}

Deck Deck::operator=(Deck& obj)
{
	this->size = obj.size;
	this->realsize = obj.realsize;
	this->mas = new Card[size];
	for (int i = 0; i < this->size; i++)
	{
		this->mas[i] = obj.mas[i];
	}
	return *this;
}

Deck::~Deck()
{
	delete[] mas;
}
