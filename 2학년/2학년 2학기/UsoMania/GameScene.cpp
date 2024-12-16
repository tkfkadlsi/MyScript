#include "pch.h"
#include "GameScene.h"
#include "GameManager.h"
#include "ResourceManager.h"
#include "InputManager.h"
#include "SceneManager.h"
#include "EventManager.h"
#include "TimeManager.h"
#include "Note.h"
#include "Line.h"
#include "WhiteObject.h"
#include "Background.h"
#include "Core.h"
#include "KeyBam.h"
#include <atomic>
#include <string>
#include <chrono>
#include <functional>
#include <thread>
#include <algorithm>
void GameScene::Init()
{
	//GET_SINGLE(ResourceManager)->TextureLoad();
	wstring chaeboTxt = GET_SINGLE(GameManager)->GetChaebo()->c_str();

	vector<wstring> notes = GET_SINGLE(Core)->SplitString(chaeboTxt, L"\n");

	NoteCount = 0;

	for (int i = 0; i < notes.size(); i++)
	{
		vector<wstring> note = GET_SINGLE(Core)->SplitString(notes[i], L",");

		NoteInfo noteInfo;
		noteInfo.IsLong = false;

		noteInfo.Line = GET_SINGLE(GameManager)->LineParse(std::stoi(note[0]));
		noteInfo.Ms = std::stoi(note[2]);

		if (std::stoi(note[3]) == 128)
		{
			noteInfo.IsLong = true;

			vector<wstring> timings = GET_SINGLE(Core)->SplitString(note[5], L":");
			noteInfo.EndMs = std::stoi(timings[0]);
		}

		Note* newNote = new Note;
		newNote->pGameScene = this;
		newNote->SetNoteInfo(noteInfo);
		NoteCount++;

		GetNoteVectors[noteInfo.Line].push_back(newNote);
	}

	WhiteObject* wo = new WhiteObject;
	wo->SetPos({ 450, SCREEN_HEIGHT / 2 });
	wo->SetSize({ 400, SCREEN_HEIGHT });
	AddObject(wo, LAYER::BACKGEAR);

	for (int i = 0; i < 5; i++)
	{
		Line* newLine = new Line;
		newLine->SetPos({ 250 + (i * 100), 0 });
		newLine->SetSize({ 1, 2000 });
		AddObject(newLine, LAYER::GEAR);
	}

	Line* judgeLIne = new Line;
	judgeLIne->SetPos({ 450, 760 });
	judgeLIne->SetSize({ 400, 20 });
	AddObject(judgeLIne, LAYER::GEAR);

	for (int i = 0; i < 4; i++)
	{
		KeyBam* newKeyBam = new KeyBam;
		newKeyBam->SetPos({ 300 + (i * 100), 375 });
		newKeyBam->SetSize({ 100, 750 });
		KeyBams.push_back(newKeyBam);
		AddObject(newKeyBam, LAYER::KEYBAM);
	}

	Background* bg = new Background;
	bg->SetBG(GET_SINGLE(GameManager)->currentBG);
	AddObject(bg, LAYER::BACKGROUND);

	//Line* gear = new Line;
	//gear->SetPos({ 450, 1000 });
	//gear->SetSize({ 400, 400 });
	//AddObject(gear, LAYER::GEAR);

	GET_SINGLE(ResourceManager)->Play(GET_SINGLE(GameManager)->m_currentSong, SOUND_CHANNEL::BGM);
	GET_SINGLE(ResourceManager)->Volume(SOUND_CHANNEL::BGM, 0.2f);
	GET_SINGLE(ResourceManager)->Volume(SOUND_CHANNEL::EFFECT, 0.1f);
}

void GameScene::Update()
{
	//if(isPlayingSong == false && playSongTimer < 0.0f)
	//{
	//	isPlayingSong = true;
	//	PlaySong();
	//}
	//else if(playSongTimer > 0.0f)
	//{
	//	playSongTimer -= GET_SINGLE(TimeManager)->GetDT();
	//}

	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::D) == KEY_STATE::DOWN)
	{
		KeyBams[0]->isPressed = true;
		if (GetNoteVectors[0].empty() == false)
			GetPeekNote(0)->GetInput(true);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::D) == KEY_STATE::UP)
	{
		KeyBams[0]->isPressed = false;
		if (GetNoteVectors[0].empty() == false)
			GetPeekNote(0)->GetInput(false);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::F) == KEY_STATE::DOWN)
	{
		KeyBams[1]->isPressed = true;
		if (GetNoteVectors[1].empty() == false)
			GetPeekNote(1)->GetInput(true);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::F) == KEY_STATE::UP)
	{
		KeyBams[1]->isPressed = false;
		if (GetNoteVectors[1].empty() == false)
			GetPeekNote(1)->GetInput(false);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::J) == KEY_STATE::DOWN)
	{
		KeyBams[2]->isPressed = true;
		if (GetNoteVectors[2].empty() == false)
			GetPeekNote(2)->GetInput(true);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::J) == KEY_STATE::UP)
	{
		KeyBams[2]->isPressed = false;
		if (GetNoteVectors[2].empty() == false)
			GetPeekNote(2)->GetInput(false);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::K) == KEY_STATE::DOWN)
	{
		KeyBams[3]->isPressed = true;
		if (GetNoteVectors[3].empty() == false)
			GetPeekNote(3)->GetInput(true);
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::K) == KEY_STATE::UP)
	{
		KeyBams[3]->isPressed = false;
		if (GetNoteVectors[3].empty() == false)
			GetPeekNote(3)->GetInput(false);
	}


	for (int i = 0; i < GetNoteVectors.size(); i++)
	{
		auto& notes = GetNoteVectors[i];

		size_t cnt = min(notes.size(), static_cast<size_t>(10));


		int index = 0;
		for (int i = 0; i < cnt; i++)
		{
			auto it = notes.begin() + index;

			if ((*it)->IsProcessed())
			{
				NoteCount--;
				DeleteObject(*it);
				notes.erase(it);
			}
			else
			{
				(*it)->Update();
				index++;
			}
		}
	}


	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::ESC) == KEY_STATE::DOWN)
	{
		for (int i = 0; i < 4; i++)
		{
			while (GetNoteVectors[i].empty() == false)
			{
				Note* note = GetNoteVectors[i][0];
				GetNoteVectors[i].erase(GetNoteVectors[i].begin(), GetNoteVectors[i].begin() + 1);
				GET_SINGLE(EventManager)->DeleteObject(note);
			}
		}
		faslRenderTime = 0.0f;
		NoteCount = 0;
		KeyBams.clear();

		GET_SINGLE(GameManager)->Reset();
		GET_SINGLE(ResourceManager)->Stop(SOUND_CHANNEL::BGM);
		GET_SINGLE(SceneManager)->LoadScene(L"TitleScene");
	}

	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::UP) == KEY_STATE::DOWN)
	{
		userSpeed += 0.1f;
		if (userSpeed > 3.0f)
			userSpeed = 3.0f;
	}
	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::DOWN) == KEY_STATE::DOWN)
	{
		userSpeed -= 0.1f;
		if (userSpeed < 0.2f)
			userSpeed = 0.2f;
	}

	if (GET_SINGLE(InputManager)->GetKey(KEY_TYPE::M) == KEY_STATE::DOWN)
	{
		isCircle = !isCircle;
	}

	if (faslRenderTime > 0.0f)
		faslRenderTime -= GET_SINGLE(TimeManager)->GetDT();

	Scene::Update();
}

void GameScene::Render(HDC _hdc)
{
	SIZE textSize;

	Scene::Render(_hdc);

	for (int i = 0; i < GetNoteVectors.size(); i++)
	{
		auto& notes = GetNoteVectors[i];

		size_t cnt = min(notes.size(), static_cast<size_t>(10));

		for (size_t i = 0; i < cnt; i++)
		{
			auto it = notes.begin() + i;

			if((*it)->IsProcessed() == false)
				(*it)->Render(_hdc);
		}
	}

	wstring result = GET_SINGLE(GameManager)->GetCurResult();
	JUDGEMENT_TYPE renderJudgeType = GET_SINGLE(GameManager)->LastJudgement;
	wstring judgestr = L"";

	switch (renderJudgeType)
	{
	case JUDGEMENT_TYPE::PGREAT:
		judgestr = L"PGREAT";
		break;
	case JUDGEMENT_TYPE::GREAT:
		judgestr = L"GREAT";
		break;
	case JUDGEMENT_TYPE::GOOD:
		judgestr = L"GOOD";
		break;
	case JUDGEMENT_TYPE::BAD:
		judgestr = L"BAD";
		break;
	case JUDGEMENT_TYPE::MISS:
		judgestr = L"MISS";
		break;
	case JUDGEMENT_TYPE::None:
		judgestr = L"";
	}

	std::vector<wstring> results = GET_SINGLE(Core)->SplitString(result, L"\n");

	results[0] += L"점";
	results[1] += L"%";

	SelectObject(_hdc, GET_SINGLE(Core)->ClassFont);
	SetTextColor(_hdc, RGB(255, 255, 255));

	GetTextExtentPoint32(_hdc, results[3].c_str(), results[3].length(), &textSize);
	TextOut(_hdc, 1200 - (textSize.cx / 2), 400 - (textSize.cy / 2), results[3].c_str(), results[3].length());

	SelectObject(_hdc, GET_SINGLE(Core)->ScoreFont);

	GetTextExtentPoint32(_hdc, results[0].c_str(), results[0].length(), &textSize);
	TextOut(_hdc, 1200 - (textSize.cx / 2), 200 - (textSize.cy / 2), results[0].c_str(), results[0].length());

	GetTextExtentPoint32(_hdc, results[1].c_str(), results[1].length(), &textSize);
	TextOut(_hdc, 1200 - (textSize.cx / 2), 250 - (textSize.cy / 2), results[1].c_str(), results[1].length());

	wstring wstr = L"ESC를 눌러 나가기.";
	TextOut(_hdc, 0, 0, wstr.c_str(), wstr.length());

	wstr = L"속도 : " + std::to_wstring(userSpeed);
	TextOut(_hdc, 0, 50, wstr.c_str(), wstr.length());

	wstr = L"방향키로 노트 속도 변경.";
	TextOut(_hdc, 0, 100, wstr.c_str(), wstr.length());

	wstr = L"M을 눌러 노트 모드 변경.";
	TextOut(_hdc, 0, 150, wstr.c_str(), wstr.length());

	if (NoteCount != 0)
	{
		wstr = L"남은 노트 : " + std::to_wstring(NoteCount);
	}
	else
	{
		wstr = L"플레이 해주셔서 감사합니다 (_ _)";
	}

	GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
	TextOut(_hdc, 1100 - (textSize.cx / 2), 900 - (textSize.cy / 2), wstr.c_str(), wstr.length());

	wstr = L"PGREAT : " + std::to_wstring(GET_SINGLE(GameManager)->judgeMap[JUDGEMENT_TYPE::PGREAT]);
	TextOut(_hdc, 1150, 600, wstr.c_str(), wstr.length());

	wstr = L"GREAT : " + std::to_wstring(GET_SINGLE(GameManager)->judgeMap[JUDGEMENT_TYPE::GREAT]);
	TextOut(_hdc, 1150, 650, wstr.c_str(), wstr.length());

	wstr = L"GOOD : " + std::to_wstring(GET_SINGLE(GameManager)->judgeMap[JUDGEMENT_TYPE::GOOD]);
	TextOut(_hdc, 1150, 700, wstr.c_str(), wstr.length());

	wstr = L"BAD : " + std::to_wstring(GET_SINGLE(GameManager)->judgeMap[JUDGEMENT_TYPE::BAD]);
	TextOut(_hdc, 1150, 750, wstr.c_str(), wstr.length());

	wstr = L"MISS : " + std::to_wstring(GET_SINGLE(GameManager)->judgeMap[JUDGEMENT_TYPE::MISS]);
	TextOut(_hdc, 1150, 800, wstr.c_str(), wstr.length());

	wstr = GET_SINGLE(GameManager)->GetFasl();
	TextOut(_hdc, 1100, 500, wstr.c_str(), wstr.length());

	SetTextColor(_hdc, RGB(0, 0, 0));

	if (renderJudgeType != JUDGEMENT_TYPE::None)
	{
		GetTextExtentPoint32(_hdc, judgestr.c_str(), judgestr.length(), &textSize);
		TextOut(_hdc, 450 - (textSize.cx / 2), 600 - (textSize.cy / 2), judgestr.c_str(), judgestr.length());
	}

	SelectObject(_hdc, GET_SINGLE(Core)->ComboFont);

	wstr = GET_SINGLE(GameManager)->GetSong();
	GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);

	TextOut(_hdc, (SCREEN_WIDTH / 2 - (textSize.cx / 2)) + 3, (30 - (textSize.cy / 2)) + 3, wstr.c_str(), wstr.length());
	TextOut(_hdc, (SCREEN_WIDTH / 2 - (textSize.cx / 2)) - 3, (30 - (textSize.cy / 2)) - 3, wstr.c_str(), wstr.length());
	
	SetTextColor(_hdc, RGB(255, 255, 255));

	TextOut(_hdc, SCREEN_WIDTH / 2 - (textSize.cx / 2), 30 - (textSize.cy / 2), wstr.c_str(), wstr.length());

	SetTextColor(_hdc, RGB(0, 0, 0));

	GetTextExtentPoint32(_hdc, results[2].c_str(), results[2].length(), &textSize);
	TextOut(_hdc, 450 - (textSize.cx / 2), 300 - (textSize.cy / 2), results[2].c_str(), results[2].length());

	wstr = L"D";
	GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
	TextOut(_hdc, 300 - (textSize.cx / 2), 900 - (textSize.cy / 2), wstr.c_str(), wstr.length());

	wstr = L"F";
	GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
	TextOut(_hdc, 400 - (textSize.cx / 2), 900 - (textSize.cy / 2), wstr.c_str(), wstr.length());

	wstr = L"J";
	GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
	TextOut(_hdc, 500 - (textSize.cx / 2), 900 - (textSize.cy / 2), wstr.c_str(), wstr.length());

	wstr = L"K";
	GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
	TextOut(_hdc, 600 - (textSize.cx / 2), 900 - (textSize.cy / 2), wstr.c_str(), wstr.length());

	if (faslRenderTime > 0.0f)
	{
		SelectObject(_hdc, GET_SINGLE(Core)->FaSlFont);

		wstr = isFast == true ? L"Fast" : L"Slow";
		GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
		TextOut(_hdc, 450 - (textSize.cx / 2), 500 - (textSize.cy / 2), wstr.c_str(), wstr.length());
	}
}



Note* GameScene::GetPeekNote(int line)
{
	return GetNoteVectors[line].front();
}

void GameScene::PlaySong()
{

}
