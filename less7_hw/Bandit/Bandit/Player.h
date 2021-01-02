#pragma once
class Player
{
	int score;
public:
	Player();
	void operator++();
	void operator--();
	int Get() { return score; }
};

