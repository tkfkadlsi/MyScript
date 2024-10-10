using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject exitPanel;

    private void Awake()
    {
        exitPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NoExit()
    {
        exitPanel.SetActive(false);
    }

    public void CallExitPanel()
    {
        exitPanel.SetActive(true);
    }
}
