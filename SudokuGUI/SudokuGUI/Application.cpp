#include "Application.h"
#include "tinyfiledialogs.h"

void Application::start()
{
    RenderWindow window (sf::VideoMode(1100, 1100), "Sudoku!");
    createMenu();
    Field newField;

    while (window.isOpen())
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
                window.close();
            if (Keyboard::isKeyPressed(Keyboard::F2))
            {
                char* fileName;
                char const* lFilterPatterns[1] = { "*.sud" };
                if ((fileName = tinyfd_openFileDialog("Open Sudoku file...", "", 1, lFilterPatterns, "Sudoku files", 0)) != NULL)
                {
                    try
                    {
                        newField.loadField(fileName);
                        newField.print(window);
                    }
                    catch (const char* str)
                    {
                        tinyfd_messageBox("Load error", str, "ok", "error", 1);
                    }
                } 
            }
            if (Keyboard::isKeyPressed(Keyboard::F9))
            {
                try
                {
                    if (newField.setCell(0, 0))
                    {
                        tinyfd_messageBox("Complete!", "Calculate succesfully complete!", "ok", "info", 1);
                    }
                    else
                    {
                        tinyfd_messageBox("Not complete!", "Sudoku has no solution! ", "ok", "info", 1);
                    }
                }
                catch (const char* str)
                {
                    tinyfd_messageBox("Load error", str, "ok", "error", 1);
                }
            }
            if (Keyboard::isKeyPressed(Keyboard::F11))
            {
                char* fileName;
                char const* lFilterPatterns[4] = { "*.bmp", "*.png", "*.tga", "*.jpg" };
                if ((fileName = tinyfd_saveFileDialog("Save as...", "", 4, lFilterPatterns, "*.bmp ,*.png, *.tga, *.jpg")) != NULL)
                {
                    Texture texture;
                    texture.create(window.getSize().x, window.getSize().y);
                    texture.update(window);
                    texture.copyToImage().saveToFile(fileName);
                }
            }
        }
        window.clear(WINDOW_COLOR);
        window.draw(mainMenu);
        if (newField.getSize() > 0)
        {
            newField.print(window);
        }
        window.display();
    }
}

void Application::createMenu()
{
    menuFont.loadFromFile(FONT_FILE);
    mainMenu.setFont(menuFont);
    mainMenu.setCharacterSize(FONT_SIZE);
    mainMenu.setFillColor(Color::Black);
    mainMenu.setString("F2 - Load from file | F9 - Calculate | F11 - Save to file");
}
