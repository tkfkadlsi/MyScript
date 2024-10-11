using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;

    public void OpenPanel()
    {
        optionPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        optionPanel.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
