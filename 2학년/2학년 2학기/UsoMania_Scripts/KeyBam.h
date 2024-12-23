#pragma once
#include "Object.h"


class KeyBam : public Object
{
public:
	KeyBam();
	~KeyBam();
public:
	virtual void Update() override;
	virtual void Render(HDC _hdc) override;
public:
	bool isPressed = false;
private:
	HBRUSH blueBrush;
};

