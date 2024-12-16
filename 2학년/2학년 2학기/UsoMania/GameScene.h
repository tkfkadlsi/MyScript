#pragma once
#include "Scene.h"
#include <queue>
#include <vector>

class Note;
class KeyBam;

class GameScene :
    public Scene
{
public:
    // Scene을(를) 통해 상속됨
    virtual void Init() override;
    virtual void Update() override;
    virtual void Render(HDC _hdc) override;
    Note* GetPeekNote(int line);
private:
    void PlaySong();
public:
    std::vector<std::vector<Note*>> GetNoteVectors{ 4 };
    int NoteCount = 0;
private:
    std::vector<KeyBam*> KeyBams;
public:
    bool isCircle = false;
    float userSpeed = 1.5f;
    float faslRenderTime = 0.0f;
    bool isFast = false;
    bool isPlayingSong = false;
    float playSongTimer = 0.0f;
};