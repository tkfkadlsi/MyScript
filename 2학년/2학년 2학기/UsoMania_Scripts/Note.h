#pragma once
#include "Object.h"
#include "Vec2.h"
#include "NoteInfo.h"

class GameScene;
class Texture;
class Note : public Object
{
public:
	Note();
	~Note();
public:
	GameScene* pGameScene;
public:
	void Init() override;
	void Update() override;
	void Render(HDC _hdc) override;
	void GetInput(bool isDown);
	void SetNoteInfo(NoteInfo _noteInfo);
	bool IsProcessed();
private:
	Vec2 CalculatePosition();
	JUDGEMENT_TYPE CalculateJudgement(int subTime);
	float CalculateAccurary(JUDGEMENT_TYPE judgement);
private:
	NoteInfo noteInfo;
	bool isHit;
	bool isEndHit;

	float m_endPosy = -150;

	const int judgeLine = 800;

	int longSizeY = 0;
};

