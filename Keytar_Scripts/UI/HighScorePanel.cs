using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.IO;

public class HighScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI HighRatingText;

    private RectTransform rect;

    public int HighScore = 0;
    public string HighRating = "";

    private void Awake()
    {
        rect = this.GetComponent<RectTransform>();
    }

    public void OpenPanel(Difficult difficult)
    {
        if(difficult == Difficult.normal)
        {
            if(Information.Instance.Language == "한국어")
                HighScoreText.text = "최고 점수 : " + Information.Instance.NormalHighScore.ToString("D6");
            else if(Information.Instance.Language == "English")
                HighScoreText.text = "High Score : " + Information.Instance.NormalHighScore.ToString("D6");

            HighRatingText.text = Information.Instance.NormalHighRating;
        }
        else if(difficult == Difficult.hard)
        {
            if(Information.Instance.Language == "한국어")
                HighScoreText.text = "최고 점수 : " + Information.Instance.HardHighScore.ToString("D6");
            else if(Information.Instance.Language == "English")
                HighScoreText.text = "High Score : " + Information.Instance.HardHighScore.ToString("D6");

            HighRatingText.text = Information.Instance.HardHighRating;
        }
        rect.DOAnchorPos(new Vector2(0, 0), 0.25f).SetEase(Ease.OutSine);
    }
    public void ClosePanel()
    {
        rect.DOAnchorPos(new Vector2(500, 0), 0.25f).SetEase(Ease.OutSine);
    }
}
