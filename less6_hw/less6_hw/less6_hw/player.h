#pragma once
#include"deck.h"

class Player
{
	int score;
	Card* hand;
	int cardcount;
public:
	Player();
	Player(Player&);
	void addCard(Card);
	void showHand();
	int getScore() { return score; }
	void operator=(Player&);
	~Player();
};

