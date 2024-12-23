using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public event Action SelectIsland;
    public event Action UnSelectIsland;
    public event Action DragEvent;

    public List<AudioClip> LobbySFXs = new List<AudioClip>();

    public SelectType SelectType;
    public CamDrag CamDrag;
    public SetCamPosition SetCamPosition;
    //public LobbyUIMove LobbyUIMove;
    public RhythmUI RhythmGamePanel;
    public AudioSource LobbyAudioSource;
    public AudioSource LobbySFXSource;
    public GoGameScene LobbyGO;
    public ItemPanel ItemPanel;

    public static LobbyManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SelectType = SelectType.NoSelect;
    }

    private void Update()
    {
    }   

    private void Start()
    {
        Information.Instance.ScreenHalfWidth = Screen.width / 2;
    }

    public void PlaySFX(int i)
    {
        //LobbySFXSource.PlayOneShot(LobbySFXs[i]);
    }

    public void Selecting(int id)
    {
        SelectType = SelectType.Select;
        SelectIsland?.Invoke();
        CamDrag.enabled = false;
        Information.Instance.currentSong = Information.Instance.SongList[id];
        MainUI.Instance.SelectIsland();
    }

    public void SongPlay()
    {
        Song playingSong = Information.Instance.currentSong;
        LobbyAudioSource.clip = playingSong.AudioFile;
        LobbyAudioSource.time = playingSong.Highlight;
        LobbyAudioSource.Play();
        DragEvent?.Invoke();
    }

    public void UnSelect()
    {
        UnSelectIsland?.Invoke();
        CamDrag.enabled = true;
        SelectType = SelectType.NoSelect;
    }

    public void GameStart()
    {
        if(!ItemPanel.isCanPay)
        {
            return;
        }
        SelectType = SelectType.EnterGame;
        StartCoroutine(LobbyGO.GameScene());
    }
}
