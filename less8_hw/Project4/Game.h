#pragma once
#include <iostream>
#include <conio.h>
#include "Player.h"
#include "ColorConfig.h"
using namespace std;

#define BORDER_NUM 0
#define BORDER_SYMB (char)178

#define ROAD_NUM 1
#define ROAD_SYMB (char)176

#define ARROW_LEFT 75
#define ARROW_RIGHT 77
#define ARROW_UP 72 
#define ARROW_DOWN 80


#define PLAYER_NUM 3
#define PLAYER_SYMB (char)219

#define MONEY_NUM 5
#define MONEY_SYMB (char)156

#define EXIT_NUM 6
#define EXIT_SYMB (char)254

class Game
{
public:
	enum MoveDirection {
		Left,
		Right,
		Up,
		Down,
		None
	};
	~Game();
	Game(const char* username, int);

	void start();
private:
	ColorConfig::ConsoleColor playerColor = ColorConfig::ConsoleColor::Red;
	ColorConfig::ConsoleColor roadColor = ColorConfig::ConsoleColor::White;
	ColorConfig::ConsoleColor borderColor = ColorConfig::ConsoleColor::Green;
	ColorConfig::ConsoleColor textColor = ColorConfig::ConsoleColor::White;
	ColorConfig::ConsoleColor moneyColor = ColorConfig::ConsoleColor::Yellow;

	Player* player;
	int width;					//ширина поля
	int height;					//высота поля
	bool run = true;
	int** gameField; 	//игровое поле

	void init(int);
	bool isGameOver();
	void printTopPanel();
	void printField();
	void printSymb(int symbNum);
	MoveDirection keyUp();
	void playerMove(MoveDirection direction);

	bool canMoveToRight();
	bool canMoveToLeft();
	bool canMoveToUp();
	bool canMoveToDown();
};