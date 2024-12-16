#include "pch.h"
#include "Note.h"
#include "ResourceManager.h"
#include "EventManager.h"
#include "GameManager.h"
#include "SceneManager.h"
#include "GameScene.h"
#include "Enums.h"
#include "cmath"
#include <memory>

Note::Note()
{
	isHit = false;
	isEndHit = false;

	m_vSize.x = 80;
	m_vSize.y = 30;

	m_vPos.y = -150;
}

Note::~Note()
{
	pGameScene->NoteCount--;
}

void Note::Init()
{
	switch (noteInfo.Line)
	{
	case 0:
		m_vPos.x = 300;
		break;
	case 1:
		m_vPos.x = 400;
		break;
	case 2:
		m_vPos.x = 500;
		break;
	case 3:
		m_vPos.x = 600;
		break;
	}
}

void Note::Update()
{
 	int songMs = GET_SINGLE(ResourceManager)->GetTime(SOUND_CHANNEL::BGM);
	int subMs = 0;
	int longSubMs = 0;
	if (isHit == false)
	{
		subMs = noteInfo.Ms - songMs;	//곡이 진행함에 따라 점점 줄어듬
		int posY = 750 - subMs * pGameScene->userSpeed;
		m_vPos.y = posY;
	}
	else
	{
		m_vPos.y = 750;
	}

	if (isHit == false && subMs < -(int)JUDGEMENT_TYPE::BAD)//Bad판정 바깥으로 지나가면(=Miss라면)
	{
		GetInput(true);
	}

	if (noteInfo.IsLong == true)
	{
		longSubMs = noteInfo.EndMs - songMs;
		int endPosY = 750 - longSubMs * pGameScene->userSpeed;
		m_endPosy = endPosY;
	}

	if (isEndHit == false && longSubMs < -(int)JUDGEMENT_TYPE::BAD)//Bad판정 바깥으로 지나가면(=Miss라면)
	{
		GetInput(false);
	}
}

void Note::Render(HDC _hdc)
{
	if (noteInfo.IsLong == false)
	{
		if (pGameScene->isCircle == false)
			RECT_RENDER(_hdc, GetPos().x, GetPos().y, GetSize().x, GetSize().y);
		else
			ELLIPSE_RENDER(_hdc, GetPos().x, GetPos().y, 80, 80);
	}
	else
	{
		int posY = (GetPos().y + m_endPosy) / 2;
		if (pGameScene->isCircle == false)
		{
			int sizeY = GetPos().y - m_endPosy + 30;
			RECT_RENDER(_hdc, GetPos().x, posY, GetSize().x, sizeY);
		}
		else
		{
			int sizeY = GetPos().y - m_endPosy;
			RECT_RENDER(_hdc, GetPos().x, posY, GetSize().x, sizeY);
			ELLIPSE_RENDER(_hdc, GetPos().x, GetPos().y, 80, 80);
			ELLIPSE_RENDER(_hdc, GetPos().x, m_endPosy, 80, 80);
		}
	}
}

void Note::GetInput(bool isDown)
{
	if (isDown)
	{
		if (isHit == true)
			return;

		int inputTime = GET_SINGLE(ResourceManager)->GetTime(SOUND_CHANNEL::BGM);
		int subTime = inputTime - noteInfo.Ms;

		bool isFast = subTime < 0 ? true : false;

		JUDGEMENT_TYPE judgement = CalculateJudgement(subTime);

		if (judgement == JUDGEMENT_TYPE::None)
			return;

		if (judgement != JUDGEMENT_TYPE::MISS)
		{
			GET_SINGLE(ResourceManager)->Stop(SOUND_CHANNEL::EFFECT);
			GET_SINGLE(ResourceManager)->Play(L"hit", SOUND_CHANNEL::EFFECT);
		}

		if (judgement != JUDGEMENT_TYPE::PGREAT)
		{
			pGameScene->isFast = isFast;
			pGameScene->faslRenderTime = 0.75f;

			GET_SINGLE(GameManager)->AddFasl(isFast);
		}

		GET_SINGLE(GameManager)->judgeMap[judgement]++;

		float accuValue = 0;

		accuValue = CalculateAccurary(judgement);

		GET_SINGLE(GameManager)->AddScore(192 - (int)judgement, accuValue);
		GET_SINGLE(GameManager)->LastJudgement = judgement;

		

		isHit = true;
	}
	else
	{
		if (noteInfo.IsLong == false)
			return;
		if (isHit == false)
			return;
		if (isEndHit == true)
			return;

		int inputTime = GET_SINGLE(ResourceManager)->GetTime(SOUND_CHANNEL::BGM);
		int subTime = inputTime - noteInfo.EndMs;

		bool isFast = subTime < 0 ? true : false;


		JUDGEMENT_TYPE judgement = CalculateJudgement(subTime);

		if (judgement == JUDGEMENT_TYPE::None)
			judgement = JUDGEMENT_TYPE::MISS; //롱노트 보정

		if (judgement == JUDGEMENT_TYPE::GREAT)
			judgement = JUDGEMENT_TYPE::PGREAT;	//롱노트 보정

		if (judgement != JUDGEMENT_TYPE::PGREAT)
		{
			pGameScene->isFast = isFast;
			pGameScene->faslRenderTime = 0.75f;

			GET_SINGLE(GameManager)->AddFasl(isFast);
		}

		GET_SINGLE(GameManager)->judgeMap[judgement]++;

		float accuValue = 0;

		accuValue = CalculateAccurary(judgement);

		GET_SINGLE(GameManager)->AddScore(192 - (int)judgement, accuValue);
		GET_SINGLE(GameManager)->LastJudgement = judgement;
		isEndHit = true;
	}
}

void Note::SetNoteInfo(NoteInfo _noteInfo)
{
	noteInfo = _noteInfo;

	switch (noteInfo.Line)
	{
	case 0:
		m_vPos.x = 300;
		break;
	case 1:
		m_vPos.x = 400;
		break;
	case 2:
		m_vPos.x = 500;
		break;
	case 3:
		m_vPos.x = 600;
		break;
	}
}

bool Note::IsProcessed()
{
	if (noteInfo.IsLong == true)
		return isHit && isEndHit;
	else
		return isHit;
}

Vec2 Note::CalculatePosition()
{
	return Vec2();
}

JUDGEMENT_TYPE Note::CalculateJudgement(int subTime)
{
	subTime = abs(subTime);

	if (subTime <= (int)JUDGEMENT_TYPE::PGREAT)
	{
		return JUDGEMENT_TYPE::PGREAT;
	}
	else if (subTime <= (int)JUDGEMENT_TYPE::GREAT)
	{
		return JUDGEMENT_TYPE::GREAT;
	}
	else if (subTime <= (int)JUDGEMENT_TYPE::GOOD)
	{
		return JUDGEMENT_TYPE::GOOD;
	}
	else if (subTime <= (int)JUDGEMENT_TYPE::BAD)
	{
		return JUDGEMENT_TYPE::BAD;
	}
	else if (subTime <= (int)JUDGEMENT_TYPE::MISS)
	{
		return JUDGEMENT_TYPE::MISS;
	}
	else
	{
		return JUDGEMENT_TYPE::None;
	}
}

float Note::CalculateAccurary(JUDGEMENT_TYPE judgement)
{
	switch (judgement)
	{
	case JUDGEMENT_TYPE::PGREAT:
		return 100.0f;
	case JUDGEMENT_TYPE::GREAT:
		return 90.0f;
	case JUDGEMENT_TYPE::GOOD:
		return 66.6f;
	case JUDGEMENT_TYPE::BAD:
		return 33.3f;
	case JUDGEMENT_TYPE::MISS:
		return 0.0f;
	}

	return 0;
}
