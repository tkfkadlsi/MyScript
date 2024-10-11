#include <iostream>
#include<conio.h>
#include<io.h>
#include<fcntl.h>
#include<windows.h>

#include "TitleScene.h"
#include "Console.h"
#include "mci.h"

using namespace std;

void TitleRender()
{
	Gotoxy(0, 0);
	int beforemode = _setmode(_fileno(stdout), _O_U16TEXT);

	SetColor((int)COLOR::GRAY, (int)COLOR::BLACK);
	wcout << "                                                                              " << endl;
	wcout << L"  ██████╗ █████╗ ████████╗    ███████╗███████╗ ██████╗ █████╗ ██████╗ ███████╗" << endl;
	wcout << L" ██╔════╝██╔══██╗╚══██╔══╝    ██╔════╝██╔════╝██╔════╝██╔══██╗██╔══██╗██╔════╝" << endl;
	SetColor((int)COLOR::WHITE, (int)COLOR::BLACK);
	wcout << L" ██║     ███████║   ██║       █████╗  ███████╗██║     ███████║██████╔╝█████╗  " << endl;
	wcout << L" ██║     ██╔══██║   ██║       ██╔══╝  ╚════██║██║     ██╔══██║██╔═══╝ ██╔══╝  " << endl;
	wcout << L" ╚██████╗██║  ██║   ██║       ███████╗███████║╚██████╗██║  ██║██║     ███████ " << endl;
	wcout << L" ╚═════╝╚═╝  ╚═╝   ╚═╝       ╚══════╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝     ╚══════╝ " << endl;
	
	wcout << endl;
	SetColor((int)COLOR::LIGHT_YELLOW, (int)COLOR::BLACK);

	wcout << L"         ↓                  ↓" << endl;
	wcout << L"             __                ↓" << endl;
	wcout << L"    ↓     ,db'    ↓     ↓" << endl;
	wcout << L"         ,d8/       ↓             ↓" << endl;
	wcout << L"         888" << endl;
	wcout << L"         `db\\             ↓" << endl;
	wcout << L"           `o`_                    ↓ ↓" << endl;
	wcout << L"      ↓                      _          ↓" << endl;
	wcout << L"            ↓                 / )" << endl;

	wcout << L"         ↓   (\\__/)↓        ( (  ↓" << endl;
	wcout << L"       ,-.,-.,)    (.,-.,-.,-.) ).,-.,-." << endl;
	wcout << L"      | @|  ={      }= | @|  / / | @|o |" << endl;
	wcout << L"     _j__j__j_)     `-------/ /__j__j__j_" << endl;
	wcout << L"     ________(               /___________" << endl;
	wcout << L"      |  | @| \\              || o|O | @|" << endl;
	wcout << L"      |o |  |,'\\       ,   ,\"|  |  |  |  hjw" << endl;
	wcout << L"     vV\\|/vV|`-\\  ,---\\   | \\Vv\\hjwVv\\//v" << endl;
	wcout << L"                _) )    `. \\/" << endl;
	wcout << L"               (__/       ) )" << endl;
	wcout << L"                         (_/" << endl;

	SetColor((int)COLOR::WHITE, (int)COLOR::BLACK);
	int curoremode = _setmode(_fileno(stdout), beforemode);
}

void InfoRender()
{
	COORD Resolution = GetConsoleResolution(); // 콘솔 해상도를 가져옵니다

	system("cls");

	int boxWidth = 50;
	int boxHeight = 9;
	int boxX = (Resolution.X - boxWidth) / 2;
	int boxY = (Resolution.Y - boxHeight) / 2;

	// 상단 네모 출력
	Gotoxy(boxX, boxY);
	cout << "┌";
	for (int i = 0; i < boxWidth - 2; ++i)
		cout << "─";
	cout << "┐";

	// 중간 부분 출력
	for (int i = 1; i < boxHeight - 1; ++i)
	{
		Gotoxy(boxX, boxY + i);
		cout << "│";
		for (int j = 0; j < boxWidth - 2; ++j)
			cout << " ";
		cout << "│";
	}

	// 하단 네모 출력
	Gotoxy(boxX, boxY + boxHeight - 1);
	cout << "└";
	for (int i = 0; i < boxWidth - 2; ++i)
		cout << "─";
	cout << "┘";

	// 텍스트 출력
	Gotoxy(boxX + 2, boxY + 1);
	cout << "조  작  법  : ←↑→↓ 방향키" << endl;
	Gotoxy(boxX + 2, boxY + 3);
	cout << "게 임 설 명 : 화살표가 가리킨 줄을 피하고" << endl;
	Gotoxy(boxX + 2, boxY + 5);
	cout << "	       최대한 오래 살아 남으세요!" << endl;
	Gotoxy(boxX + 2, boxY + 7);
	cout << "제      작  : 20306 김예성, 20312 이예빈" << endl;


	Sleep(100);
	while (true)
	{
		if (KeyController() == KEY::SPACE)
		{
			system("cls");
			Sleep(100);
			TitleRender();
			break;
		}
	}
}

void EnterAnimation()
{
	Gotoxy(0, 0);
	COORD xy = GetConsoleResolution();          

	int x = xy.X;
	int y = xy.Y;

	SetColor((int)COLOR::WHITE, (int)COLOR::WHITE);

	for (int i = 0; i < y; i++)
	{
		for (int j = 0; j < x; j++)
		{
			cout << "■";
		}
		cout << '\n';
		Sleep(10);
	}

	// 5번 깜빡거리기.
	for (int i = 0; i < 1; ++i)
	{
		Gotoxy(0, 0);
		SetColor((int)COLOR::BLACK, (int)COLOR::WHITE);
		system("cls");
		Sleep(20);

		Gotoxy(0, 0);
		SetColor((int)COLOR::WHITE, (int)COLOR::BLACK);
		system("cls");
		Sleep(20);
	}


	// 크로스.
	SetColor((int)COLOR::BLACK, (int)COLOR::WHITE);
	for (int i = 0; i < x / 2; ++i)
	{
		for (int j = 0; j < y; j += 2)
		{
			Gotoxy(i * 2, j);
			SetColor((int)COLOR::LIGHT_YELLOW, (int)COLOR::BLACK);
			//cout << "  ";
			cout << "■";
		}
		for (int j = 1; j < y; j += 2)
		{
			Gotoxy(x - 2 - i * 2, j);
			SetColor((int)COLOR::GRAY, (int)COLOR::BLACK);
			//cout << "  ";
			cout << "■";
		}
		Sleep(30);
	}
	SetColor((int)COLOR::WHITE, (int)COLOR::BLACK);
	system("cls");
}

MENU MenuRender()
{
    COORD Resolution = GetConsoleResolution(); // 해상도 출력
    int x = Resolution.X / 4.5;
    int y = Resolution.Y / 4;
    int originy = y;

    Gotoxy(x - 2, y); // 화살표 처음 위치에 출력
    cout << ">";
    Gotoxy(x, y);
    cout << "게임 시작";
    Gotoxy(x, y + 1);
    cout << "게임 정보";
    Gotoxy(x, y + 2);
    cout << "게임 종료";

    while (true)
    {
        // 키 입력이 된 것을 받아옴
        KEY ekey = KeyController();

        switch (ekey)
        {
            // 화살표 출력
            // 화살표 지우기
        case KEY::UP:
        {
            if (y > originy)
            {
                Gotoxy(x - 2, y);
                cout << " ";
                Gotoxy(x - 2, --y);
                cout << ">";
                Sleep(100);
            }
        }
        break;
        case KEY::DOWN:
        {
            if (y < originy + 2)
            {
                Gotoxy(x - 2, y);
                cout << " ";
                Gotoxy(x - 2, ++y);
                cout << ">";
                Sleep(100);
            }
        }
        break;
        case KEY::SPACE:
        {
            if (originy == y)
                return MENU::START;

            else if (originy + 1 == y)
                return MENU::INFO;

            else if (originy + 2 == y)
                return MENU::QUIT;
        }
        break;
        }
    }

    return MENU::INFO;
}


KEY KeyController()
{
	if (GetAsyncKeyState(VK_UP) & 0x8000)
	{
		return KEY::UP;
	}
	if (GetAsyncKeyState(VK_DOWN) & 0x8000)
	{
		return KEY::DOWN;
	}
	if (GetAsyncKeyState(VK_SPACE) & 0x8000)
	{
		return KEY::SPACE;
	}

	return KEY::FALE;
}


void Init()
{
	srand((unsigned int)time(nullptr));
	SetCursorVis(false, 40);
		
	system("title cppteamproject | mode con cols=80 lines=30");

		
	PlayBgm(TEXT("TitleBGM.mp3"), 500);
}

bool TitleScene()
{
	TitleRender();
	while (true)
	{
		MENU eMenu = MenuRender();

		switch (eMenu)
		{
		case MENU::START:
			EnterAnimation();
			return true;
		case MENU::INFO:
			InfoRender();
			break;
		case MENU::QUIT:
			system("cls");
			return false;
			break;
		}
	}
}
