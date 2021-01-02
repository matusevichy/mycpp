#include "card.h"

Card::Card()
{
	index = 0; 
	suit = 0;
	score = 0;
	isused = false;
}

Card::Card(int index, int suit, int score)
{
	this->index = index;
	this->suit = suit;
	this->score = score;
	isused = false;
}

void Card::Set(int index, int suit, int score)
{
	this->index = index;
	this->suit = suit;
	this->score = score;
	isused = false;
}

void Card::Show()
{
	switch (this->index)
	{
	case Ace:
	{
		wcout << "A";
		break;
	}
	case Jack:
	{
		wcout << "J";
		break;
	}
	case Queen:
	{
		wcout << "Q";
		break;
	}
	case King:
	{
		wcout << "K";
		break;
	}
	default:
	{
		wcout << this->index;
		break;
	}
	}
	switch (this->suit)
	{
	case diamonds:
	{
		wcout << L"\u2666" << endl;
		break;
	}
	case hearts:
	{
		wcout << L"\u2665" << endl;
		break;
	}
	case clubs:
	{
		wcout << L"\u2663" << endl;
		break;
	}
	case spades:
	{
		wcout << L"\u2660" << endl;
		break;
	}
	default:
		break;
	}
}

