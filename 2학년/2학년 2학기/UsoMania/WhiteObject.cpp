#include "pch.h"
#include "WhiteObject.h"

WhiteObject::WhiteObject()
{
	whiteBrush = CreateSolidBrush(RGB(255, 255, 255));
}

WhiteObject::~WhiteObject()
{
}

void WhiteObject::Init()
{
}

void WhiteObject::Update()
{
}

void WhiteObject::Render(HDC _hdc)
{
	oldBrush = (HBRUSH)SelectObject(_hdc, whiteBrush);

	RECT_RENDER(_hdc, GetPos().x, GetPos().y, GetSize().x, GetSize().y);

	SelectObject(_hdc, oldBrush);
}
