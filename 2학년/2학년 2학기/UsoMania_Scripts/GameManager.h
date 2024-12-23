#pragma once
#include "pch.h"
#include "Note.h"
#include "queue"
#include "vector"
#include "map"
class GameManager
{
	DECLARE_SINGLE(GameManager);
public:
	void Init();
	void Update();
public:
	void SelectSong(wstring _key);
	wstring* GetChaebo();
	wstring GetSong();
	void AddScore(int value, float accuValue);
	int LineParse(int value);
	void Reset();
	void AddFasl(bool isFast);
	wstring GetFasl();
	wstring GetCurResult();
	JUDGEMENT_TYPE LastJudgement = JUDGEMENT_TYPE::None;
	std::map<JUDGEMENT_TYPE, int> judgeMap;
	wstring m_currentSong;
	Texture* currentBG;
private:
private:
	int score;
	float sumAccurary;
	float curAccurary;
	int count;
	int combo;
	int maxCombo;
	wstring curClass;
	int fastCnt;
	int slowCnt;
};

