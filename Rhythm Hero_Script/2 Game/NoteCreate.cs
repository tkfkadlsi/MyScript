using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCreate : MonoBehaviour
{
    [SerializeField] private RectTransform attackGear;
    [SerializeField] private RectTransform defendGear;

    [SerializeField] private SongEnd songEnd;
    [SerializeField] private BossPatern bossPatern;

    AudioSource audioSource;
    AudioClip song;

    int stage;

    private void Awake()
    {
        stage = Information.instance.Stage;
        audioSource = GetComponent<AudioSource>();
    }

    string[] lines;
    float bpm;
    float offset;
    float plusOffset;
    float unitTime;
    float noteSpeed;

    public void GameStart()
    {
        lines = GameManager.instance.notefile.text.Split('\n');
        bpm = GameManager.instance.bpm;
        offset = GameManager.instance.offset;
        plusOffset = GameManager.instance.plusOffset;
        noteSpeed = Information.instance._noteSpeed;

        song = GameManager.instance.song;

        switch (Information.instance.Stage)
        {
            case 0:
                bpm = 110;
                offset = (770f + (int)plusOffset) / 1000f;
                unitTime = 60f / (bpm * 2);
                break;
            case 1:
                bpm = 177;
                offset = (2260f + (int)plusOffset) / 1000f;
                unitTime = 60f / bpm;
                break;
            case 2:
                bpm = 118;
                offset = (2570f + (int)plusOffset) / 1000f;
                unitTime = 60f / (bpm * 2);
                break;
            case 3:
                bpm = 200;
                offset = (530f + (int)plusOffset) / 1000f;
                unitTime = 60f / (bpm * 2);
                break;
            case 4:
                bpm = 234.5f;
                offset = (760f + (int)plusOffset) / 1000f;
                unitTime = 60 / (bpm * 2);
                break;
            case 5:
                bpm = 220;
                offset = (520f + (int)plusOffset) / 1000f;
                unitTime = 60 / (bpm * 4);
                bossPatern.CallBossStage();
                break;
        }

        audioSource.PlayOneShot(song);
        songEnd.SongStart();
        Invoke("SongStart", offset);
    }


    public void SongStart()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(' ');

            int dir = int.Parse(line[0]);
            int bit = int.Parse(line[1]);

            if (stage == 5 && i+1 >= 198)
                bit -= 8;

            noteSelected((State)dir, bit);
        }
    }


    public void noteSelected(State dt, int bit)
    {

        switch (dt)
        {
            case State.attack:
                Invoke("CreateAttackNote", unitTime * bit);
                break;
            case State.defend:
                Invoke("CreateDefendNote", unitTime * bit);
                break;
        }
    }

    void CreateAttackNote()
    {
        GameObject note = GameManager.instance.GetNote();
        note.tag = "AttackNote";
        Image image = note.GetComponent<Image>();
        RectTransform rect = note.GetComponent<RectTransform>();
        note.transform.SetParent(attackGear);
        image.color = Information.instance._attackNoteColor;
        rect.anchoredPosition = new Vector2(attackGear.anchoredPosition.x, attackGear.anchoredPosition.y + 800);
    }


    void CreateDefendNote()
    {
        GameObject note = GameManager.instance.GetNote();
        note.tag = "DefendNote";
        Image image = note.GetComponent<Image>();
        RectTransform rect = note.GetComponent<RectTransform>();
        note.transform.SetParent(defendGear);
        image.color = Information.instance._defendNoteColor;
        rect.anchoredPosition = new Vector2(defendGear.anchoredPosition.x, defendGear.anchoredPosition.y + 800);
    }
}
