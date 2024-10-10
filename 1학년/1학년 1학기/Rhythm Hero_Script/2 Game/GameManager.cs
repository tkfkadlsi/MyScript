using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.IO;

public enum State
{
    attack = 1,
    defend = 2
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Image StageStartPanel;
    [SerializeField] private TextMeshProUGUI StartStageText;

    [SerializeField] private NoteCreate noteCreate;
    [SerializeField] private Enemy enemy;

    [SerializeField] private GameObject notePrefab;

    [SerializeField] private TutorialText tutorialText;

    [SerializeField] private SongEnd songEnd;

    public bool isPause;

    Queue<GameObject> notePool = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;
        isPause = false;

        for (int i = 0; i < 30; i++)
        {
            notePool.Enqueue(CreateNote());
        }

        StartStage();
    }

    private void StartStage()
    {
        if (Information.instance.Stage == 0)
            StartStageText.text = "New Start";
        else if (Information.instance.Stage == 1)
            StartStageText.text = "Smooooch A";
        else if (Information.instance.Stage == 2)
            StartStageText.text = "Back In My Days";
        else if (Information.instance.Stage == 3)
            StartStageText.text = "In 59 second";
        else if (Information.instance.Stage == 4)
            StartStageText.text = "Freedom Dive (T+pazolite remix)";
        else if (Information.instance.Stage == 5)
            StartStageText.text = "Secret Boss";

        StageStartPanel.DOColor(new Color(1, 1, 1, 1), 1);
        StartStageText.DOColor(new Color(1, 1, 1, 1), 1).OnComplete(() =>
        {
            StageStartPanel.DOColor(new Color(1, 1, 1, 0), 1);
            StartStageText.DOColor(new Color(1, 1, 1, 0), 1).OnComplete(() =>
            {
                StartGame();
            });
        });
    }



    public int stage;
    public float bpm;
    public float offset;
    public float plusOffset;
    public float noteSpeed;

    public Sprite enemySprite;
    public AudioClip song;
    public TextAsset notefile;

    void StartGame()
    {
        int stage = Information.instance.Stage;
        switch (stage)
        {
            case 0:

                notefile = Resources.Load<TextAsset>("NoteFile/TutorialNoteFile");
                enemySprite = Resources.Load<Sprite>("EnemySprite/wolf-white");
                song = Resources.Load<AudioClip>("Songs/NewStart");

                StartStageText.text = "New Start";

                bpm = 110;
                offset = 1100;
                plusOffset = Information.instance._plusOffset;
                noteSpeed = Information.instance._noteSpeed;

                tutorialText.GameStart();
                break;
            case 1:

                notefile = Resources.Load<TextAsset>("NoteFile/SmoooochNoteFile");
                enemySprite = Resources.Load<Sprite>("EnemySprite/Cat-2-Idle");
                song = Resources.Load<AudioClip>("Songs/Smooooch");

                StartStageText.text = "smooooch A";

                bpm = 177;
                plusOffset = Information.instance._plusOffset;
                noteSpeed = Information.instance._noteSpeed;
                break;
            case 2:
                notefile = Resources.Load<TextAsset>("NoteFile/BackInMyDaysNoteFile");
                enemySprite = Resources.Load<Sprite>("EnemySprite/Slime");
                song = Resources.Load<AudioClip>("Songs/BackInMyDays");

                StartStageText.text = "Back In My Days";

                bpm = 118;
                plusOffset = Information.instance._plusOffset;
                noteSpeed = Information.instance._noteSpeed;

                break;
            case 3:
                notefile = Resources.Load<TextAsset>("NoteFile/JangSongNoteFile");
                enemySprite = Resources.Load<Sprite>("EnemySprite/rat-brown");
                song = Resources.Load<AudioClip>("Songs/JangSong");

                bpm = 200;
                plusOffset = Information.instance._plusOffset;
                noteSpeed = Information.instance._noteSpeed;
                break;
            case 4:
                notefile = Resources.Load<TextAsset>("NoteFile/FreedomDiveNoteFile");
                enemySprite = Resources.Load<Sprite>("EnemySprite/Idle");
                song = Resources.Load<AudioClip>("Songs/FreedomDive");

                StartStageText.text = "Freedom Dive (T+pazolite remix)";

                bpm = 234.5f;
                plusOffset = Information.instance._plusOffset;
                noteSpeed = Information.instance._noteSpeed;
                break;
            case 5:
                notefile = Resources.Load<TextAsset>("NoteFile/SecretBossNoteFile");
                enemySprite = Resources.Load<Sprite>("EnemySprite/Boss");
                song = Resources.Load<AudioClip>("Songs/SecretBoss");

                bpm = 220;
                plusOffset = Information.instance._plusOffset;
                noteSpeed = Information.instance._noteSpeed;
                break;
        }

        songEnd.GameStart();
        noteCreate.GameStart();
        enemy.SongStart();
    }

    GameObject CreateNote()
    {
        GameObject newObj = Instantiate(notePrefab);
        newObj.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }


    public GameObject GetNote()
    {
        if (notePool.Count > 0)
        {
            GameObject outObj = notePool.Dequeue();
            outObj.SetActive(true);
            return outObj;
        }
        else
        {
            GameObject outObj = CreateNote();
            outObj.SetActive(true);
            return outObj;
        }
    }


    public void DelNote(GameObject inObj)
    {
        inObj.SetActive(false);
        inObj.transform.SetParent(transform);
        notePool.Enqueue(inObj);
    }
}