using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Select select;
    [SerializeField] private GameObject TutorialPanel;

    public void TutorialStart()
    {
        Information.instance.Stage = 0;
        SceneManager.LoadScene(2);
    }

    public void TutorialNo()
    {
        TutorialPanel.SetActive(false);
        select.isAction = false;
    }
}
