using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UINavigation StartUI;

    public MenuFuncs MenuFuncs;
    public OptionFuncs OptionFuncs;
    public SettingFuncs SettingFuncs;
    public SongFuncs SongFuncs;
    public ProfileFuncs ProfileFuncs;
    public RankingFuncs RankingFuncs;

    public GameObject songselectText;

    public TextMeshProUGUI triggerTMP;

    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;

        Time.fixedDeltaTime = 0.02f;
        Application.targetFrameRate = 60;
        Cursor.visible = true;

        MenuFuncs = GetComponent<MenuFuncs>();
        OptionFuncs = GetComponent<OptionFuncs>();
        SettingFuncs = GetComponent<SettingFuncs>();
        SongFuncs = GetComponent<SongFuncs>();
        ProfileFuncs = GetComponent<ProfileFuncs>();
        RankingFuncs = GetComponent<RankingFuncs>();

        songselectText.SetActive(false);

        UINavigation.ChangeFocus(StartUI);
    }

    private void Start()
    {
        Information.Instance.PlayerState = PlayerState.None;
    }

    private void Update()
    {
        if (Information.Instance.IsGamePoint)
        {
            bool isNoneState = Information.Instance.PlayerState == PlayerState.None;
            if (isNoneState != songselectText.activeSelf)
            {
                songselectText.SetActive(isNoneState);
            }
        }
        else if (songselectText.activeSelf)
        {
            songselectText.SetActive(false);
        }
    }

    public void SetMsg(string msg)
    {
        triggerTMP.text = msg;
    }
}
