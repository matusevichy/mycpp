#include "Cell.h"

Cell::Cell()
{
	cellRect.setSize(CELL_SIZE);
	cellRect.setFillColor(CELL_COLOR);
	cellText.setCharacterSize(FONT_SIZE);
	font.loadFromFile(FONT_FILE);
	cellText.setFont(font);
	cellText.setFillColor(TEXT_COLOR);
	value = NULL;
}

void Cell::setPosition(int x, int y)
{
	cellRect.setPosition(Vector2f(x,y));
	cellText.setPosition(cellRect.getPosition()+TEXT_POS);
}

void Cell::show(RenderWindow& window)
{
	window.draw(cellRect);
	if (value)
	{
		cellText.setCharacterSize(FONT_SIZE);
		cellText.setString(to_string(value));
		cellText.setOrigin(Vector2f(5, FONT_SIZE / 2));
		window.draw(cellText);
	}
}

void Cell::setValue(int value)
{
	this->value = value;
}
