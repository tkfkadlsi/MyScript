using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject escapePanel;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        escapePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escapePanel.activeSelf == false)
            {
                escapePanel.SetActive(true);
                GameManager.instance.isPause = true;
                Time.timeScale = 0;
                audioSource.pitch = 0;
            }
            else
            {
                escapePanel.SetActive(false);
                GameManager.instance.isPause = false;
                Time.timeScale = 1;
                audioSource.pitch = 1;
            }
        }
    }


    public void Escape()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Remuse()
    {
        escapePanel.SetActive(false);
        GameManager.instance.isPause = false;
        Time.timeScale = 1;
        audioSource.pitch = 1;
    }
}
