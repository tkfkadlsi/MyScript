using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public static Information Instance;

    public string userNickname;

    public PlayerState PlayerState = PlayerState.None;

    public Dictionary<SongTitle, SongSO> SongDictionary = new Dictionary<SongTitle, SongSO>();
    public SongTitle CurrentSong;
    public DiffcultType DiffcultType;

    public GameData GameData = new GameData();
    public OptionData OptionData = new OptionData();

    public Result Result = new Result();
    public PlayerInputs PlayerInputs;

    public List<RankData> AureliaRanking = new List<RankData>();
    public List<RankData> WitchRecordRanking = new List<RankData>();

    public bool IsGamePoint = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            FindObjectOfType<InitInformation>().Init(this);
            PlayerInputs = new PlayerInputs();
            PlayerInputs.GameInput.Enable();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (PlayerInputs != null)
            PlayerInputs.GameInput.Disable();
    }
}
