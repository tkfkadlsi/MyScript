using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class OptionButton : MonoBehaviour
      , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private StartButton startButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.DOColor(new Color(1, 0, 0), 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.DOColor(new Color(1, 1, 1), 0.25f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        optionPanel.SetActive(true);
        startButton.isOption = true;
    }
}
