using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;

    [SerializeField] List<string> strings = new List<string>();
    [SerializeField] List<string> engStrings = new List<string>();

    [SerializeField] private Button exitButton;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ClickNoTouchZone()
    {
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        if (Information.Instance.IsKorean)
            storyText.text = strings[Information.Instance.currentSong.SongID];
        else
            storyText.text = engStrings[Information.Instance.currentSong.SongID];
    }
}