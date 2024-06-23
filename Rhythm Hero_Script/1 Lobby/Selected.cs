using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    [SerializeField] private GameObject thisPanel;
    [SerializeField] private Select select;

    KeyCode escape = KeyCode.Escape;

    private void Awake()
    {
        thisPanel.SetActive(false);
    }

    public void SelectThis()
    {
        thisPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(escape))
        {
            thisPanel.SetActive(false);
            select.isAction = false;
        }
    }
}
