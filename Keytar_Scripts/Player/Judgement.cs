using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Judgement : MonoBehaviour
{
    [SerializeField] private Sound sound;
    [SerializeField] private SoundEnergy soundEnergy;
    [SerializeField] private RectTransform judgeLine;
    [SerializeField] private JudgeText judgeText;
    [SerializeField] private string targetTag;

    private GameSetter gameSetter;
    private float ms = 0.6f;

    private void Awake()
    {
        gameSetter = FindObjectOfType<GameSetter>();
        judgeLine.anchoredPosition = new Vector2(-600, 0);
    }

    public bool Judge()
    {
        if (gameSetter == null) gameSetter = FindObjectOfType<GameSetter>();
        GameObject[] notes = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closetObject = null;

        float closetDistance = Mathf.Infinity;

        foreach (GameObject note in notes)
        {
            RectTransform noteRect = note.GetComponent<RectTransform>();
            float distance = Mathf.Abs(noteRect.anchoredPosition.x - judgeLine.anchoredPosition.x);

            if (closetDistance > distance)
            {
                closetDistance = distance;
                closetObject = note;
            }
        }

        if (closetObject == null) return false;

        RectTransform closetRect = closetObject.GetComponent<RectTransform>();
        float n = Mathf.Abs(judgeLine.anchoredPosition.x - closetRect.anchoredPosition.x);

        if (n <= 220 * ms)
        {
            if (gameSetter != null)
                gameSetter.resultCount.Play++;
            ReturnNote(closetObject);
            judgeText.Text();
            return true;
        }
        else if (n <= 280 * ms)
        {
            if(Information.Instance.Language == "한국어")
                judgeText.Text("잘못된 입력!");
            else if(Information.Instance.Language == "English")
                judgeText.Text("Wrong input!");

            return false;
        }
        else if (n <= 1500)
        {
            if (Information.Instance.Language == "한국어")
                judgeText.Text("연타는 나빠요!");
            else if (Information.Instance.Language == "English")
                judgeText.Text("Repeated hitting is bad!");

            MissNote(closetObject);
            return false;
        }
        else
        {
            return false;
        }
    }

    public void ReturnNote(GameObject note)
    {
        Note noteScript = note.GetComponent<Note>();
        sound.SoundPlay(Information.Instance.CurrentInst.clips[noteScript.Tone - 1]);
        soundEnergy.SoundEnergyUp(4f);
        noteScript.Release();
    }

    private void MissNote(GameObject note)
    {
        if (gameSetter != null)
            gameSetter.resultCount.Miss++;
        Note noteScript = note.GetComponent<Note>();
        noteScript.Release();
    }
}
