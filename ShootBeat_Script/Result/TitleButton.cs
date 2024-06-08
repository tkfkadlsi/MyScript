using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.DOColor(new Color(0.45f, 0.7f, 0.65f), 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.DOColor(new Color(0.65f, 0.9f, 0.85f), 0.25f);
    }
}
