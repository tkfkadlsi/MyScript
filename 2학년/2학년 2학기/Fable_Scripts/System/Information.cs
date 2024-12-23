using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class Information : MonoBehaviour
{
    [Header("SongList")]
    public List<Song> SongList = new List<Song>();

    [Header("SelectedSong")]
    public Song currentSong;
    public DifficultType currentDiff;

    [Header("Judgement")]
    public int dream;
    public int cool;
    public int bed;
    public int awake;

    [Header("Option")]
    public int offset;
    public int ScreenHalfWidth;
    public int InGameFrame = 120;
    public bool IsLowDetailMode;
    public bool IsShake;
    public bool ShowEffect;
    public bool IsKorean;

    [Header("GameData")]
    public GameData GameData;

    [Header("Item")]
    public Dictionary<AchieveType, string> AchieveDicionary = new Dictionary<AchieveType, string>();
    public Dictionary<SkinType, NoteSkin> SkinDictionary = new Dictionary<SkinType, NoteSkin>();
    public Dictionary<ThemeType, ThemeTypeSO> ThemeDictionary = new Dictionary<ThemeType, ThemeTypeSO>();

    public List<RankingData> rankingDatas = new List<RankingData>();
    public RankingData myRankingData = new RankingData();

    public List<string> gameversion;

    public bool UseHeroItem = false;
    public bool UseFairyItem = false;
    public bool UseKnowledgeItem = false;
    public bool UseFairytaleItem = false;

    public static Information Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            if (PlayerPrefs.HasKey("IsLowDetailMode"))
            {
                IsShake = PlayerPrefs.GetInt("IsShake") == 0 ? false : true;
                ShowEffect = PlayerPrefs.GetInt("ShowEffect") == 0 ? false : true;
                InGameFrame = PlayerPrefs.GetInt("InGameFrame");
                //IsKorean = PlayerPrefs.GetInt("IsKorean") == 0 ? false : true;
                IsKorean = true;
                IsLowDetailMode = PlayerPrefs.GetInt("IsLowDetailMode") == 0 ? false : true;
            }
            else
            {
                IsShake = true;
                ShowEffect = true;
                InGameFrame = 120;
                IsKorean = true;
                IsLowDetailMode = false;
            }

            Instance = this;
            currentSong = SongList[0];
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        PlayerPrefs.SetInt("IsShake", IsShake == true ? 1 : 0);
        PlayerPrefs.SetInt("ShowEffect", ShowEffect == true ? 1 : 0);
        PlayerPrefs.SetInt("InGameFrame", InGameFrame);
        PlayerPrefs.SetInt("IsKorean", IsKorean == true ? 1 : 0);
        PlayerPrefs.SetInt("IsLowDetailMode", IsLowDetailMode == true ? 1 : 0);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("IsShake", IsShake == true ? 1 : 0);
        PlayerPrefs.SetInt("ShowEffect", ShowEffect == true ? 1 : 0);
        PlayerPrefs.SetInt("InGameFrame", InGameFrame);
        PlayerPrefs.SetInt("IsKorean", IsKorean == true ? 1 : 0);
        PlayerPrefs.SetInt("IsLowDetailMode", IsLowDetailMode == true ? 1 : 0);
        DOTween.KillAll();
    }

    public bool IsAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }
    public void SetUpItemfalse()
    {
        UseHeroItem = false;
        UseKnowledgeItem = false;
        UseFairyItem = false;
        UseFairytaleItem = false;
    }
}
