#include "pch.h"
#include "Core.h"
#include "GameManager.h"
#include "ResourceManager.h"

void GameManager::Init()
{
	score = 0;
	sumAccurary = 0.0f;
	curAccurary = 0.0f;
	count = 0;
	combo = 0;
	maxCombo = 0;
	fastCnt = 0;
	slowCnt = 0;
	judgeMap[JUDGEMENT_TYPE::PGREAT] = 0;
	judgeMap[JUDGEMENT_TYPE::GREAT] = 0;
	judgeMap[JUDGEMENT_TYPE::GOOD] = 0;
	judgeMap[JUDGEMENT_TYPE::BAD] = 0;
	judgeMap[JUDGEMENT_TYPE::MISS] = 0;
}

void GameManager::Update()
{
}

void GameManager::SelectSong(wstring _key)
{
	m_currentSong = _key;
}

wstring* GameManager::GetChaebo()
{
    return GET_SINGLE(ResourceManager)->FindChaebo(m_currentSong);
}

wstring GameManager::GetSong()
{
	return m_currentSong;
}

void GameManager::AddScore(int value, float accuValue)
{
	count++;
	score += value;
	sumAccurary += accuValue;

	if (accuValue != 0.0f)
	{
		combo++;
		if (maxCombo < combo)
			maxCombo = combo;
	}
	else
		combo = 0;

	curAccurary = sumAccurary / count;
}

int GameManager::LineParse(int value)
{
	switch (value)
	{
	case 64:
		value = 0;
		break;
	case 192:
		value = 1;
		break;
	case 320:
		value = 2;
		break;
	case 448:
		value = 3;
		break;
	}

	return value;
}

void GameManager::Reset()
{
	score = 0;
	sumAccurary = 0.0f;
	curAccurary = 0.0f;
	count = 0;
	combo = 0;
	maxCombo = 0;
	fastCnt = 0;
	slowCnt = 0;
	judgeMap[JUDGEMENT_TYPE::PGREAT] = 0;
	judgeMap[JUDGEMENT_TYPE::GREAT] = 0;
	judgeMap[JUDGEMENT_TYPE::GOOD] = 0;
	judgeMap[JUDGEMENT_TYPE::BAD] = 0;
	judgeMap[JUDGEMENT_TYPE::MISS] = 0;
}

void GameManager::AddFasl(bool isFast)
{
	if (isFast == true)
	{
		fastCnt++;
	}
	else
	{
		slowCnt++;
	}
}

wstring GameManager::GetFasl()
{
	return L"Fast : " + std::to_wstring(fastCnt) + L" / " + L"Slow : " + std::to_wstring(slowCnt);
}

wstring GameManager::GetCurResult()
{
	wstring resultText = std::to_wstring(score) + L'\n';
	resultText += std::to_wstring(curAccurary) + L'\n';
	resultText += std::to_wstring(combo) + L'\n';

	if (curAccurary >= 99.0f)
		curClass = L"SSS";
	else if (curAccurary >= 97.0f)
		curClass = L"SS";
	else if (curAccurary >= 95.0f)
		curClass = L"S";
	else if (curAccurary >= 90.0f)
		curClass = L"A";
	else if (curAccurary >= 80.0f)
		curClass = L"B";
	else if (curAccurary >= 70.0f)
		curClass = L"C";
	else if (curAccurary >= 60.0f)
		curClass = L"D";
	else
		curClass = L"F";

	resultText += curClass;

	return resultText;
}

