using System.Collections.Generic;

public class GameData
{
    public int[] BestStarRatingFairytale = new int[10];
    public int[] BestStarRatingDream = new int[10];
    public int[] BestStarRatingNightmare = new int[10];
    public float[] BestFairytaleAccuraries = new float[10];
    public float[] BestDreamAccuraries = new float[10];
    public float[] BestNightmareAccuraries = new float[10];
    public bool[] IsFairytaleClear = new bool[10];
    public bool[] IsDreamClear = new bool[10];
    public bool[] IsNightClear = new bool[10];
    public int EnterTicket;
    public string Nickname;
    public string PassWord;
    public int Exp;
    public int LV;
    public int Coin;
    public List<AchieveType> IsAchieveUnLock = new List<AchieveType>();
    public AchieveType selectedAchieve;
    public List<SkinType> IsSkinUnLock = new List<SkinType>();
    public SkinType selectedSkin;
    public List<ThemeType> IsThemeUnLock = new List<ThemeType>();
    public ThemeType selectedTheme;
    public bool isChild;
    public bool[] IsBlessOn = new bool[4];
    public bool IsTutorialPopup;
}