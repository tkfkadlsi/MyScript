using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameSceneSetting : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Light Global_Light;
    [SerializeField] private Light Player_Light;

    [Header("Option")]
    [SerializeField] private List<Color> LightColor = new List<Color>() { Color.white };
    private void Start()
    {
        SetLightColor();
    }

    private void SetLightColor()
    {
        Global_Light.color = LightColor[Information.Instance.currentSong.SongID];
        Player_Light.color = LightColor[Information.Instance.currentSong.SongID];
    }
}
