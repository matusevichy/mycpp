#pragma once
#include<iostream>
#include <SFML/Graphics.hpp>
using namespace std;
using namespace sf;
#define FONT_FILE "ArialRegular.ttf"
#define FONT_SIZE 24
#define CELL_COLOR Color::White
#define TEXT_COLOR Color::Black
#define CELL_SIZE Vector2f(40,40)
#define TEXT_POS Vector2f(CELL_SIZE.x/2,CELL_SIZE.y/2)

class Cell
{
	Vector2f position;
	RectangleShape cellRect;
	Text cellText;
	Font font;
	int value;
public:
	Cell();
	void setPosition(int, int);
	void show(RenderWindow&);
	void setValue(int);
	const int& getValue() {	return value;}
};

