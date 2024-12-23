#include "Console.h"

BOOL Gotoxy(int x, int y)
{
	COORD Cur = { x, y };

	return SetConsoleCursorPosition(
		GetStdHandle(STD_OUTPUT_HANDLE), Cur);
}

COORD CursorPos()
{
	CONSOLE_SCREEN_BUFFER_INFO Buff;
	GetConsoleScreenBufferInfo(
		GetStdHandle(STD_OUTPUT_HANDLE), &Buff);
	return Buff.dwCursorPosition;
}

void SetCursorVis(bool vis, DWORD size)
{
	CONSOLE_CURSOR_INFO curinfo;
	curinfo.bVisible = vis; // TRUE : ON, FALSE : OFF
	curinfo.dwSize = size; //Ä¿¼­ ±½±â´Â 1~100
	SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE)
		, &curinfo);
}

void SetColor(int textColor, int bgColor)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),
		(bgColor << 4) | textColor);
}

int GetColor()
{
	CONSOLE_SCREEN_BUFFER_INFO info;
	GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE),
		&info);
	int color = info.wAttributes & 0xf;
	return color;
}

void LockResize()
{
	HWND console = GetConsoleWindow();
	if (console != nullptr)
	{
		LONG style = GetWindowLong(console, GWL_STYLE);
		style &= ~WS_MAXIMIZEBOX & ~WS_SIZEBOX & ~WS_CAPTION;
		SetWindowLong(console, GWL_STYLE, style);
	}
}

COORD GetConsoleResolution()
{
	CONSOLE_SCREEN_BUFFER_INFO info;
	GetConsoleScreenBufferInfo(GetStdHandle(STD_OUTPUT_HANDLE),
		&info);
	short width = info.srWindow.Right - info.srWindow.Left + 1;
	short height = info.srWindow.Bottom - info.srWindow.Top + 1;
	return COORD{ width, height };
}

void SetFontSize(UINT weight, UINT fontx, UINT fonty)
{
	CONSOLE_FONT_INFOEX font;
	font.cbSize = sizeof(font);

	HANDLE hout = GetStdHandle(STD_OUTPUT_HANDLE);

	GetCurrentConsoleFontEx(hout, false, &font);
	font.FontWeight = weight;
	font.dwFontSize.X = fontx;
	font.dwFontSize.Y = fonty;
	SetCurrentConsoleFontEx(hout, false, &font);
}