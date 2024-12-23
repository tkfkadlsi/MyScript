using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmGameManager : MonoBehaviour
{
    [HideInInspector] public AudioSource BGMSource;
    [SerializeField] private PlayerInput player;
    [SerializeField] private Image blindImage;
    [SerializeField] private Image countDownImage;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject noTouchzone;

    private EndEvent EndEvent;

    public bool isSongPlaying = false;
    public float songTime { get; private set; } = 0f;

    private void Awake()
    {
        BGMSource = GetComponent<AudioSource>();
        countDownImage.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        noTouchzone.SetActive(false);
        blindImage.gameObject.SetActive(true);

    }

    private void Start()
    {
        Application.targetFrameRate = Information.Instance.InGameFrame;
        StartCoroutine(SongStart());
        Information.Instance.dream = 0;
        Information.Instance.cool = 0;
        Information.Instance.bed = 0;
        Information.Instance.awake = 0;
    }

    private void Update()
    {
        if (isSongPlaying)
            songTime += Time.deltaTime;
    }

    public IEnumerator SongStart()
    {
        float offset = Information.Instance.offset / 1000f;
        //offset += 5f / 1000f;
        GameObject backGround;
        if (Information.Instance.currentDiff == DifficultType.Fairy)
        {
            backGround = Information.Instance.currentSong.Fairytale_Map;
        }
        else if (Information.Instance.currentDiff == DifficultType.Dream)
        {
            backGround = Information.Instance.currentSong.Dream_Map;
        }
        else
        {
            backGround = Information.Instance.currentSong.Nightmare_Map;
        }

        if (backGround != null && !Information.Instance.IsLowDetailMode)
        {
            GameObject obj = Instantiate(backGround, new Vector3(0, -15, 0), Quaternion.identity);
        }

        BGMSource.clip = Information.Instance.currentSong.AudioFile;

        blindImage.DOColor(Color.clear, 0.5f).OnComplete(() =>
        {
            blindImage.gameObject.SetActive(false);
        });

        if (offset == 0)
        {
            yield return new WaitForSeconds(1); // 걍 오프셋 0인데 뭔소리임.
            GameStartEvent?.Invoke();
            BGMSource.Play();
            isSongPlaying = true;
        }
        else if (offset > 0)
        {
            yield return new WaitForSeconds(1 - offset); // 페이블 먼저 움직이고 offset 만큼 후에 곡 재생
            GameStartEvent?.Invoke();
            yield return new WaitForSeconds(offset);
            BGMSource.Play();
            isSongPlaying = true;
        }
        else if (offset < 0)
        {
            yield return new WaitForSeconds(1 + offset); // 곡 먼저 재생하고 offset만큼 후에 움직이기
            BGMSource.Play();
            isSongPlaying = true;
            yield return new WaitForSeconds(offset * -1);
            GameStartEvent?.Invoke();
        }
    }

    public void SongPause()
    {
        Time.timeScale = 0;
        BGMSource.pitch = 0;
        pausePanel.SetActive(true);
        noTouchzone.SetActive(true);
    }

    public void SongResume()
    {
        pausePanel.SetActive(false);
        noTouchzone.SetActive(false);
        countDownImage.gameObject.SetActive(true);
    }

    public void SongRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("RhythmGame");
    }

    public void GoLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }

    public void DiePlayer()
    {
        GameStopEvent?.Invoke();
        blindImage.gameObject.SetActive(true);
        blindImage.DOColor(Color.black, 1f).OnComplete(() =>
        {
            SceneManager.LoadScene("Failed");
        });

    }

    public void GameClear()
    {
        StartCoroutine(GameClearCoroutine());
    }

    private IEnumerator GameClearCoroutine()
    {
        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            yield return new WaitForSeconds(30f / Information.Instance.currentSong.SongBPM);
        }
        else
        {
            yield return new WaitForSeconds(15f / Information.Instance.currentSong.SongBPM);
        }

        GameStopEvent?.Invoke();
        FindObjectOfType<CamManager>().isEnd = true;

        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            EndEvent = GetComponent<EndEvent>();
            EndEvent.EndEventHandle();
        }
        else
        {
            GoResultScene();
        }
    }

    public void GoResultScene()
    {
        blindImage.gameObject.SetActive(true);
        blindImage.DOColor(Color.white, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadScene("Result");
            //int songStageLevel = Information.Instance.currentSong.SongID;
            //bool isDreamClear = Information.Instance.GameData.IsDreamClear[songStageLevel];
            //bool isNightClear = Information.Instance.GameData.IsNightClear[songStageLevel];

            //if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
            //{
            //    if (isDreamClear)
            //    {
            //        // result Scene
            //        SceneManager.LoadScene("Result");
            //    }
            //    else
            //    {
            //        // production Scene
            //        SceneManager.LoadScene("Production");
            //    }
            //}
            //else
            //{
            //    SceneManager.LoadScene("Result");
            //}
        });
    }

    public event Action GameStartEvent;
    public event Action GameStopEvent;
}
