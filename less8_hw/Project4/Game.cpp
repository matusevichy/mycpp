#include "Game.h"

Game::~Game()
{
	delete player;
}

Game::Game(const char* username, int n)
{
	player = new Player(username);
	/*this->width = width;
	this->height = height;*/
	init();
}


void Game::start()
{
	//пока игра не закончена
	while (!isGameOver()) {
		system("cls");
		printField();
		MoveDirection direction = keyUp();
		playerMove(direction);
	}
}

void Game::init()
{
	File* fp;
	/*gameField = new int* [height];
	for (int i = 0; i < height; i++) {
		gameField[i] = new int[width];
	}*/
}

bool Game::isGameOver()
{
	return false;
}

void Game::printField()
{
	for (int i = 0; i < FIELD_HEIGTH; i++)
	{
		for (int j = 0; j < FIELD_WIDTH; j++)
		{
			if (j == player->position.x && i == player->position.y) {
				ColorConfig::setColor(playerColor);
				std::cout << PLAYER_SYMB;
			}
			else {
				if (gameField[i][j] == ROAD_NUM)
					ColorConfig::setColor(roadColor);
				else if (gameField[i][j] == BORDER_NUM)
					ColorConfig::setColor(borderColor);
				printSymb(gameField[i][j]);
			}
		}
		std::cout << std::endl;
	}
}

void Game::printSymb(int symbNum)
{
	switch (symbNum) {
	case ROAD_NUM: std::cout << ROAD_SYMB; break;
	case BORDER_NUM: std::cout << BORDER_SYMB; break;
		//case PLAYER_NUM: std::cout << PLAYER_SYMB; break;
	}
}

Game::MoveDirection Game::keyUp()
{
	_getch();
	MoveDirection direction;
	int key = _getch();

	switch (key)
	{
	case ARROW_LEFT:
		direction = Left;
		break;
	case ARROW_RIGHT:
		direction = Right;
		break;
	case ARROW_UP:
		direction = Up;
		break;
	case ARROW_DOWN:
		direction = Down;
		break;
	}

	return direction;
}
void Game::playerMove(MoveDirection direction)
{
	switch (direction)
	{
	case Game::Left:
		if (canMoveToLeft())
		{
			player->toLeft();
		}
		break;
	case Game::Right:
		if (canMoveToRight())
		{
			player->toRight();
		}
		break;
	case Game::Up:
		if (canMoveToUp())
		{
			player->toUp();
		}
		break;
	case Game::Down:
		if (canMoveToDown())
		{
			player->toDown();
		}
		break;
	}
}

bool Game::canMoveToRight()
{
	return player->position.x < FIELD_WIDTH &&
		gameField[player->position.y][player->position.x + 1] == ROAD_NUM;
}

bool Game::canMoveToLeft()
{
	return player->position.x > 0 && gameField[player->position.y][player->position.x - 1] == ROAD_NUM;
}

bool Game::canMoveToUp()
{
	return player->position.y>0&& gameField[player->position.y-1][player->position.x]==ROAD_NUM;
}

bool Game::canMoveToDown()
{
	return player->position.y < FIELD_HEIGTH && gameField[player->position.y + 1][player->position.x] == ROAD_NUM;
}
