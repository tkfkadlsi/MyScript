using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class StartButton : MonoBehaviour
    , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject selectPanel;
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject optionPanel2;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject song3Panel;

    [SerializeField] private TextMeshProUGUI highScore1;
    [SerializeField] private TextMeshProUGUI highScore2;
    [SerializeField] private TextMeshProUGUI highScore3;
    [SerializeField] private TextMeshProUGUI hiddenHighScore;

    [SerializeField] private TextMeshProUGUI speedRateText;

    [SerializeField] private AudioSource startSong;
    [SerializeField] private AudioClip startClip;

    bool isSelect;
    public bool isGuide;
    public bool isOption;
    bool isExit;

    float speedRate = 1.0f;

    int control = 0;

    public int Control
    {
        get { return control; }
        set
        {
            if (-5 > value || value > 10) return;
            else
            {
                control = value;
                speedRate = 1 + control * 0.1f;
                speedRateText.text = $"Speed Rate : {speedRate}";
                PlayerPrefs.SetFloat("SpeedRate", speedRate);
            }
        }
    }

    private void Awake()
    {
        Time.timeScale = 1;
        isSelect = false;
        isGuide = false;
        isOption = false;
        isExit = false;

        if (PlayerPrefs.GetString("PlayerColor") == null)
            SetPlayerColorOrange();
        else
            Invoke(PlayerPrefs.GetString("PlayerColor"), 0);

        if (PlayerPrefs.GetString("LaserColor") == null)
            SetLaserColorRed();
        else
            Invoke(PlayerPrefs.GetString("LaserColor"), 0);

        highScore1.text = "High Score : " + PlayerPrefs.GetInt("HighScore1").ToString();
        highScore2.text = "High Score : " + PlayerPrefs.GetInt("HighScore2").ToString();
        highScore3.text = "High Score : " + PlayerPrefs.GetInt("HighScore3").ToString();
        hiddenHighScore.text = "High Score : " + PlayerPrefs.GetInt("HiddenHighScore").ToString();

        Control = 0;
        speedRateText.text = $"Speed Rate : {speedRate}";

        selectPanel.SetActive(false);
        guidePanel.SetActive(false);
        exitPanel.SetActive(false);
        optionPanel.SetActive(false);
        optionPanel2.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isSelect == true)
            {
                selectPanel.SetActive(false);
                startSong.Stop();
                startSong.clip = startClip;
                startSong.time = 0;
                startSong.Play();
                startSong.volume = 0.5f;
                isSelect = false;
            }
            else if(isGuide == true)
            {
                guidePanel.SetActive(false);
                isGuide = false;
            }
            else if(isOption == true)
            {
                optionPanel.SetActive(false);
                optionPanel2.SetActive(false);
                isOption = false;
            }
            else
            {
                if(isExit == false)
                {
                    exitPanel.SetActive(true);
                    isExit = true;
                }
                else
                {
                    exitPanel.SetActive(false);
                    isExit = false;
                }
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.DOColor(new Color(1, 0, 0), 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.DOColor(new Color(1, 1, 1), 0.25f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectPanel.SetActive(true);
        song3Panel.SetActive(true);
        isSelect = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SpeedRateUp()
    {
        Control++;
    }

    public void SpeedRateDown()
    {
        Control--;
    }

    public void OptionChange()
    {
        if(optionPanel.activeSelf == true)
        {
            optionPanel.SetActive(false);
            optionPanel2.SetActive(true);
        }
        else
        {
            optionPanel.SetActive(true);
            optionPanel2.SetActive(false);
        }
    }

    public void SetPlayerColorRed()
    {
        KeyInfo.instance.playerColor = new Color(1, 0, 0);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorRed");
    }

    public void SetPlayerColorOrange()
    {
        KeyInfo.instance.playerColor = new Color(1, 0.5f, 0);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorOrange");
    }

    public void SetPlayerColorYellow()
    {
        KeyInfo.instance.playerColor = new Color(1, 1, 0);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorYellow");
    }

    public void SetPlayerColorGreen()
    {
        KeyInfo.instance.playerColor = new Color(0, 1, 0);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorGreen");
    }

    public void SetPlayerColorSky()
    {
        KeyInfo.instance.playerColor = new Color(0, 1, 1);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorSky");
    }

    public void SetPlayerColorBlue()
    {
        KeyInfo.instance.playerColor = new Color(0, 0, 1);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorBlue");
    }

    public void SetPlayerColorPurple()
    {
        KeyInfo.instance.playerColor = new Color(0.5f, 0, 1);
        PlayerPrefs.SetString("PlayerColor", "SetPlayerColorPurple");
    }




    public void SetLaserColorRed()
    {
        KeyInfo.instance.laserColor = new Color(1, 0, 0);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorRed");
    }

    public void SetLaserColorOrange()
    {
        KeyInfo.instance.laserColor = new Color(1, 0.5f, 0);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorOrange");
    }

    public void SetLaserColorYellow()
    {
        KeyInfo.instance.laserColor = new Color(1, 1, 0);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorYellow");
    }

    public void SetLaserColorGreen()
    {
        KeyInfo.instance.laserColor = new Color(0, 1, 0);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorGreen");
    }

    public void SetLaserColorSky()
    {
        KeyInfo.instance.laserColor = new Color(0, 1, 1);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorSky");
    }

    public void SetLaserColorBlue()
    {
        KeyInfo.instance.laserColor = new Color(0, 0, 1);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorBlue");
    }

    public void SetLaserColorPurple()
    {
        KeyInfo.instance.laserColor = new Color(0.5f, 0, 1);
        PlayerPrefs.SetString("LaserColor", "SetLaserColorPurple");
    }

    
}
