#include "pch.h"
#include "KeyBam.h"

KeyBam::KeyBam()
{
	blueBrush = CreateSolidBrush(RGB(220, 255, 255));
}

KeyBam::~KeyBam()
{
}

void KeyBam::Update()
{
}

void KeyBam::Render(HDC _hdc)
{
	HBRUSH oldBrush = (HBRUSH)SelectObject(_hdc, blueBrush);

	if (isPressed == true)
	{
		RECT_RENDER(_hdc, GetPos().x, GetPos().y, GetSize().x, GetSize().y);
	}

	SelectObject(_hdc, oldBrush);
}