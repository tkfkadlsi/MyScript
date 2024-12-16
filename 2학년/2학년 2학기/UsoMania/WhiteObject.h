#pragma once
#include "Object.h"
class WhiteObject :
    public Object
{
public:
    WhiteObject();
    ~WhiteObject();
public:
    void Init() override;
    void Update() override;
    void Render(HDC _hdc) override;
private:
    HBRUSH whiteBrush;
    HBRUSH oldBrush;
};

