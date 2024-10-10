using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongEnd : MonoBehaviour
{
    [SerializeField] private Slider enemyHP;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private JudgeText judgeText;

    float songTime;
    bool songStart = false;

    public void GameStart()
    {
        switch (Information.instance.Stage)
        {
            case 0:
                songTime = 32;
                break;
            case 1:
                songTime = 119;
                break;
            case 2:
                songTime = 46;
                break;
            case 3:
                songTime = 60;
                break;
            case 4:
                songTime = 140;
                break;
                    case 5:
                songTime = 143;
                break;
        }
        audioSource.volume = 1;
    }


    public void SongStart()
    {
        songStart = true;
    }

    private void Update()
    {
        if(songStart == true)
        {
            songTime -= Time.deltaTime;
        }

        if(songTime < 0)
        {
            CallSongEnd();
        }

        if(songTime < 1)
        {
            audioSource.volume -= Time.deltaTime;
        }
    }

    public void CallSongEnd()
    {
        if(enemyHP.value == 0)
        {
            Information.instance.clearGame = true;
        }
        else
        {
            Information.instance.clearGame = false;
        }

        Information.instance._critical = judgeText.critical;
        Information.instance._nice = judgeText.nice;
        Information.instance._miss = judgeText.miss;
        Information.instance._defense = judgeText.defense;
        Information.instance._safe = judgeText.safe;
        Information.instance._break = judgeText.break_;
        Information.instance._highCombo = judgeText.highCombo;

        SceneManager.LoadScene(3);
    }
}
