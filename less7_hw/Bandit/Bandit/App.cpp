#include "App.h"

void App::Start()
{
    while (true)
    {
        system("cls");
        int act;
        menu();
        cin >> act;
        switch (act)
        {
        case NEW:
        {
            newgame = new Game(10, 48);
            newgame->Start();
            break;
        }
        case EXIT:
        {
            exit(0);
        }
        default:
            break;
        }
    }
}

void App::menu()
{
    cout << "1 - New game;\n";
    cout << "0 - Exit.\n";
}
