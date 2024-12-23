#pragma once


enum class MENU
{
	START, INFO, QUIT
};

enum class KEY
{
	UP, DOWN, SPACE, FALE
};

void Init();
bool TitleScene();
void TitleRender();
void InfoRender();
void EnterAnimation();
MENU MenuRender();
KEY KeyController();

