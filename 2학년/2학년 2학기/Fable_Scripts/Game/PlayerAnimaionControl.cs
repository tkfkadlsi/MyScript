using System.Collections;
using UnityEngine;

public class PlayerAnimaionControl : MonoBehaviour
{
    [SerializeField] private Animator fableAnim;
    [SerializeField] private Animator rabbitAnim;

    private RhythmGameManager gameManager;
    private bool beforeIsRunning = false;
    private void Start()
    {
        gameManager = FindObjectOfType<RhythmGameManager>();
        gameManager.GameStartEvent += GameStart;
        gameManager.GameStopEvent += GameStop;

        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            fableAnim.speed = Information.Instance.currentSong.SongBPM / 120f;
        }
        else
        {
            fableAnim.speed = Information.Instance.currentSong.SongBPM / 60f;
        }
    }
    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.GameStartEvent -= GameStart;
            gameManager.GameStopEvent -= GameStop;
        }
    }

    public void GameStart()
    {
        fableAnim.SetBool("IsGaming", true);
        rabbitAnim.SetBool("IsGaming", true);
    }

    public void GameStop()
    {
        fableAnim.SetBool("IsGaming", false);
        rabbitAnim.SetBool("IsGaming", false);
    }

    public void Event()
    {
        fableAnim.SetTrigger($"Event{Information.Instance.currentSong.SongID}");
        rabbitAnim.SetTrigger($"Event{Information.Instance.currentSong.SongID}");
    }

    public void Running(bool isRunning)
    {
        if (isRunning == beforeIsRunning)
            return;

        beforeIsRunning = isRunning;

        if(Information.Instance.currentDiff != DifficultType.Nightmare)
            return;
        if (ChangeCo != null)
        {
            StopCoroutine(ChangeCo);
        }
        ChangeCo = Walk_RunChange(isRunning);
        StartCoroutine(ChangeCo);
    }

    private IEnumerator ChangeCo;

    private IEnumerator Walk_RunChange(bool isToRun)
    {
        float t = 0f;
        float lerpTime = 0.5f;

        float start = isToRun ? 0f : 1f;
        float end = isToRun ? 1f : 0f;

        while (t < lerpTime)
        {
            t += Time.deltaTime;
            yield return null;

            fableAnim.SetFloat("Blend", Mathf.Lerp(start, end, t / lerpTime));
        }
    }
}
