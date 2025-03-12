using UnityEngine;
using System.Collections;
using System;

public enum TouchState
{
    Began,
    Moved,
    Stationary,
    None
}

public class PlayerInput : MonoBehaviour
{
    Information infomation;
    Transform trm;
    public RhythmGameManager rhythmManager;
    public JudgeSystem judgeSystem;
    public PlayerDie playerDie;
    public NoteQueue noteQ;
    public GameItemText gameItemText;
    public event Action<Vector3> Setting;

    private readonly float correctTime = 0.067f;

    [Header("SongBPM")]
    [SerializeField]
    int bpm;

    [Header("Player")]
    public float moveSpeed;

    public bool isPlaying = false;
    bool isRotating = false;
    private bool isAndroid = true;

    TouchPhase leftState;
    TouchPhase rightState;
    Touch leftTouch;
    Touch rightTouch;
    int cnt;
    float leftTouchCorrect = 0f;
    float rightTouchCorrect = 0f;

    float x;
    float z;

    private Vector3 lastMousePosition;

    Vector3 endPos;
    [Header("Note")]
    Note currentNote;

    public void SetCurrentNote(Note noteScript)
    {
        currentNote = noteScript;
    }

    private void Awake()
    {
        Debug.Log(isAndroid);

        rhythmManager = FindObjectOfType<RhythmGameManager>().GetComponent<RhythmGameManager>();
        infomation = FindObjectOfType<Information>().GetComponent<Information>();
        judgeSystem = FindObjectOfType<JudgeSystem>();
        playerDie = FindObjectOfType<PlayerDie>();
        noteQ = FindObjectOfType<NoteQueue>();
        gameItemText = FindObjectOfType<GameItemText>();
        trm = transform;
    }
    private void OnEnable()
    {
        rhythmManager.GameStartEvent += StartGame;
        rhythmManager.GameStopEvent += StopGame;
    }
    private void OnDisable()
    {
        rhythmManager.GameStartEvent -= StartGame;
        rhythmManager.GameStopEvent -= StopGame;
    }

    private void StartGame()
    {
        isPlaying = true;
        isAndroid = Information.Instance.IsAndroid();
    }

    private void StopGame()
    {
        isPlaying = false;
    }

    private void Start()
    {
        bpm = infomation.currentSong.SongBPM;

        if (infomation.currentDiff == DifficultType.Dream || infomation.currentDiff == DifficultType.Fairy)
            moveSpeed = bpm / 30f;
        else if (infomation.currentDiff == DifficultType.Nightmare)
            moveSpeed = bpm / 15f;
    }

    private void Update()
    {
        ResetInput();

        PlayerMove();

#if UNITY_EDITOR
        Note note = noteQ.GetNote(0);
        if (0f >= note.noteTiming - rhythmManager.songTime && note is EventNote)
        {
            note.Hit(NoteType.EventNote);
            //note.Hit(NoteType.LeftStep);
            //note.Hit(NoteType.RightStep);
            //note.Hit(NoteType.LeftRotate);
            //note.Hit(NoteType.RightRotate);
        }
#endif

        cnt = Input.touchCount;

        InputProcess();
    }

    private void ResetInput()
    {
        leftTouchCorrect -= Time.deltaTime;
        rightTouchCorrect -= Time.deltaTime;
        leftState = TouchPhase.Canceled;
        rightState = TouchPhase.Canceled;
    }

    private void PlayerMove()
    {
        if (!isPlaying) return;
        if (isRotating)
        {
            endPos += trm.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            trm.position += trm.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void InputProcess()
    {

        Touch nowTouch;


        for (int i = 0; i < cnt; ++i)
        {
            nowTouch = Input.GetTouch(i);

            if (nowTouch.position.x < Information.Instance.ScreenHalfWidth)
            {
                if (leftState != TouchPhase.Canceled)
                    continue;
                //왼쪽 터치가 이미 있다면 무시.
                leftState = nowTouch.phase;
                leftTouch = nowTouch;
            }
            else
            {
                if (rightState != TouchPhase.Canceled)
                    continue;
                //오른쪽 터치가 이미 있다면 무시.
                rightState = nowTouch.phase;
                rightTouch = nowTouch;
            }

        }

        if(isAndroid == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                leftState = TouchPhase.Began;
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                float distance = Input.mousePosition.x - lastMousePosition.x;
                leftTouch.deltaPosition = new Vector2(distance, 0);
                if (Mathf.Abs(distance) >= 15f)
                    leftState = TouchPhase.Moved;
            }

            if (Input.GetMouseButtonDown(1))
            {
                rightState = TouchPhase.Began;
            }
            else if (Input.GetMouseButton(1))
            {
                float distance = Input.mousePosition.x - lastMousePosition.x;
                rightTouch.deltaPosition = new Vector2(distance, 0);
                if (Mathf.Abs(distance) >= 15f)
                    rightState = TouchPhase.Moved;
            }
        }



        if (leftState == TouchPhase.Canceled && rightState == TouchPhase.Canceled)
            return;

        currentNote = noteQ.GetNote(0);

        if (leftState == TouchPhase.Began)
            leftTouchCorrect = correctTime;
        if (rightState == TouchPhase.Began)
            rightTouchCorrect = correctTime;


        //이벤트 처리인지
        if (leftState == TouchPhase.Began && rightTouchCorrect > 0 || rightState == TouchPhase.Began && leftTouchCorrect > 0)
        {
            currentNote.Hit(NoteType.EventNote);
            leftTouchCorrect = 0;
            rightTouchCorrect = 0;
            //return;
        }
        //아니라면 탭 처리인지
        if (leftState == TouchPhase.Began)
        {
            currentNote.Hit(NoteType.LeftStep);
        }
        else if (rightState == TouchPhase.Began)
        {
            currentNote.Hit(NoteType.RightStep);
        }
        //아니라면 로테이트 처리인지
        if (leftState == TouchPhase.Moved/* && leftTouch.deltaTime < 0.1f*/)
        {
            if (leftTouch.deltaPosition.x < -15f)
            {
                currentNote.Hit(NoteType.LeftRotate);
            }
            else if (leftTouch.deltaPosition.x > 15f)
            {
                currentNote.Hit(NoteType.RightRotate);
            }
        }
        else if (rightState == TouchPhase.Moved/* && rightTouch.deltaTime < 0.1f*/)
        {
            if (rightTouch.deltaPosition.x < -15f)
            {
                currentNote.Hit(NoteType.LeftRotate);
            }
            else if (rightTouch.deltaPosition.x > 15f)
            {
                currentNote.Hit(NoteType.RightRotate);
            }
        }
    }

    // 방향 전환.
    public void TagDown(GameObject note, int i)
    {
        Vector3 trmpos = trm.position;
        Vector3 hitPos = note.transform.position;
        // TagDown(hit);

        Setting?.Invoke(transform.position);

        if (trm.rotation == Quaternion.Euler(0, 90, 0))
        {
            z = hitPos.z - trmpos.z;
            x = trmpos.x - hitPos.x;

            if (i > 0)
            {
                i = 180;
                endPos = note.transform.position - new Vector3(z, -0.6f, x);
            }
            else
            {
                i = 0;
                endPos = note.transform.position + new Vector3(z, 0.6f, x);
            }
            trm.rotation = Quaternion.Euler(new Vector3(0, i, 0));
        }
        else if (trm.rotation == Quaternion.Euler(0, -90, 0))
        {

            z = hitPos.z - trmpos.z;
            x = trmpos.x - hitPos.x;

            if (i > 0)
            {
                i = 0;
                endPos = note.transform.position - new Vector3(z, -0.6f, x);
            }
            else
            {
                i = 180;
                endPos = note.transform.position + new Vector3(z, 0.6f, x);
            }
            trm.rotation = Quaternion.Euler(new Vector3(0, i, 0));
        }
        else if (trm.rotation == Quaternion.Euler(0, 0, 0))
        {
            z = hitPos.z - trmpos.z;
            x = hitPos.x - trmpos.x;

            if (i > 0)
            {
                endPos = note.transform.position - new Vector3(z, -0.6f, x);
            }
            else
            {
                endPos = note.transform.position + new Vector3(z, 0.6f, x);
            }

            trm.rotation = Quaternion.Euler(new Vector3(0, i, 0));
        }
        else
        {
            z = trmpos.z - hitPos.z;
            x = hitPos.x - trmpos.x;

            if (i < 0)
            {
                endPos = note.transform.position - new Vector3(z, -0.6f, x);
            }
            else
            {
                endPos = note.transform.position + new Vector3(z, 0.6f, x);
            }

            trm.rotation = Quaternion.Euler(new Vector3(0, -i, 0));
        }
        trm.position = endPos;
        //StartCoroutine(PosReset());
    }

    private IEnumerator PosReset()
    {
        float t = 0f;
        float lerpTime = 0f;
        Vector3 startPos = trm.position;
        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            lerpTime = 30f / Information.Instance.currentSong.SongBPM;
        }
        else
        {
            lerpTime = 15f / Information.Instance.currentSong.SongBPM;
        }

        isRotating = true;
        while (t < lerpTime)
        {
            trm.position = Vector3.Lerp(startPos, endPos, t / lerpTime);
            t += Time.deltaTime;
            yield return null;
        }
        trm.position = endPos;
        isRotating = false;

        endPos = Vector3.zero;
    }


}

