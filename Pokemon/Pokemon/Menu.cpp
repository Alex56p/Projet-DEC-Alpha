#include "Menu.h"
#include <iostream>
using namespace std;
Menu::Menu(float width, float height)
{

	sf::Image img;

	//menu[0].setPosition(sf::Vector2f(width / 2, height / (MAX_NUMBER_OF_ITEMS + 1) * 1));
	img.loadFromFile("..\\Images\\Connexion_Button.png");
	bouttons[0].setAll(img, img, img, 600 / 2, 600 / (MAX_NUMBER_OF_ITEMS + 1) * 1);

	//menu[1].setPosition(sf::Vector2f(width / 2, height / (MAX_NUMBER_OF_ITEMS + 1) * 2));
	img.loadFromFile("..\\Images\\CreerCompte_Button.png");
	bouttons[1].setAll(img, img, img, 600 / 2, 600 / (MAX_NUMBER_OF_ITEMS + 1) * 2);

	//menu[2].setPosition(sf::Vector2f(width / 2, height / (MAX_NUMBER_OF_ITEMS + 1) * 3));
	img.loadFromFile("..\\Images\\Quitter_Button.png");
	bouttons[2].setAll(img, img, img, 600 / 2, 600 / (MAX_NUMBER_OF_ITEMS + 1) * 3);


	selectedItemIndex = 0;
}

Menu::~Menu()
{

}

void Menu::draw(sf::RenderWindow &window)
{
	for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
	{
		sf::Texture texture;
		texture.loadFromImage(bouttons[i].Button_Image);
		sf::Sprite sprite;
		sprite.setTexture(texture, true);
		sprite.setPosition(sf::Vector2f(bouttons[i].Width, bouttons[i].Height));
		window.draw(sprite);
	}
}

void Menu::MoveUp()
{
	if (selectedItemIndex - 1 >= 0)
	{
		menu[selectedItemIndex].setColor(sf::Color::White);
		selectedItemIndex--;
		menu[selectedItemIndex].setColor(sf::Color::Red);
	}
}

void Menu::MoveDown()
{
	if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
	{
		menu[selectedItemIndex].setColor(sf::Color::White);
		selectedItemIndex++;
		menu[selectedItemIndex].setColor(sf::Color::Red);
	}
}