#pragma once
#include "SFML\Graphics.hpp"

class Button
{
private:
	sf::Image Button_Over;
	sf::Image Button_Pressed;
	

public:
	float Width;
	float Height;

	sf::Image Current_Button;
	sf::Image Button_Image;


	Button();
	Button(sf::Image Image, sf::Image Over, sf::Image Pressed, float width, float height);
	
	

	void Draw(sf::RenderWindow &window);
	void ChangeButtonImage(int index = 1);
	void setImage(sf::Image Image);
	void setOver(sf::Image Over);
	void setPressed(sf::Image Pressed);
	void setPosition(float width, float height);
	void setAll(sf::Image Image, sf::Image Over, sf::Image Pressed, float width, float height);
};