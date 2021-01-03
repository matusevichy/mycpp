#include <iostream>
#include <iomanip>
#include <conio.h>
#include <time.h>
using namespace std;

const int FIELD_WIDTH = 4;
const int FIELD_HEIGHT = 4;

#define ROAD_NUM 1
#define BORDER_NUM 0
#define ROAD_SYMB (char)177
#define BORDER_SYMB (char)178

//прототип класса
class Game;


class Player {
private:
	char name[30];
	int scores;
public:
	Player() {
		strcpy_s(name, "Unknown");
		scores = 0;
	}

	//дружба с классом Game
	friend class Game;
};


class Field {
	int field[FIELD_HEIGHT][FIELD_WIDTH] = {
		{1,0,0,0},
		{1,1,1,0},
		{0,0,1,1},
		{0,0,0,1}
	};
public:
	//дружба с классом Game
	friend class Game;
};

class Game {
	Field gameField;
	Player player;
public:
	void start() {
		while (true) {
			//очистка экрана
			system("cls");
			//вывод информации об игроке
			drawPlayerInfo();
			//вывод игрового поля
			drawField();
			//ожидание ввода от пользователя
			_getch();
		}
	}

	void drawField() {
		for (int i = 0; i < FIELD_HEIGHT; i++)
		{
			for (int j = 0; j < FIELD_HEIGHT; j++)
			{
				switch (gameField.field[i][j]) {
				case ROAD_NUM:
					cout << ROAD_SYMB;
					break;
				case BORDER_NUM:
					cout << BORDER_SYMB;
					break;
				}
			}
			cout << endl;
		}
	}

	void drawPlayerInfo() {
		cout << player.name << ", scores = " << player.scores << endl;
	}
};

int main() {
	srand(time(0));
	int arr[10][10];

	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			arr[i][j] = rand() % 1000;
			cout << setw(4) << arr[i][j] << " ";
		}
		cout << endl;
	}

	//new Game()->start();
	Game game;
	//game.start();

	return 0;
}