using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SongPause : MonoBehaviour
{

    public void IsPause(GameObject stopPanel, AudioSource source)
    {
        stopPanel.SetActive(true);
        Time.timeScale = 0;
        source.pitch = 0;
    }

    public void CallContinue(GameObject stopPanel, AudioSource source)
    {
        stopPanel.SetActive(false);
        Time.timeScale = PlayerPrefs.GetFloat("SpeedRate");
        source.pitch = PlayerPrefs.GetFloat("SpeedRate");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackTitle()
    {
        SceneManager.LoadScene(0);
    }
}
