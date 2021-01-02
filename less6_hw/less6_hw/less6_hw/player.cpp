#include "player.h"

Player::Player()
{
	score = 0;
	hand = nullptr;
	cardcount = 0;
}

Player::Player(Player& obj)
{
	this->score = obj.score;
	this->cardcount = obj.cardcount;
	for (int i = 0; i < this->cardcount; i++)
	{
		this->hand[i] = obj.hand[i];
	}
}

void Player::addCard(Card card)
{
	if (this->hand == nullptr)
	{
		hand = (Card*)malloc(sizeof(Card));
	}
	else
	{
		hand = (Card*)realloc(hand, (this->cardcount + 1) * sizeof(Card));
	}
	hand[cardcount++] = card;
	score += card.getScore();
}

void Player::showHand()
{
	for (int i = 0; i < this->cardcount; i++)
	{
		this->hand[i].Show();
	}
}

void Player::operator=(Player& obj)
{
	this->score = obj.score;
	this->cardcount = obj.cardcount;
	for (int i = 0; i < this->cardcount; i++)
	{
		this->hand[i] = obj.hand[i];
	}
}

Player::~Player()
{
	delete[] hand;
}
