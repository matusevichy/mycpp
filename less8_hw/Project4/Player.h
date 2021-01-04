#pragma once
#include <iostream>
#include "Position.h"

class Game;
class Player
{
	char nickname[20];
	int score;
	Position position;
public:
	Player(const char* nickname) {
		strcpy_s(this->nickname, nickname);
		score = 0;
	}

	void toLeft() {
		position.x--;
	}
	void toRight() {
		position.x++;
	}
	void toUp() {
		position.y--;
	}
	void toDown() {
		position.y++;
	}

	friend class Game;
};

