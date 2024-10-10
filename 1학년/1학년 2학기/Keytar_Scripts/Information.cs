using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Information : MonoBehaviour
{
    public static Information Instance;
    public Action ChaeboChange;

    public string Keymode = "";
    public List<Key> currentKeyList = new List<Key>();

    public ResultCount ResultCount;
    public bool isClear = false;
    private Chaebo currentChaebo;

    public string Language;

    public float PlayTime;

    public Chaebo CurrentChaebo
    {
        get
        {
            return currentChaebo;
        }

        set
        {
            currentChaebo = value;
            ChaeboChange?.Invoke();
        }
    }

    public Instrument CurrentInst;

    public Difficult stageDifficult;

    public bool LDM;

    public int NormalHighScore;
    public int HardHighScore;
    public string NormalHighRating;
    public string HardHighRating;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("Language"))
        {
            Language = PlayerPrefs.GetString("Language");
        }
        else
        {
            Language = "ÇÑ±¹¾î";
            PlayerPrefs.SetString("Language", Language);
        }
    }
}
