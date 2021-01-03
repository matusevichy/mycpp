#include <iostream>
#include "Application.h"
#include "ColorConfig.h"


int main() {
	ColorConfig::setColor(ColorConfig::White);

	Application app;
	app.start();

	return 0;
}