using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HiddenSongButton : MonoBehaviour
    , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image image;
    AudioSource song;
    public AudioSource startSong;

    private void Awake()
    {
        image = GetComponent<Image>();
        song = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(5);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.DOColor(new Color(0.6f, 0.3f, 0.8f), 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.DOColor(new Color(0.8f, 0.5f, 1f), 0.25f);
    }
}
