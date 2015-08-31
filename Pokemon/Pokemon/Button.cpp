#include "Button.h"

Button::Button()
{

}

Button::Button(sf::Image Image, sf::Image Over, sf::Image Pressed, float width, float height)
{
	setImage(Image);
	setOver(Over);
	setPressed(Pressed);
	setPosition(width, height);
}

void Button::setAll(sf::Image Image, sf::Image Over, sf::Image Pressed, float width, float height)
{
	setImage(Image);
	setOver(Over);
	setPressed(Pressed);
	setPosition(width, height);
}

void Button::setImage(sf::Image Image)
{
	Button_Image = Image;
}

void Button::setOver(sf::Image Over)
{
	Button_Over = Over;
}

void Button::setPressed(sf::Image Pressed)
{
	Button_Pressed = Pressed;
}

void Button::setPosition(float width, float height)
{
	Height = height;
	Width = width;
}

void Button::Draw(sf::RenderWindow &window)
{
	sf::Texture texture;
	texture.loadFromImage(Current_Button);
	sf::Sprite sprite;
	sprite.setTexture(texture, true);
	window.draw(sprite);
}

void Button::ChangeButtonImage(int index)
{
	if (index == 1)
	{
		Current_Button = Button_Image;
	}
	else if (index == 2)
	{
		Current_Button = Button_Over;
	}
	else if (index == 3)
	{
		Current_Button = Button_Pressed;
	}
	else
	{
		Current_Button = Button_Image;
	}
}