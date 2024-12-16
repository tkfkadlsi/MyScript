#include "pch.h"
#include "TitleScene.h"
#include "Core.h"
#include "Object.h"
#include "Background.h"
#include "Player.h"
#include "InputManager.h"
#include "SceneManager.h"
#include "GameManager.h"
#include "Enemy.h"
#include "SongUI.h"
#include "CollisionManager.h"
#include "ResourceManager.h"
void TitleScene::Init()
{
	//Object* pObj = new Enemy;
	//pObj->SetPos({ SCREEN_WIDTH / 2.f,150.f });
	//pObj->SetSize({ 100.f,100.f });
	//pObj->SetName(L"Enemy");
	//AddObject(pObj, LAYER::UI);

	//Object* pPlayer = new Player;
	//pPlayer->SetPos({ SCREEN_WIDTH / 2.f,500.f });
	//pPlayer->SetSize({ 100.f,100.f });
	//AddObject(pPlayer, LAYER::GEAR);
	//GET_SINGLE(CollisionManager)->CheckLayer(LAYER::NOTE, LAYER::UI);
	////GET_SINGLE(CollisionManager)->CheckLayer(LAYER::PLAYER, LAYER::ENEMY);

	GET_SINGLE(ResourceManager)->LoadChaebo(L"Touhou Ex Boss Rush!!", L"Chaebo\\HardChaebo.txt");
	GET_SINGLE(ResourceManager)->LoadChaebo(L"Bad Apple!!!", L"Chaebo\\EasyChaebo.txt");
	GET_SINGLE(ResourceManager)->LoadSound(L"Touhou Ex Boss Rush!!", L"Sound\\HardSong.mp3", false);
	GET_SINGLE(ResourceManager)->LoadSound(L"Bad Apple!!!", L"Sound\\EasySong.mp3", false);
	GET_SINGLE(ResourceManager)->LoadSound(L"hit", L"Sound\\HitSFX.wav", false);

	GET_SINGLE(ResourceManager)->LoadSound(L"BGM", L"Sound\\Retro_bgm.wav", true);
	GET_SINGLE(ResourceManager)->Play(L"BGM", SOUND_CHANNEL::BGM);
	GET_SINGLE(ResourceManager)->Volume(SOUND_CHANNEL::BGM, 0.1f);

	Background* back = new Background;
	back->SetBG(GET_SINGLE(ResourceManager)->TextureLoad(L"Logo", L"Texture\\UsoLogo.bmp"));
	AddObject(back, LAYER::BACKGROUND);

	//Object* pSongUI = new SongUI;
	//pSongUI->SetPos({ SCREEN_WIDTH / 3.0f, 300.0f });
	//pSongUI->SetSize({ 100, 100 });
	//pSongUI->Init();
	
	//AddObject(pSongUI, LAYER::DEFAULT);

	//GET_SINGLE(GameManager)->SelectSong(L"touhou");
	//GET_SINGLE(SceneManager)->LoadScene(L"GameScene");
}

void TitleScene::Update()
{
	Scene::Update();
	if (GET_KEYDOWN(KEY_TYPE::H))
	{
		GET_SINGLE(GameManager)->SelectSong(L"Touhou Ex Boss Rush!!");
		GET_SINGLE(ResourceManager)->Stop(SOUND_CHANNEL::BGM);
		GET_SINGLE(GameManager)->currentBG = GET_SINGLE(ResourceManager)->TextureLoad(L"Hard", L"Texture\\HardBG.bmp");
		GET_SINGLE(SceneManager)->LoadScene(L"GameScene");
	}
	if (GET_KEYDOWN(KEY_TYPE::E))
	{
		GET_SINGLE(GameManager)->SelectSong(L"Bad Apple!!!");
		GET_SINGLE(ResourceManager)->Stop(SOUND_CHANNEL::BGM);
		GET_SINGLE(GameManager)->currentBG = GET_SINGLE(ResourceManager)->TextureLoad(L"Easy", L"Texture\\EasyBG.bmp");
		GET_SINGLE(SceneManager)->LoadScene(L"GameScene");
	}
}

void TitleScene::Render(HDC _hdc)
{
	Scene::Render(_hdc);

	SIZE textSize;

	SelectObject(_hdc, GET_SINGLE(Core)->ClassFont);

	{
		wstring wstr = L"UsoMania";
		GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
		TextOut(_hdc, SCREEN_WIDTH / 2 - (textSize.cx / 2), 200 - (textSize.cy / 2), wstr.c_str(), wstr.length());
	}

	SelectObject(_hdc, GET_SINGLE(Core)->ScoreFont);

	{
		wstring wstr = L"E키를 눌러 Easy난이도 시작().";
		GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
		TextOut(_hdc, SCREEN_WIDTH / 2 - (textSize.cx / 2), 750 - (textSize.cy / 2), wstr.c_str(), wstr.length());
	}

	{
		wstring wstr = L"H키를 눌러 Hard난이도 시작().";
		GetTextExtentPoint32(_hdc, wstr.c_str(), wstr.length(), &textSize);
		TextOut(_hdc, SCREEN_WIDTH / 2 - (textSize.cx / 2), 800 - (textSize.cy / 2), wstr.c_str(), wstr.length());
	}
}
