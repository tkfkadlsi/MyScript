using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbySceneUI : MonoBehaviour
{
    public HighScorePanel highScorePanel;
    [SerializeField] private KeyGuidePanel keyGuidePanel;
    [SerializeField] private TextMeshProUGUI interectionText;

    bool keyGuide;

    private void Update()
    {
        InputUI();
    }

    private void InputUI()
    {
        if (Input.GetKeyDown(Information.Instance.currentKeyList[7].Code))
        {
            if (keyGuide)
            {
                keyGuide = false;
                keyGuidePanel.UpPanel();
            }
            else
            {
                keyGuide = true;
                keyGuidePanel.DownPanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (keyGuide)
            {
                keyGuide = false;
                keyGuidePanel.UpPanel();
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void SetInterectionText(string text)
    {
        interectionText.text = text;
    }
}
