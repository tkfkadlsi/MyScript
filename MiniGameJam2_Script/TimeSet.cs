using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class TimeSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI FinishText;
    [SerializeField] private GameObject FinishButton;
    float time;

    private void Start()
    {
        FinishButton.SetActive(false);
        time = 100;
    }

    private void Update()
    {
        if(time < 0)
        {
            GameFin();
            return;
        }

        time -= Time.deltaTime;
        timeText.text = $"Time : {TimeSpan.FromSeconds(time).ToString("mm\\:ss\\.ff")}";
    }

    private void GameFin()
    {
        Height height = this.GetComponent<Height>();

        Cursor.lockState = CursorLockMode.None;

        string hstr = height.highHeight.ToString("0.00");
        FinishText.text = $"시간 종료! 최고높이 : {hstr}m";
        FinishButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
