#include "pch.h"
#include "Line.h"
Line::Line()
{
}

Line::~Line()
{
}

void Line::Init()
{
}

void Line::Update()
{
}

void Line::Render(HDC _hdc)
{
	RECT_RENDER(_hdc, GetPos().x, GetPos().y, GetSize().x, GetSize().y);
}