using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInformation : MonoBehaviour
{
    [SerializeField] private List<AchieveData> AchieveDatas = new List<AchieveData>();
    [SerializeField] private List<SkinData> SkinDatas = new List<SkinData>();
    [SerializeField] private List<ThemeTypeSO> ThemeDatas = new List<ThemeTypeSO>();

    private void Start()
    {
        foreach(AchieveData data in AchieveDatas)
        {
            Information.Instance.AchieveDicionary.Add(data.Type, data.Achieve);
        }
        foreach(SkinData data in SkinDatas)
        {
            Information.Instance.SkinDictionary.Add(data.Type, data.Skin);
        }
        foreach(ThemeTypeSO data in ThemeDatas)
        {
            Information.Instance.ThemeDictionary.Add(data.themeType, data);
        }
    }
}
