using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Adventure : MonoBehaviour
{
    [SerializeField] private GameObject adventurePanel;
    [SerializeField] private GameObject adventureSelectPanel;
    [SerializeField] private Select select;


    KeyCode escape = KeyCode.Escape;


    private void Awake()
    {
        adventureSelectPanel.SetActive(false);
    }

    public void GoAdventure()
    {
        adventurePanel.SetActive(false);
        adventureSelectPanel.SetActive(true);
    }

    public void NoAdventure()
    {
        adventurePanel.SetActive(false);
        select.isAction = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(escape))
        {
            adventureSelectPanel.SetActive(false);
            select.isAction = false;
        }
    }
}
