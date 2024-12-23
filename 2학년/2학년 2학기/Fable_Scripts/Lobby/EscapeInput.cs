using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EscapeInput : MonoBehaviour
{
    [SerializeField] private GameObject escapePanelObject;
    private RectTransform escapePanel;
    private bool isChange;
    private void Start()
    {
        escapePanel = escapePanelObject.GetComponent<RectTransform>();
        escapePanelObject.SetActive(false);
        escapePanel.localScale = Vector3.zero;
        isChange = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPanel();
        }
    }

    private void OnPanel()
    {
        if (isChange) return;

        isChange = true;
        escapePanel.gameObject.SetActive(true);
        escapePanel.DOScale(1f, 0.5f).OnComplete(()=>
        {
            isChange = false;
        });
    }

    private void OffPanel()
    {
        if (isChange) return;

        isChange = true;
        escapePanel.DOScale(0f, 0.5f).OnComplete(() =>
        {
            escapePanel.gameObject.SetActive(false);
            isChange = false;
        });
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        OffPanel();
    }
}
