#pragma once
#include <vector>
typedef struct _tagpos
{
	int x;
	int y;
	bool operator == (const _tagpos& other)
	{
		if (x == other.x && y == other.y) return true;
		else return false;
	}
}POS, *PPOS;

typedef struct _tagplayer
{
	POS position;
	//countMoveTime이 이 숫자보다 크면 이동 가능.
	long waitMSForMove = 100;

	//update에서 매번 deltatime만큼 증가시켜줌
	long countMoveTime = 0;

	//superGuardTime이 0초과시 무적상태, update에서 매번 감소시켜줌.
	long superGuardTime = 0;

	//쿨타임을 가지고 있는 변수
	long superGuardCoolTime = 5000;

	//countSuperGuardCoolDown이 위 변수보다 크면 무적 사용가능, update에서 매번 증가시켜줌.
	long countSuperGuardCoolDown = 5000;
}PLAYER, *PPLAYER;

typedef struct _tagarrow
{
	POS position; //화살표의 위치
	int spawnDir; //화살표의 방향
	long countwaitTime; //터지기까지의 시간
	bool isBombed = false; //터졌는지 아닌지
	long countAfterBombTime; //터진게 사라지기까지의 시간

	bool operator==(_tagarrow other) // == 연산자
	{
		return
			position == other.position &&
			spawnDir == other.spawnDir &&
			countwaitTime == other.countwaitTime &&
			isBombed == other.isBombed &&
			countAfterBombTime == countAfterBombTime;
	}
}ARROW, *PARROW;

void Frame(int frame, PPLAYER pPlayer, long* deltaTime);
bool Update(char map[8][8], PPLAYER pPlayer, long* deltaTime, bool isStart = false);
void Render(char map[8][8], PPLAYER pPlayer, time_t currentTime);
void BorderRender(int mapSize);
void MoveUpdate(char map[8][8], PPLAYER pPlayer);
void CreateArrow(char map[8][8], PPLAYER pPlayer, std::vector<ARROW>& arrowVec, COORD mapStart, int* waitCreateArrow, long* deltaTime);
void ActiveArrow(char map[8][8], std::vector<ARROW>& arrowVec, COORD mapStart, long* deltaTime);
void DeleteArrow(char map[8][8], std::vector<ARROW>& arrowVec, COORD mapStart, long* deltaTime);
void ResetArrow(std::vector<ARROW>& arrowVec);