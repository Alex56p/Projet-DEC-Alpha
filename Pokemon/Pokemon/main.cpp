#include <SFML/Graphics.hpp>
#include <iostream>
#include "Menu.h"

enum GAME_STATE{
	MainMenu, Options, Battle
};

GAME_STATE state = MainMenu;

int main()
{
	sf::RenderWindow window(sf::VideoMode(600, 600), "SFML works!");

	Menu menu(window.getSize().x, window.getSize().y);

	sf::Event event;

	while (window.isOpen())
	{
		while (window.pollEvent(event))
		{
			if (state == MainMenu)
			{
				switch (event.type)
				{
				case sf::Event::KeyReleased:
					switch (event.key.code)
					{
					case sf::Keyboard::Up:
						menu.MoveUp();
						break;
					case sf::Keyboard::Down:
						menu.MoveDown();
						break;
					case sf::Keyboard::Return:
						switch (menu.GetPressedItem())
						{
						case 0:
							std::cout << "Play Button has been pressed" << std::endl;
							break;
						case 1:
							std::cout << "Option Button has been pressed" << std::endl;
							break;
						case 2:
							window.close();
							break;
						}
						break;
					}
					break;
				case sf::Event::Closed:
					window.close();
					break;
				}
			}

			window.clear();

			menu.draw(window);

			window.display();
		}
	}

	return 0;
}