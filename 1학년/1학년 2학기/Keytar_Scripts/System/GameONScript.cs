using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameONScript : MonoBehaviour
{

    
    private void Start()
    {
        JsonLoad();
    }

    private void JsonLoad()
    {
        ResultJsonClass resultJsonClass = new ResultJsonClass();

        string path = Path.Combine(Application.dataPath, "HighScore.json");
        if (!File.Exists(path))
        {
            Information.Instance.NormalHighScore = 0;
            Information.Instance.HardHighScore = 0;
            Information.Instance.NormalHighRating = "F";
            Information.Instance.HardHighRating = "F";
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            resultJsonClass = JsonUtility.FromJson<ResultJsonClass>(loadJson);

            Information.Instance.NormalHighScore = resultJsonClass.NormalScore;
            Information.Instance.NormalHighRating = resultJsonClass.NormalRating;
            Information.Instance.HardHighScore = resultJsonClass.HardScore;
            Information.Instance.HardHighRating = resultJsonClass.HardRating;
        }
    }
}
