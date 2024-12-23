#pragma once
#include "Object.h"
class Background :
    public Object
{
public:
	Background();
	~Background();
public:
	void Init() override;
	void Update() override;
	void Render(HDC _hdc) override;
	void SetBG(Texture* texture);
};

