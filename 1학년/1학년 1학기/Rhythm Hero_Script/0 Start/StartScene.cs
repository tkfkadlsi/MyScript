using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartScene : MonoBehaviour
{
    [SerializeField] private GameObject titleText;
    [SerializeField] private GameObject text_1;
    [SerializeField] private Image barrier;

    [SerializeField] private AudioClip GX;

    Transform cameraTrm;
    AudioSource audioSource;

    bool nextScene = false;

    private void Awake()
    {
        int w = Screen.width;

        int h = (w * 9) / 16;

        Screen.SetResolution(w, h, true);

        cameraTrm = gameObject.GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        titleText.SetActive(false);
        text_1.SetActive(false);
    }

    private void Start()
    {
        audioSource.PlayOneShot(GX);
        barrier.DOColor(new Color(1, 1, 1, 1), 2).SetEase(Ease.Linear);
        cameraTrm.DOMove(new Vector3(0, 8, -10), 2.5f).SetEase(Ease.OutSine).OnComplete(()=> 
        {
            StartCoroutine(FinishMove());
        });
    }

    private void Update()
    {
        if(nextScene == true)
        {
            if (Input.anyKeyDown)
            {
                nextScene = false;
                NextScene();
            }
        }
    }

    IEnumerator FinishMove()
    {
        titleText.SetActive(true);
        yield return new WaitForSeconds(1);

        barrier.DOColor(new Color(1, 1, 1, 0), 0.25f);

        yield return new WaitForSeconds(1f);
        text_1.SetActive(true);
        StartCoroutine(ListenStart());
    }

    IEnumerator ListenStart()
    {
        nextScene = true;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (text_1.activeSelf == true)
                text_1.SetActive(false);
            else
                text_1.SetActive(true);
        }
    }

    void NextScene()
    {
        barrier.DOColor(new Color(1, 1, 1, 1), 1.5f).OnComplete(()=> 
        {
            SceneManager.LoadScene(1);
        });
    }
}
