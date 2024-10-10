using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private float lerpTime;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI accuraryText;
    [SerializeField] private TextMeshProUGUI ratingText;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private TextMeshProUGUI missText;
    [SerializeField] private TextMeshProUGUI movingText;
    [SerializeField] private TextMeshProUGUI atkSuccessText;
    [SerializeField] private TextMeshProUGUI energyAccuraryText;
    [SerializeField] private TextMeshProUGUI playTimeText;

    private ResultCount resultCount = new ResultCount();
    private bool isClear = false;

    public int Score = 0;
    private float Accurary = 0f;
    public string Rating;

    private void Start()
    {
        resultCount = Information.Instance.ResultCount;
        isClear = Information.Instance.isClear;

        Accurary = (float)(resultCount.Play * 100) / (float)(resultCount.Play + resultCount.Miss);
    
        float dlatlAccurary = Accurary;
        if (isClear)
        {
            Score = (resultCount.Play * -50) + (resultCount.Miss * -100)
            + (int)(dlatlAccurary * 500) + (resultCount.ATKSuccess * 500)
            + (int)(10000000 / Information.Instance.PlayTime) + (int)(resultCount.EnergyAccurary * 1000)
            + 10000;
        }
        else
        {
            Score = (resultCount.Play * -50) + (resultCount.Miss * -100)
            + (int)(dlatlAccurary * 500) + (resultCount.ATKSuccess * 500)
            + (int)(resultCount.EnergyAccurary * 1000);
        }

        if (Score >= 300000) Rating = "S";
        else if (Score >= 280000) Rating = "A";
        else if (Score >= 250000) Rating = "B";
        else if (Score >= 210000) Rating = "C";
        else if (Score >= 160000) Rating = "D";
        else if (Score >= 100000) Rating = "E";
        else Rating = "F";

        if(Information.Instance.stageDifficult == Difficult.normal)
        {
            if(Information.Instance.NormalHighScore < Score)
            {
                Information.Instance.NormalHighScore = Score;
                Information.Instance.NormalHighRating = Rating;
                DataToJson();
            }
        }
        else if(Information.Instance.stageDifficult == Difficult.hard)
        {
            if (Information.Instance.HardHighScore < Score)
            {
                Information.Instance.HardHighScore = Score;
                Information.Instance.HardHighRating = Rating;
                DataToJson();
            }
        }

        StartCoroutine(Lerps());
    }

    private void DataToJson()
    {
        ResultJsonClass data = new ResultJsonClass();

        data.NormalScore = Information.Instance.NormalHighScore;
        data.HardScore = Information.Instance.HardHighScore;
        data.NormalRating = Information.Instance.NormalHighRating;
        data.HardRating = Information.Instance.HardHighRating;

        string jsonData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.dataPath, "HighScore.json");
        File.WriteAllText(path, jsonData);
    }

    private IEnumerator Lerps()
    {
        float t = 0;
        float time = 0;

        

        while (t != lerpTime)
        {
            string str = "";
            if (Information.Instance.Language == "한국어")
            {
                str = ((int)Mathf.Lerp(0, Score, t / lerpTime)).ToString("D6");
                scoreText.text = $"점수 : {str}";

                str = Mathf.Lerp(0, Accurary, t / lerpTime).ToString("0.00");
                accuraryText.text = $"정확도 : {str}%";

                str = ((int)Mathf.Lerp(0, resultCount.Play, t / lerpTime)).ToString("D4");
                playText.text = $"연주한 음표 : {str}";

                str = ((int)Mathf.Lerp(0, resultCount.Miss, t / lerpTime)).ToString("D4");
                missText.text = $"놓친 음표 : {str}";

                str = ((int)Mathf.Lerp(0, resultCount.Moving, t / lerpTime)).ToString("D4");
                movingText.text = $"움직인 횟수 : {str}";

                str = ((int)Mathf.Lerp(0, resultCount.ATKSuccess, t / lerpTime)).ToString("D4");
                atkSuccessText.text = $"공격에 성공한 횟수 : {str}";

                str = Mathf.Lerp(0, resultCount.EnergyAccurary, t / lerpTime).ToString("0.00");
                energyAccuraryText.text = $"평균 체력 : {str}";

                time = Mathf.Lerp(0, Information.Instance.PlayTime, t / lerpTime);
                playTimeText.text = $"플레이 타임 : {TimeSpan.FromSeconds(time).ToString("mm\\:ss\\.ff")}";
            }
            else if(Information.Instance.Language == "English")
            {
                str = ((int)Mathf.Lerp(0, Score, t / lerpTime)).ToString("D6");
                scoreText.text = $"Score : {str}";

                str = Mathf.Lerp(0, Accurary, t / lerpTime).ToString("0.00");
                accuraryText.text = $"Accuracy : {str}%";

                str = ((int)Mathf.Lerp(0, resultCount.Play, t / lerpTime)).ToString("D4");
                playText.text = $"Played Notes : {str}";

                str = ((int)Mathf.Lerp(0, resultCount.Miss, t / lerpTime)).ToString("D4");
                missText.text = $"Missed Notes : {str}";

                str = ((int)Mathf.Lerp(0, resultCount.Moving, t / lerpTime)).ToString("D4");
                movingText.text = $"Moving Count : {str}";

                str = ((int)Mathf.Lerp(0, resultCount.ATKSuccess, t / lerpTime)).ToString("D4");
                atkSuccessText.text = $"Attack Count : {str}";

                str = Mathf.Lerp(0, resultCount.EnergyAccurary, t / lerpTime).ToString("0.00");
                energyAccuraryText.text = $"Average Health : {str}";

                time = Mathf.Lerp(0, Information.Instance.PlayTime, t / lerpTime);
                playTimeText.text = $"Play Time : {TimeSpan.FromSeconds(time).ToString("mm\\:ss\\.ff")}";
            }


            t += Time.deltaTime;
            yield return null;
            if(t > lerpTime)
            {
                t = lerpTime;
            }
        }
        ratingText.text = Rating;
        Debug.Log(Rating);

        if(Information.Instance.Language == "한국어")
        {
            scoreText.text = $"점수 : {Score.ToString("D6")}";
            accuraryText.text = $"정확도 : {Accurary.ToString("0.00")}%";
            playText.text = $"연주한 음표 : {resultCount.Play.ToString("D4")}";
            missText.text = $"놓친 음표 : {resultCount.Miss.ToString("D4")}";
            movingText.text = $"움직인 횟수 : {resultCount.Moving.ToString("D4")}";
            atkSuccessText.text = $"공격에 성공한 횟수 : {resultCount.ATKSuccess.ToString("D4")}";
            energyAccuraryText.text = $"평균 체력 : {resultCount.EnergyAccurary.ToString("F2")}";
            playTimeText.text = $"플레이 타임 : {TimeSpan.FromSeconds(Information.Instance.PlayTime).ToString("mm\\:ss\\.ff")}";
        }
        else if(Information.Instance.Language == "English")
        {
            scoreText.text = $"Score : {Score.ToString("D6")}";
            accuraryText.text = $"Accuracy : {Accurary.ToString("0.00")}%";
            playText.text = $"Played Notes : {resultCount.Play.ToString("D4")}";
            missText.text = $"Missed Notes : {resultCount.Miss.ToString("D4")}";
            movingText.text = $"Moving Count : {resultCount.Moving.ToString("D4")}";
            atkSuccessText.text = $"Attack Count : {resultCount.ATKSuccess.ToString("D4")}";
            energyAccuraryText.text = $"Average Health : {resultCount.EnergyAccurary.ToString("F2")}";
            playTimeText.text = $"Play Time : {TimeSpan.FromSeconds(Information.Instance.PlayTime).ToString("mm\\:ss\\.ff")}";
        }
    }

    public void GoTitle()
    {
        Information.Instance.ResultCount = new ResultCount();
        SceneManager.LoadScene(0);
    }
}

public class ResultJsonClass
{
    public int NormalScore;
    public int HardScore;
    public string NormalRating;
    public string HardRating;
}