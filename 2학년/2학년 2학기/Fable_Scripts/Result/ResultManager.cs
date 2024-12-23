using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private Image DifficultImage;
    [SerializeField] private TextMeshProUGUI perfectCount;
    [SerializeField] private TextMeshProUGUI greatCount;
    [SerializeField] private TextMeshProUGUI badCount;
    [SerializeField] private TextMeshProUGUI missCount;
    [SerializeField] private TextMeshProUGUI Accurary;
    [SerializeField] private AnimationCurve resultCurve;

    [SerializeField] private TextMeshProUGUI coinCount;
    [SerializeField] private TextMeshProUGUI expCount;

    [SerializeField] private RectTransform starSlideRect;
    [SerializeField] private RectTransform arrowRect;
    [SerializeField] private Image starSliderFill;

    [SerializeField] private Sprite FairyImage;
    [SerializeField] private Sprite DreamImage;
    [SerializeField] private Sprite NightmareImage;
    private StarRating starRating;

    private int plusCoin;
    private int plusEXP;

    private float accurary = 0f;
    private bool isAP = false;
    private bool isFC = false;

    private bool isOneStar = false;
    private bool isTwoStar = false;
    private bool isThreeStar = false;

    Vector2 startPos;
    Vector2 endPos;

    public void Start()
    {
        Application.targetFrameRate = 60;
        starRating = GetComponent<StarRating>();

        IsClear();
        WhatIsDifficult();
        CalculateAccu();
        SetArrowPoses();
        PlusUserEXP();
        PlusUserGold();
        Information.Instance.GetComponent<SaveLoadData>().SaveData();
        StartCoroutine(ResultDisplay());
        starSliderFill.fillAmount = 0f;
        UpdateRecord();
    }

    private void WhatIsDifficult()
    {
        if (Information.Instance.currentDiff == DifficultType.Fairy)
        {
            DifficultImage.sprite = FairyImage;
        }
        else if (Information.Instance.currentDiff == DifficultType.Dream)
        {
            DifficultImage.sprite = DreamImage;
        }
        else
        {
            DifficultImage.sprite = NightmareImage;
        }
    }

    private void IsClear()
    {
        if (Information.Instance.currentDiff == DifficultType.Fairy)
            Information.Instance.GameData.IsFairytaleClear[Information.Instance.currentSong.SongID] = true;
        else if (Information.Instance.currentDiff == DifficultType.Dream)
            Information.Instance.GameData.IsDreamClear[Information.Instance.currentSong.SongID] = true;
        else
            Information.Instance.GameData.IsNightClear[Information.Instance.currentSong.SongID] = true;
    }

    private void CalculateAccu()
    {
        float sumJudge
           = Information.Instance.dream * 100
           + Information.Instance.cool * 65
           + Information.Instance.bed * 35
           + Information.Instance.awake * 0;

        float sumNote
            = Information.Instance.dream
            + Information.Instance.cool
            + Information.Instance.bed
            + Information.Instance.awake;

        accurary = sumJudge / sumNote;


    }

    private void SetArrowPoses()
    {
        float height = starSlideRect.rect.height;

        startPos = new Vector2(-25, -height / 2);
        endPos = new Vector2(-25, height / 2);

        startPos.y += 25;
        endPos.y += 22;
    }

    private void PlusUserEXP()
    {

        int multiplier = 1;

        if (Information.Instance.UseKnowledgeItem)
            multiplier = 2;

        GameData data = Information.Instance.GameData;

        if (Information.Instance.currentDiff == DifficultType.Fairy)
        {
            plusEXP = ((int)(Mathf.Sqrt(Information.Instance.currentSong.FairytaleDiffcult) * accurary * 2) + 400) * multiplier; //置社 600
        }
        else if (Information.Instance.currentDiff == DifficultType.Dream)
        {
            plusEXP = ((int)(Mathf.Sqrt(Information.Instance.currentSong.DreamDifficult) * accurary * 2) + 400) * multiplier; //置社 600
        }
        else
        {
            plusEXP = ((int)(Mathf.Sqrt(Information.Instance.currentSong.NightMareDifficult) * accurary * 2) + 400) * multiplier; //置企 1000
        }

        data.Exp += plusEXP;

        while (data.Exp >= 1000)
        {
            data.Exp -= 1000;
            data.LV++;
        }
        Information.Instance.UseKnowledgeItem = false;
    }

    private void PlusUserGold()
    {
        GameData data = Information.Instance.GameData;

        if (Information.Instance.currentDiff == DifficultType.Fairy)
        {
            plusCoin = ((int)(Mathf.Sqrt(Information.Instance.currentSong.FairytaleDiffcult) * accurary) + 50); //置社 150
        }
        else if (Information.Instance.currentDiff == DifficultType.Dream)
        {
            plusCoin = ((int)(Mathf.Sqrt(Information.Instance.currentSong.DreamDifficult) * accurary) + 100); //置社 200
        }
        else
        {
            plusCoin = ((int)(Mathf.Sqrt(Information.Instance.currentSong.NightMareDifficult) * accurary) + 100); //置企 400
        }

        data.Coin += plusCoin;
    }

    private IEnumerator ResultDisplay()
    {
        songName.text = Information.Instance.currentSong.SongName;

        if (Information.Instance.awake == 0)
            isFC = true;

        if (this.accurary == 100f)
            isAP = true;

        float t = 0f;
        float lerpTime = 5.0f;

        float perfect = Information.Instance.dream;
        float great = Information.Instance.cool;
        float bad = Information.Instance.bed;
        float miss = Information.Instance.awake;

        float accurary = 0f;
        float targetFillAmount = this.accurary / 100f;

        Vector2 targetPos = Vector2.Lerp(startPos, endPos, this.accurary / 100f);

        while (t < lerpTime + 0.02f)
        {
            perfectCount.text = ((int)ReturnLerp(0, perfect, t / lerpTime)).ToString();
            greatCount.text = ((int)ReturnLerp(0, great, t / lerpTime)).ToString();
            badCount.text = ((int)ReturnLerp(0, bad, t / lerpTime)).ToString();
            missCount.text = ((int)ReturnLerp(0, miss, t / lerpTime)).ToString();
            accurary = ReturnLerp(0, this.accurary, t / lerpTime);
            arrowRect.anchoredPosition = ReturnLerp(startPos, targetPos, t / lerpTime);
            starSliderFill.fillAmount = ReturnLerp(0, targetFillAmount, t / lerpTime);
            coinCount.text = ((int)ReturnLerp(0, plusCoin, t / lerpTime)).ToString();
            expCount.text = ((int)ReturnLerp(0, plusEXP, t / lerpTime)).ToString();
            Accurary.text = "Accurary : " + accurary.ToString("F2") + "%";
            CalculateStarRating(accurary);

            t += Time.deltaTime;
            yield return null;
        }
        CalculateFCAP();
    }

    private void CalculateStarRating(float accurary)
    {
        if (accurary < 50f)
        {
            return;
        }

        if (accurary < 70f)
        {
            if (isOneStar)
            {
                return;
            }

            isOneStar = true;
            starRating.OneStar();
            return;
        }

        if (accurary < 90f)
        {
            if (isTwoStar)
            {
                return;
            }

            isTwoStar = true;
            starRating.TwoStar();
            return;
        }

        if (accurary < 100f)
        {
            if (isThreeStar)
            {
                return;
            }

            isThreeStar = true;
            starRating.ThreeStar();
            return;
        }
    }

    private void CalculateFCAP()
    {
        if (isAP)
        {
            starRating.AP();
        }
        else if (isFC && isThreeStar)
        {
            starRating.FC();
        }
    }

    private float ReturnLerp(float start, float end, float t)
    {
        return Mathf.Lerp(start, end, resultCurve.Evaluate(t));
    }

    private Vector2 ReturnLerp(Vector2 start, Vector2 end, float t)
    {
        return Vector2.Lerp(start, end, resultCurve.Evaluate(t));
    }

    public void GoLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }

    private void UpdateRecord()
    {
        int id = Information.Instance.currentSong.SongID;
        if (Information.Instance.currentDiff == DifficultType.Fairy)
        {
            if (Information.Instance.GameData.BestFairytaleAccuraries[id] < accurary)
            {
                Information.Instance.GameData.BestFairytaleAccuraries[id] = accurary;
            }
            else
            {
                return;
            }

            if (isAP)
            {
                Information.Instance.GameData.BestStarRatingFairytale[id] = 5;
            }
            else if (isFC)
            {
                Information.Instance.GameData.BestStarRatingFairytale[id] = 4;
            }
            else if (isThreeStar)
            {
                Information.Instance.GameData.BestStarRatingFairytale[id] = 3;
            }
            else if (isTwoStar)
            {
                Information.Instance.GameData.BestStarRatingFairytale[id] = 2;
            }
            else if (isOneStar)
            {
                Information.Instance.GameData.BestStarRatingFairytale[id] = 1;
            }
            else
            {
                Information.Instance.GameData.BestStarRatingFairytale[id] = 0;
            }
        }
        else if (Information.Instance.currentDiff == DifficultType.Dream)
        {
            if (Information.Instance.GameData.BestDreamAccuraries[id] < accurary)
            {
                Information.Instance.GameData.BestDreamAccuraries[id] = accurary;
            }
            else
            {
                return;
            }

            if (isAP)
            {
                Information.Instance.GameData.BestStarRatingDream[id] = 5;
            }
            else if (isFC)
            {
                Information.Instance.GameData.BestStarRatingDream[id] = 4;
            }
            else if (accurary > 90f)
            {
                Information.Instance.GameData.BestStarRatingDream[id] = 3;
            }
            else if (accurary > 70f)
            {
                Information.Instance.GameData.BestStarRatingDream[id] = 2;
            }
            else if (accurary > 50f)
            {
                Information.Instance.GameData.BestStarRatingDream[id] = 1;
            }
            else
            {
                Information.Instance.GameData.BestStarRatingDream[id] = 0;
            }
        }
        else
        {
            if (Information.Instance.GameData.BestNightmareAccuraries[id] < accurary)
            {
                Information.Instance.GameData.BestNightmareAccuraries[id] = accurary;
            }
            else
            {
                return;
            }

            if (isAP)
            {
                Information.Instance.GameData.BestStarRatingNightmare[id] = 5;
            }
            else if (isFC)
            {
                Information.Instance.GameData.BestStarRatingNightmare[id] = 4;
            }
            else if (accurary > 90f)
            {
                Information.Instance.GameData.BestStarRatingNightmare[id] = 3;
            }
            else if (accurary > 70f)
            {
                Information.Instance.GameData.BestStarRatingNightmare[id] = 2;
            }
            else if (accurary > 50f)
            {
                Information.Instance.GameData.BestStarRatingNightmare[id] = 1;
            }
            else
            {
                Information.Instance.GameData.BestStarRatingNightmare[id] = 0;
            }
        }
    }
}