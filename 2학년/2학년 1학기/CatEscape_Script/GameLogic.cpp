#include<fcntl.h>
#include<io.h>
#include "Console.h"
#include "GameLogic.h"
#include "TitleScene.h"

#include "mci.h"

void Frame(int frame, PPLAYER pPlayer, long* deltaTime)
{
	clock_t oldtime, curtime;
	oldtime = clock();

	while (true)
	{
		curtime = clock();
		if (curtime - oldtime > 1000 / frame)
		{
			*deltaTime = curtime - oldtime;
			oldtime = curtime;
			break;
		}
	}
}
bool Update(char map[8][8], PPLAYER pPlayer, long* deltaTime, bool isStart)
{
	static int waitCreateArrow = 3000;
	if (isStart)
	{
		waitCreateArrow = 3000;
	}
	static std::vector<ARROW> arrowVec;
	COORD mapStart =
	{
		GetConsoleResolution().X / 2 - 8,
		GetConsoleResolution().Y / 2 - 4 
	};



	pPlayer->countMoveTime += *deltaTime;
	pPlayer->countSuperGuardCoolDown += *deltaTime;
	pPlayer->superGuardTime -= *deltaTime;
	MoveUpdate(map, pPlayer);
	//플레이어 이동 입력
	CreateArrow(map, pPlayer, arrowVec, mapStart, &waitCreateArrow, deltaTime);
	//시간에 따라 화살표 생성
	ActiveArrow(map, arrowVec, mapStart, deltaTime);
	//생성된 화살표 중 countWaitTime이 0인 화살표는 맵에 폭탄을 터트림
	DeleteArrow(map, arrowVec, mapStart, deltaTime);
	//폭탄이 터진 후 countAfterBomb이 0이되면 폭탄이 사라짐

	POS playerPos = pPlayer->position;
	bool IsSuperGuard = false;
	if (pPlayer->superGuardTime > 0)
	{
		IsSuperGuard = true;
	}
	else
	{
		IsSuperGuard = false;
	}

	if (map[playerPos.y][playerPos.x] == 2 && !IsSuperGuard)
	{
		ResetArrow(arrowVec);
		return false;
	}

	if (IsSuperGuard)
	{
		map[playerPos.y][playerPos.x] = 3;
	}
	else
	{
		map[playerPos.y][playerPos.x] = 1;
	}

	return true;
}

void Render(char map[8][8], PPLAYER pPlayer, time_t currentTime)
{
	COORD mapStart =
	{ GetConsoleResolution().X / 2 - 8,
	  GetConsoleResolution().Y / 2 - 4 };

	Gotoxy(0, 0);
	cout << "버틴 시간 : " << currentTime << " 초" << std::endl;
	if (pPlayer->countSuperGuardCoolDown > 5000)
	{
		cout << "슈퍼아머 : 사용 가능";
	}
	else
	{
		long time = 5000 - pPlayer->countSuperGuardCoolDown;
		cout << "슈퍼아머 : " << time / 1000 + 1 << "초 남음" << std::endl;
	}

	for (int y = 0; y < 8; y++)
	{
		Gotoxy(mapStart.X, mapStart.Y + y);
		for (int x = 0; x < 8; x++)
		{
			switch (map[y][x])
			{
			case 0:
				cout << "□";
				break;
			case 1:
			{
				int beforemode = _setmode(_fileno(stdout), _O_U16TEXT);
				wcout << L"ὣ ";
				int curoremode = _setmode(_fileno(stdout), beforemode);

			}
			break;
			case 2:
 				cout << "◎";
				break;
			case 3:
				cout << "♠";
			}
		}
		cout << '\n';
	}
}

void BorderRender(int mapSize)
{
	PlayBgm(TEXT("CatEscapeBGM.mp3"), 500);

	SetColor((int)COLOR::WHITE, (int)COLOR::WHITE);
	COORD mapStartpos =
	{ GetConsoleResolution().X / 2 - 8,
	  GetConsoleResolution().Y / 2 - 4 };

	int bordersize = mapSize + 2;
	COORD borderStartpos =
	{
		mapStartpos.X - 2, mapStartpos.Y - 1
	};

	for (int i = 0; i < bordersize; i++)
	{
		for (int j = 0; j < bordersize; j++)
		{
			if ((i == 0 || i == 9) || (j == 0 || j == 9))
			{
				Gotoxy(borderStartpos.X + i * 2, borderStartpos.Y + j);
				cout << "■";
			}
		}
	}
	SetColor((int)COLOR::WHITE, (int)COLOR::BLACK);
}

void MoveUpdate(char map[8][8], PPLAYER pPlayer)
{
	if (pPlayer->countMoveTime < pPlayer->waitMSForMove) return;

	if (GetAsyncKeyState(VK_UP) & 0x8000)
	{
		if (pPlayer->position.y == 0) return;
		map[pPlayer->position.y][pPlayer->position.x] = 0;
		--pPlayer->position.y;
		pPlayer->countMoveTime = 0;
	}
	if (GetAsyncKeyState(VK_DOWN) & 0x8000)
	{
		if (pPlayer->position.y == 7) return;
		map[pPlayer->position.y][pPlayer->position.x] = 0;
		++pPlayer->position.y;
		pPlayer->countMoveTime = 0;
	}
	if (GetAsyncKeyState(VK_LEFT) & 0x8000)
	{
		if (pPlayer->position.x == 0) return;
		map[pPlayer->position.y][pPlayer->position.x] = 0;
		--pPlayer->position.x;
		pPlayer->countMoveTime = 0;
	}
	if (GetAsyncKeyState(VK_RIGHT) & 0x8000)
	{
		if (pPlayer->position.x == 7) return;
		map[pPlayer->position.y][pPlayer->position.x] = 0;
		++pPlayer->position.x;
		pPlayer->countMoveTime = 0;
	}
	if (GetAsyncKeyState(VK_SPACE) & 0x8000)
	{
		if (pPlayer->countSuperGuardCoolDown < pPlayer->superGuardCoolTime) return;
		pPlayer->countSuperGuardCoolDown = 0;
		pPlayer->superGuardTime = 1000;
	}
}

void CreateArrow(char map[8][8], PPLAYER pPlayer, std::vector<ARROW>& arrowVec, COORD mapStart, int* waitCreateArrow, long* deltaTime)
{
	
	static int countWaitTime = 0;
	int createAmount = 0;

	countWaitTime += *deltaTime;

	if (countWaitTime > *waitCreateArrow)
	{
		countWaitTime -= *waitCreateArrow;
		*waitCreateArrow -= 50;
		if (*waitCreateArrow < 1000)
		{
			*waitCreateArrow = 1000;
		}

		createAmount = 10 - *waitCreateArrow / 300;
	}
	else
	{
		return;
	}

	bool isUp = true, isRight = true;

	for (int i = 0; i < createAmount; i++)
	{
		POS spawnPos = { 0, 0 };
		int dir = rand() % 4;
		switch (dir)
		{
		case 0:
		{
			spawnPos = { mapStart.X + (rand() % 8) * 2, mapStart.Y - 2 };
			Gotoxy(spawnPos.x, spawnPos.y);
			cout << "↓";
		}
		break;
		case 1:
		{
			spawnPos = { mapStart.X + (rand() % 8) * 2, mapStart.Y + 9 };
			Gotoxy(spawnPos.x, spawnPos.y);
			cout << "↑";
		}
		break;
		case 2:
		{
			spawnPos = { mapStart.X + 18, mapStart.Y + rand() % 8 };
			Gotoxy(spawnPos.x, spawnPos.y);
			cout << "←";
		}
		break;
		case 3:
		{
			spawnPos = { mapStart.X - 4, mapStart.Y + rand() % 8 };
			Gotoxy(spawnPos.x, spawnPos.y);
			cout << "→";
		}
		break;
		}

		ARROW arrow = {
			arrow.position = spawnPos,
			arrow.spawnDir = dir,
			arrow.countwaitTime = *waitCreateArrow / 2
		};

		arrowVec.push_back(arrow);
	}
}

void ActiveArrow(char map[8][8], std::vector<ARROW>& arrowVec, COORD mapStart, long* deltaTime)
{
	for (int i = 0; i < arrowVec.size(); i++)
	{
		arrowVec[i].countwaitTime -= *deltaTime;
		if (arrowVec[i].countwaitTime < 0)
		{
			switch (arrowVec[i].spawnDir)
			{
			case 0:
			case 1:
			{
				Gotoxy(arrowVec[i].position.x, arrowVec[i].position.y);
				cout << "  ";
				arrowVec[i].isBombed = true;
				for (int j = 0; j < 8; j++)
				{
					map[j][(arrowVec[i].position.x - mapStart.X) / 2] = 2;
				}
			}
			break;
			case 2:
			case 3:
			{
				Gotoxy(arrowVec[i].position.x, arrowVec[i].position.y);
				cout << "  ";
				arrowVec[i].isBombed = true;
				for (int j = 0; j < 8; j++)
				{
					map[arrowVec[i].position.y - mapStart.Y][j] = 2;
				}
			}
			break;
			}
		}
	}
}

void DeleteArrow(char map[8][8], std::vector<ARROW>& arrowVec, COORD mapStart, long* deltaTime)
{
	for (int i = 0; i < arrowVec.size(); i++)
	{
		if (arrowVec[i].isBombed == false)
		{
			return;
		}

		arrowVec[i].countAfterBombTime += *deltaTime;
		if (arrowVec[i].countAfterBombTime >= 100)
		{
			switch (arrowVec[i].spawnDir)
			{
			case 0:
			case 1:
			{
				for (int j = 0; j < 8; j++)
				{
					map[j][(arrowVec[i].position.x - mapStart.X) / 2] = 0;
				}
				arrowVec.erase(arrowVec.begin() + i);
			}
			break;
			case 2:
			case 3:
			{
				for (int j = 0; j < 8; j++)
				{
					map[arrowVec[i].position.y - mapStart.Y][j] = 0;
				}
				arrowVec.erase(arrowVec.begin() + i);
			}
			break;
			}
		}
		else
		{
			switch (arrowVec[i].spawnDir)
			{
			case 0:
			case 1:
			{
				for (int j = 0; j < 8; j++)
				{
					map[j][(arrowVec[i].position.x - mapStart.X) / 2] = 2;
				}
			}
			break;
			case 2:
			case 3:
			{
				for (int j = 0; j < 8; j++)
				{
					map[arrowVec[i].position.y - mapStart.Y][j] = 2;
				}
			}
			break;
			}
		}
	}
}

void ResetArrow(std::vector<ARROW>& arrowVec)
{
	arrowVec.clear();
}