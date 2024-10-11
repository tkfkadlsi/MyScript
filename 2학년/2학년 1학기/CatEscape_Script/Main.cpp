#include "Console.h"
#include "TitleScene.h"
#include "GameLogic.h"
#include "mci.h"
#include<iostream>
#include<conio.h>
#include<Windows.h>
#include<io.h>
#include<fcntl.h>
using namespace std;

int main()
{
	Init();

	long deltaTime = 0;
	char map[8][8] = { 0 };
	//std::fill(map[0][0], map[7][7], '0');
	PLAYER player =
	{
		player.position = { 4, 4 },
	};


	while (true)
	{
		while (true)
		{
			bool isGameStart = TitleScene();
			if (isGameStart) break;
			else return 0;
		}


		BorderRender(8);

		// 게임 시작 시간
		time_t startTime = time(NULL);
		time_t currentTime;
		//초기화용 Update
		Update(map, &player, &deltaTime, true);
		while (true)
		{
			if (Update(map, &player, &deltaTime) == false)
			{
				break;
			}
			currentTime = time(NULL) - startTime;
			Render(map, &player, currentTime);
			Frame(60, &player, &deltaTime);
		}
		// 게임 종료 시간
		time_t endTime = time(NULL);

		system("cls");
		// 경과 시간 계산
		double duration = difftime(endTime, startTime);

		Gotoxy(0, 0);
		int beforemode = _setmode(_fileno(stdout), _O_U16TEXT);

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

		cout << "버틴 시간: " << duration << "초" << endl;
		Sleep(3000);
		cout << "잠시 후 타이틀로 돌아갑니다.";
		Sleep(4000);

		for (int i = 0; i < 1; ++i)
		{
			Gotoxy(0, 0);
			SetColor((int)COLOR::BLACK, (int)COLOR::WHITE);
			system("cls");
			Sleep(200);

			Gotoxy(0, 0);
			SetColor((int)COLOR::WHITE, (int)COLOR::BLACK);
			system("cls");
			Sleep(200);
		}
		
		for (int y = 0; y < 8; y++)
		{
			for (int x = 0; x < 8; x++)
			{
				map[y][x] = 0;
			}
		}
	}
	return 0;
}

