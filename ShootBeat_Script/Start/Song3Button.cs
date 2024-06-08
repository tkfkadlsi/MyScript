using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Song3Button : MonoBehaviour
    , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image image;
    AudioSource song;
    public AudioSource startSong;

    [SerializeField] private GameObject HiddenSongPanel;
    [SerializeField] private GameObject Song1Panel;
    [SerializeField] private GameObject Song2Panel;

    [SerializeField] private Image arrow;

    [SerializeField] private RectTransform divePanel;

    [SerializeField] private AudioClip freedomDive;
    [SerializeField] private AudioClip startClip;

    KeyCode hiddenKey = KeyCode.DownArrow;

    int hiddenCount;

    bool isHidden = false;

    private void Awake()
    {
        image = GetComponent<Image>();
        song = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        isHidden = false;
        hiddenCount = 0;
        arrow.color = new Color(1, 0, 0);
        divePanel.anchoredPosition = new Vector2(0, 1400);
        HiddenSongPanel.SetActive(false);
        Song1Panel.SetActive(true);
        Song2Panel.SetActive(true);
    }

    void Update()
    {
        if(isHidden == false)
        {
            if (Input.GetKeyDown(hiddenKey))
            {
                hiddenCount++;
                ArrowDown();
            }
            if(hiddenCount >= 10)
            {
                isHidden = true;
                DOTween.Kill(this);
                OnHidden();
                HiddenSongPanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }


    void ArrowDown()
    {
        arrow.color = new Color(arrow.color.r, arrow.color.g + 0.1f, arrow.color.b + 0.1f);
    }

    void OnHidden()
    {
        Song1Panel.SetActive(false);
        Song2Panel.SetActive(false);
        arrow.color = new Color(1, 1, 1);
        arrow.DOColor(new Color(0, 1, 0), 1f);
        divePanel.DOAnchorPos(new Vector2(0, -1400), 1);
        startSong.Stop();
        startSong.clip = freedomDive;
        startSong.time = 65;
        startSong.volume = 0.5f;
        startSong.Play();
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(2);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.DOColor(new Color(0.8f, 0.3f, 0.3f), 0.25f);
        song.time = 0f;
        StopCoroutine("VolDown");
        StartCoroutine("VolUp");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.DOColor(new Color(1f, 0.5f, 0.5f), 0.25f);
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
