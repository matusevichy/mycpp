#include "Game.h"

Game::~Game()
{
	delete player;
}

Game::Game(const char* username, int n)
{
	player = new Player(username);
	init(n);
}


void Game::start()
{
	//пока игра не закончена
	while (!isGameOver()) {
		system("cls");
		printTopPanel();
		printField();
		MoveDirection direction = keyUp();
		playerMove(direction);
	}
}

void Game::init(int n)
{
	char fn[10];
	char strtmp[7],str_h[4],str_w[4];
	char* pos;
	_itoa_s(n, fn, 2,10);
	strcat_s(fn,".txt");
	FILE* fp;
	fopen_s(&fp, fn, "r");
	if (fp)
	{
		fgets(strtmp, 10, fp);
	}
	pos = strchr(strtmp, ':');
	strncpy_s(str_h, strtmp, (strlen(strtmp) - strlen(pos)));
	strncpy_s(str_w, strlen(pos+1)+1, pos+1,strlen(pos+1));
	height = atoi(str_h);
	width = atoi(str_w);
	gameField = new int* [height];
	for (int i = 0; i < height; i++) {
		gameField[i] = new int[width];
	}
	for (int i = 0; i < height; i++)
	{
		char* fstr = new char [width];
		fgets(fstr, width+2, fp);
		for (int j = 0; j < width; j++)
		{
			gameField[i][j] = fstr[j]-48;
		}
	}
	fclose(fp);
	HWND h = GetConsoleWindow();  // дескриптор окна 
	::SendMessageA(h, WM_SETTEXT, 0, (LPARAM)"hello");  // заголовок 

	// размер
	RECT r;
	::GetWindowRect(h, &r);
	::SetWindowPos(h, HWND_TOP, 100, 100, width*10, height*20, SWP_SHOWWINDOW);

	//HWND hWindowConsole = GetConsoleWindow();
	//RECT r;
	//GetWindowRect(hWindowConsole, &r); //stores the console's current dimensions
	//MoveWindow(hWindowConsole, r.left, r.top, 400, 200, TRUE);
}

bool Game::isGameOver()
{
	return !run;
}

void Game::printTopPanel()
{
	cout << "Player: " << player->nickname << "\tScore: " << player->score << endl;
}

void Game::printField()
{
	for (int i = 0; i < height; i++)
	{
		for (int j = 0; j < width; j++)
		{
			if (j == player->position.x && i == player->position.y) {
				ColorConfig::setColor(playerColor);
				std::cout << PLAYER_SYMB;
				ColorConfig::setColor(textColor);
				if (gameField[i][j] == MONEY_NUM)
				{
					gameField[i][j] = ROAD_NUM;
					player->score += 5;
				}
				if (gameField[i][j] == EXIT_NUM)
				{
					run = false;
				}
			}
			else {
				if (gameField[i][j] == ROAD_NUM)
					ColorConfig::setColor(roadColor);
				else if (gameField[i][j] == BORDER_NUM)
					ColorConfig::setColor(borderColor);
				else if (gameField[i][j] == MONEY_NUM)
					ColorConfig::setColor(moneyColor);
				printSymb(gameField[i][j]);
			}
		}
		ColorConfig::setColor(textColor);
		std::cout << std::endl;
	}
}

void Game::printSymb(int symbNum)
{
	switch (symbNum) {
	case ROAD_NUM: std::cout << ROAD_SYMB; break;
	case BORDER_NUM: std::cout << BORDER_SYMB; break;
	case MONEY_NUM: std::cout << MONEY_SYMB; break;
	case EXIT_NUM: std::cout << EXIT_SYMB; break;
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
	default:
		direction = None;
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
	return player->position.x < width-1 &&
		gameField[player->position.y][player->position.x + 1] != BORDER_NUM;
}

bool Game::canMoveToLeft()
{
	return player->position.x > 0 && 
		gameField[player->position.y][player->position.x - 1] != BORDER_NUM;
}

bool Game::canMoveToUp()
{
	return player->position.y>0 && 
		gameField[player->position.y-1][player->position.x] != BORDER_NUM;
}

bool Game::canMoveToDown()
{
	return player->position.y < height && 
		gameField[player->position.y + 1][player->position.x] != BORDER_NUM;
}
