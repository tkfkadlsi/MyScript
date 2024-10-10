using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class KeyGuidePanel : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    private RectTransform rect;

    private Vector2 upState = new Vector2(0, 540);
    private Vector2 downState = new Vector2(0, 0);

    private void Awake()
    {
        rect = this.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 540);

        for(int i = 0; i < texts.Count; i++)
        {
            texts[i].text = Information.Instance.currentKeyList[i].Code.ToString();
        }
    }

    public void DownPanel()
    {
        rect.DOAnchorPos(downState, 0.5f);
    }

    public void UpPanel()
    {
        rect.DOAnchorPos(upState, 0.5f);
    }
}