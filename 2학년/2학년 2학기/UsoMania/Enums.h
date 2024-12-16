#pragma once
enum class LAYER
{
	DEFAULT,
	BACKGROUND,
	BACKGEAR,
	KEYBAM,
	NOTE,
	GEAR,
	UI,
	END,
};

enum class PEN_TYPE
{
	HOLLOW, RED, GREEN,
	BLUE, YELLOW, END
};

enum class BRUSH_TYPE
{
	HOLLOW, RED, GREEN,
	BLUE, YELLOW, END
};


enum class EVENT_TYPE
{
	CREATE_OBJECT,
	DELETE_OBJECT,
	SCENE_CHANGE,
	END,
};


enum class JUDGEMENT_TYPE
{
	PGREAT = 42,
	GREAT = 66,
	GOOD = 100,
	BAD = 142,
	MISS = 192,
	None
};


enum class SONG_LIST
{
	VICTORY
};
