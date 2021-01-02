#include <iostream>
#include <Windows.h>
#include <conio.h>

using namespace std;

enum AccType {
	Admin = 1,
	User = 2,
	None = 0
};

class Car {
	char mark[30];
	char model[30];
public:
	Car() {
		strcpy_s(mark, "Unknown");
		strcpy_s(model, "Unknown");
	}
	Car(const char* mark, const char* model) {
		strcpy_s(this->mark, mark);
		strcpy_s(this->model, model);
	}

	const char* getMark() const {
		return mark;
	}
	const char* getModel() const {
		return model;
	}

	friend ostream& operator << (ostream& os, const Car& car);
};
ostream& operator << (ostream& os, const Car& car) {
	os << car.mark << " " << car.model << endl;
	return os;
}



//Singleton(Одиночка) - предоставить возможно создания объекта в единственном экземпляре
/*
	1. Приватный конструктор
	2. Статическая переменная, которая ссылается на данный класс
	3. Статический метод, который предоставляет доступ к статической переменной
*/
class CarsStorage {
	static CarsStorage* instance;

	int capacity;		//общий размер
	int count;			//фактический размер
	Car* cars;			//массив машин

	CarsStorage() {
		capacity = 10;
		count = 0;
		cars = new Car[capacity];
	}
	CarsStorage(int capacity) {
		this->capacity = capacity;
		count = 0;
		cars = new Car[capacity];
	}
public:
	
	~CarsStorage() {
		//очистка выделенной памяти под машины
		delete[] cars;
	}

	void addNewCar(const Car& car) {
		//TODO: car validation

		if (count < capacity) {
			cars[count++] = car;
		}
	}

	const Car* findByMark(char* mark) {
		for (int i = 0; i < count; i++)
		{
			//марка совпадает
			if (_strcmpi(cars[i].getMark(), mark) == 0) {
				return &cars[i];
			}
		}
		return nullptr;
	}
	const Car* getCars() const {
		return cars;
	}
	int getCountCars() const {
		return count;
	}

	static CarsStorage* getInstance() {
		if (instance == nullptr) {
			instance = new CarsStorage();
		}
		return instance;
	}
};
//ициализация статической переменной
CarsStorage* CarsStorage::instance = nullptr;

class UserApplication {
	CarsStorage* carsStorage = CarsStorage::getInstance();

	void menu() {
		cout << "[1] Показать все машины" << endl;
		cout << "[2] Поиск машины по марке" << endl;
		cout << "[3] Выход" << endl;
	}
public:
	void start() {
		int action;
		while (true) {
			system("cls");

			menu();
			cin >> action;

			if (!runAction(action)) {
				break;
			}

			Sleep(1000);
		}
	}
	bool runAction(int action) {
		switch (action) {
		case 1:
			showAllCars();
			break;
		case 2:

			break;
		case 3:
			return false;
			break;
		}
		return true;
	}
	void showAllCars() {
		cout << "Список всех машин" << endl;

		const Car* cars = carsStorage->getCars();
		int countCars = carsStorage->getCountCars();

		if (countCars > 0) {
			for (int i = 0; i < countCars; i++)
			{
				cout << cars[i] << endl;
			}
		}
		else {
			cout << "Список машин пуст" << endl;
		}
	}
};

class AdminApplication {
	CarsStorage* carsStorage = CarsStorage::getInstance();

	void menu() {
		cout << "[1] Добавить новую машину" << endl;
		cout << "[2] Редактирование машины" << endl;
		cout << "[3] Удаление машины" << endl;
		cout << "[4] Выход" << endl;
	}
	void addNewCar() {
		cin.ignore();
		cout << "Добавление новой машины" << endl;

		char mark[30];
		char model[30];

		//ввод данных с клавиатуры
		cout << "Mark: ";
		cin.getline(mark, 30);

		cout << "Model: ";
		cin.getline(model, 30);

		Car newCar(mark, model);

		//добавление машины в хранилище
		carsStorage->addNewCar(newCar);
	}
	bool runAction(int action) {
		switch (action) {
		case 1:
			addNewCar();
			break;
		case 2:

			break;
		case 3:

			break;
		case 4:
			return false;
			break;
		}
		return true;
	}
public:
	void start() {
		int action;
		while (true) {
			system("cls");

			menu();
			cin >> action;
			if (!runAction(action)) {
				break;
			}

			Sleep(1000);
		}
	}
	
};

class Application {
	enum MenuAction {
		Login = 1,
		Exit = 2
	};
private:
	void menu() {
		cout << "[1] Вход" << endl;
		cout << "[2] Выход" << endl;
	}
	void runAction(int menuAction) {
		switch (menuAction) {
		case Login: {
			//вход
			AccType type = login();

			switch (type) {
			case Admin: {
				AdminApplication adminApp;
				adminApp.start();
				break;
			}
			case User: {
				UserApplication userApp;
				userApp.start();
				break;
			}
			}
			break;
		}
		case Exit:
			exit(0);
			break;
		}
	}

	
	
	//void editCar() {

	//}
	//void removeCar() {

	//}
	//void findByMark() {
	//	cout << "Поиск машины по марке" << endl;
	//	//марка авто для поиска
	//	char srchMark[] = "mark 1";

	//	//найденная машина
	//	const Car* srchCar = carsStorage.findByMark(srchMark);

	//	//машина найдена
	//	if (srchCar != nullptr) {
	//		cout << *srchCar << endl;
	//	}
	//	else {
	//		cout << "Машина не найдена" << endl;
	//	}
	//}

	AccType login() {

		int type;

		cout << "[1] Admin" << endl;
		cout << "[2] User" << endl;
		cin >> type;

		return type == Admin ? Admin : User;
	}
public:
	Application() {

	}
	void start() {
		int action;
		while (true) {
			system("cls");

			//отображение главного меню
			menu();
			//ввод действия в меню
			cin >> action;
			runAction(action);

			Sleep(2500);
		}
	}
};

enum Color {
	Red = 1,
	Blue = 2,
	Green = 3
};

int main() {
	//доп. настройка приложения
	system("color 0F");
	setlocale(LC_ALL, "rus");


	Application app;
	app.start();


	return 0;
}