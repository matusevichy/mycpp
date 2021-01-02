#pragma once
#include<iostream>
#include<Windows.h>
using namespace std;

enum suits { diamonds, hearts, clubs, spades };
enum indexes {Jack = 11, Queen, King, Ace };

class Card
{
	int index;
	int suit;
	int score;
	bool isused;
public:
	Card();
	Card(int, int, int);
	void Set(int, int, int);
	Card Get() { return *this; }
	void Show();
	int getScore() { return score;	}
	void setUsed() { isused = true; }
	void setUnsed() { isused = false; }
	bool isUsed() { return isused; }
};

