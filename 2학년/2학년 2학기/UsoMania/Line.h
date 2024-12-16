#pragma once
#include "pch.h"
#include "Object.h"
class Line : public Object
{
public:
	Line();
	~Line();
public:
	void Init() override;
	void Update() override;
	void Render(HDC _hdc) override;
};

