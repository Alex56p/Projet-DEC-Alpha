#pragma once
#include "SFML\Graphics.hpp"
#include "Button.h"

#define MAX_NUMBER_OF_ITEMS 3

class Menu
{
public:
	Menu(float width, float height);
	~Menu();

	void draw(sf::RenderWindow &window);
	void MoveUp();
	void MoveDown();
	int GetPressedItem() { return selectedItemIndex; }

private:
	int selectedItemIndex;
	sf::Font font;
	sf::Text menu[MAX_NUMBER_OF_ITEMS];
	sf::RenderTexture menuimage[MAX_NUMBER_OF_ITEMS];
	Button bouttons[MAX_NUMBER_OF_ITEMS];
};