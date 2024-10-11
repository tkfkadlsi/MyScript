#pragma once
#include <iostream>
#include <Windows.h>
using std::cout;
using std::wcout;
BOOL Gotoxy(int x, int y);
COORD CursorPos();
void SetCursorVis(bool vis, DWORD size);
void SetColor(int textColor, int bgColor);
int GetColor();
void LockResize();
COORD GetConsoleResolution();
void SetFontSize(UINT weight, UINT fontx, UINT fonty);

enum class COLOR
{
	BLACK, BLUE, GREEN, SKYBLUE, RED,
	VOILET, YELLOW, LIGHT_GRAY, GRAY, LIGHT_BLUE,
	LIGHT_GREEN, MINT, LIGHT_RED, LIGHT_VIOLET,
	LIGHT_YELLOW, WHITE, END
};