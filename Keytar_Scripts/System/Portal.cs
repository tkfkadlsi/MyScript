using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficult
{
    Tutorial = 1,
    normal = 2,
    hard = 3
}

public class Portal : MonoBehaviour
{
    [SerializeField] private Difficult difficult;

    private SceneChange sceneChange;
    private LobbySceneUI lobbySceneUI;

    private bool isTouch = false;

    private void Awake()
    {
        sceneChange = FindObjectOfType<SceneChange>();
        lobbySceneUI = FindObjectOfType<LobbySceneUI>();
    }

    private void Update()
    {
        Touched();
    }

    public void StageChange()
    {
        Information.Instance.stageDifficult = difficult;
        sceneChange.SceneClose();
    }

    private void Touched()
    {
        if (!isTouch) return;

        if (Input.GetKeyDown(Information.Instance.currentKeyList[6].Code))
        {
            StageChange();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            isTouch = true;

            if(difficult != Difficult.Tutorial)
                lobbySceneUI.highScorePanel.OpenPanel(difficult);

            if (difficult != Difficult.Tutorial)
            {
                if(Information.Instance.Language == "한국어")
                    lobbySceneUI.SetInterectionText($"난이도 : {difficult.ToString()}, {Information.Instance.currentKeyList[6].Code}키를 눌러 시작");
                else if(Information.Instance.Language == "English")
                    lobbySceneUI.SetInterectionText($"Difficult : {difficult.ToString()}, Press {Information.Instance.currentKeyList[6].Code} to Start");
            }
            else
            {
                if(Information.Instance.Language == "한국어")
                    lobbySceneUI.SetInterectionText($"튜토리얼을 {Information.Instance.currentKeyList[6].Code}키를 눌러 시작");
                else if(Information.Instance.Language == "English")
                    lobbySceneUI.SetInterectionText($"Tutorial, Press {Information.Instance.currentKeyList[6].Code} to Start");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            isTouch = false;
            lobbySceneUI.highScorePanel.ClosePanel();
            lobbySceneUI.SetInterectionText("");
        }
    }
}
