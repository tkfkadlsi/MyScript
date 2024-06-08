using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Note : MonoBehaviour
{
    public NoteData noteData;

    private RectTransform rect;
    private float noteSpeed = 600f;
    public int Tone;
    private GameObject sharp;
    private Judgement judgement;
    private GameSetter gameSetter;

    private void Awake()
    {
        judgement = FindObjectOfType<Judgement>();
        rect = this.GetComponent<RectTransform>();
        rect.anchoredPosition3D = Vector3.zero;
        rect.localScale = new Vector3(1, 1, 1);

        if (tag != "Note") return;

        sharp = GetComponentInChildren<SpriteRenderer>().gameObject;
        sharp.SetActive(false);
    }

    private void OnEnable()
    {
        gameSetter = FindObjectOfType<GameSetter>();
        rect.localScale = new Vector3(-1, 1, 1);
    }

    public void Set_Y(ToneY toneY)
    {
        if (tag != "Note")
        {
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -60);
            return;
        }
        float y = toneY.y;

        if(y >= -15)
        {
            rect.localScale = new Vector3(1, -1, 1);
            y += 30f;
        }
        else
        {
            rect.localScale = new Vector3(-1, 1, 1);
        }

        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, y);


        if (toneY.isSharp)
            sharp.SetActive(true);
        else
            sharp.SetActive(false);
    }

    private void Update()
    {
        if (rect.anchoredPosition.x <= -1200)
        {
            if (gameSetter != null)
                gameSetter.resultCount.Miss++;
            Release();
            return;
        }
        rect.anchoredPosition += new Vector2(-noteSpeed * Time.deltaTime, 0);

        //if (tag != "Note") return;
        //if(rect.anchoredPosition.x <= -600)
        //{
        //    judgement.Judge();
        //}
    }

    public void Release()
    {
        PoolManager.Instance.ReturnObject(noteData.NoteType, gameObject);
    }
}
