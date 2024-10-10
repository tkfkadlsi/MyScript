using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start2Prologue : MonoBehaviour
{

    private void Awake()
    {
        SetScreen();
    }

    void SetScreen()
    {
        Screen.SetResolution(2560, 1440, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
