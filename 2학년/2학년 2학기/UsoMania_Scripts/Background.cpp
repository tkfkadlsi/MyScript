#include "pch.h"
#include "Background.h"
#include "ResourceManager.h"
#include "Texture.h"
Background::Background()
{

}

Background::~Background()
{
}

void Background::Init()
{
}

void Background::Update()
{
}

void Background::Render(HDC _hdc)
{
	int width = pTex->GetWidth();
	int height = pTex->GetHeight();
	::BitBlt(_hdc
	, SCREEN_WIDTH / 2 - width / 2
	, SCREEN_HEIGHT / 2 - height / 2
	, width, height,
		pTex->GetTexDC()
	,0,0,SRCCOPY
);
	//::BitBlt(); // 그냥 옮길때 - 고속복사
	//::TransparentBlt(); // 색깔을 뺄때
	//::StretchBlt(); // 확대 혹은 축소해서 그릴때, 반전할때
}

void Background::SetBG(Texture* texture)
{
	pTex = texture;
}
