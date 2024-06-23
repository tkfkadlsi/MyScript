using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Queue<JobMethod> JobQ = new Queue<JobMethod>();

    public NoteManager NoteManager;
    public TimingManager TimingManager;
    public GamePlayerInput GamePlayerInput;
    public GameUI GameUI;
    public GameEnd GameEnd;
    public SFXPlayer SFXPlayer;
    public DisplayHitEffect HitEffectPool;

    public SongSO PlayingSong { get; private set; }

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private UINavigation startUI;
    [SerializeField] private UINavigation emptyUI;
    [SerializeField] private TextMeshProUGUI remuseCountTMP;
    [SerializeField] private SpriteRenderer backGroundSprite;

    public float SongTime { get; private set; }
    public float Eight_beatTime;
    private bool isStart;
    private bool isPlaying;
    private int offset = 0;

    public int noteCount;
    public int bellNoteCount;

    private AudioSource bgmSource;

    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
        set
        {
            isPlaying = value;
        }
    }
    private void Awake()
    {
        Instance = this;
        IsPlaying = false;
        TimerReset();
        noteCount = 0;
        bellNoteCount = 0;
        bgmSource = GetComponent<AudioSource>();

        pausePanel.SetActive(false);
        UINavigation.ChangeFocus(startUI);
    }

    private void Start()
    {
        Information.Instance.Result = new Result();
        PlayingSong = Information.Instance.SongDictionary[Information.Instance.CurrentSong];
        IsPlaying = true;
        offset = Information.Instance.OptionData.SoundOffset;
        if(Information.Instance.CurrentSong == SongTitle.Aurelia)
        {
            offset -= 20;
        }
        backGroundSprite.sprite = Information.Instance.SongDictionary[Information.Instance.CurrentSong].thumbnail;
        switch (Information.Instance.DiffcultType)
        {
            case DiffcultType.Travel:
                NoteManager.CreateNotes(PlayingSong.Travel);
                break;
            case DiffcultType.Adventure:
                NoteManager.CreateNotes(PlayingSong.Adventure);
                break;
            case DiffcultType.Special:
                NoteManager.CreateNotes(PlayingSong.Special);
                break;
        }
        NoteManager.CreateBellNote(PlayingSong.Bell);
        TimingManager.SetTiming(PlayingSong.Timing);
        bgmSource.clip = PlayingSong.Songfile;
        for (int i = 0; i < 4; i++)
        {
            foreach (Note note in NoteManager.noteList[i])
            {
                if (note.isLong)
                    noteCount += 2;
                else
                    noteCount += 1;
            }
        }
        foreach (List<NoteBell> bellNoteList in NoteManager.bellNoteList)
        {
            bellNoteCount += bellNoteList.Count;
        }
    }

    private void Update()
    {
        while (JobQ.Count > 0)
        {
            JobMethod job = JobQ.Dequeue();
            switch (job.MethodType)
            {
                case JobMethodType.SongStart:
                    SongStart();
                    break;
                case JobMethodType.Judgement:
                    GameUI.DisplayJudgement(job.Judgement);
                    break;
                case JobMethodType.DisPlayFastSlow:
                    GameUI.DisplayFastSlow(job.IsFast);
                    break;
                case JobMethodType.DisplayCombo:
                    GameUI.DisplayCombo();
                    break;
                case JobMethodType.DisplayBellScore:
                    GameUI.DisplayBellScore();
                    break;
                case JobMethodType.GameEnd:
                    GameEnd.End();
                    break;
            }
        }
    }

    public void SongStart()
    {
        bgmSource.Play();
    }

    public void SongPause()
    {
        bgmSource.Pause();
        IsPlaying = false;
        GamePlayerInput.isInputOK = false;
        pausePanel.SetActive(true);
    }

    public void SongResume()
    {
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(emptyUI);
        pausePanel.SetActive(false);
        StartCoroutine(SongRemuseCoroutine());
    }

    private IEnumerator SongRemuseCoroutine()
    {
        for (int i = 3; i > 0; i--)
        {
            remuseCountTMP.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        remuseCountTMP.text = "";

        bgmSource.Play();
        IsPlaying = true;
        GamePlayerInput.isInputOK = true;
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(startUI);
    }

    public void SongRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoLobby()
    {
        SceneManager.LoadScene("1_Selection");
    }

    public void BlockUIControl()
    {
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(emptyUI);
    }

    private void TimerReset()
    {
        SongTime = -3000;
    }


    private void FixedUpdate()
    {
        if (IsPlaying)
        {
            SongTime += Time.fixedDeltaTime * 1000f;
            if (!isStart && SongTime >= -50 + offset)
            {
                isStart = true;
                SongStart();
            }
            TimingManager.ChangeBPM();
        }
    }

    public Note GetNote(int Line)
    {
        if (NoteManager.noteList[Line].Count > 0)
            return NoteManager.noteList[Line][0];
        else
            return null;
    }
}