#pragma once
#include"card.h"
#include<time.h>
class Deck
{
	Card* mas;
	int size;
	int realsize;
public:
	Deck();
	Deck(int);
	Deck(const Deck&);
	Deck Generate();
	void Refresh();
	Card Rand();
	int getRealsize() { return realsize; }
	Deck operator=(Deck&);
	~Deck();
};

