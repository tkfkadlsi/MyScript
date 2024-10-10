using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Song1Button : MonoBehaviour
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
        SceneManager.LoadScene(4);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.DOColor(new Color(0.4f, 0.8f, 0.4f), 0.25f);
        song.time = 1f;
        StopCoroutine("VolDown");
        StartCoroutine("VolUp");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.DOColor(new Color(0.6f, 1f, 0.6f), 0.25f);
        StopCoroutine("VolUp");
        StartCoroutine("VolDown");
    }

    IEnumerator VolUp()
    {
        startSong.volume = 0;
        song.volume = 0;
        song.Play();

        for (float i = song.volume; i < 0.5; i += Time.deltaTime)
        {
            song.volume = i;
            yield return null;
        }
    }

    IEnumerator VolDown()
    {
        startSong.volume = 0.5f;
        for (float i = song.volume; i > 0; i -= Time.deltaTime)
        {
            song.volume = i;
            yield return null;
        }

        song.Stop();
    }
}
