using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class MenuFuncs : MonoBehaviour
{
    private UINavigation beforeUI;
    private SongTitle beforeSong;
    private bool isSongChange;
    [Header("SerializeField")]
    [SerializeField] private Transform SongSelectContent;

    [Header("Initial Focus")]

    [SerializeField] private Transform menuPanel;
    [SerializeField] private UINavigation focusMenuPanel;
    private Vector2 openMenuPanelPos;
    private Vector2 closeMenuPanelPos;

    [SerializeField] private Transform songSelectPanel;
    [SerializeField] private List<UINavigation> focusSelectSongPanels;
    [SerializeField] private UINavigation returnSelectSongPanel;
    private Vector2 openSongSelectPanelPos;
    private Vector2 closeSongSelectPanelPos;

    [SerializeField] private Transform optionPanel;
    [SerializeField] private UINavigation focusOptionPanel;
    [SerializeField] private UINavigation returnOptionPanel;
    private Vector2 openOptionPanelPos;
    private Vector2 closeOptionPanelPos;

    [SerializeField] private Transform songPanel;
    [SerializeField] private UINavigation travelSongPanel;
    [SerializeField] private UINavigation adventureSongPanel;
    [SerializeField] private UINavigation specialSongPanel;
    private Vector2 openSongPanelPos;
    private Vector2 closeSongPanelPos;

    [SerializeField] private Transform settingPanel;
    [SerializeField] private UINavigation focusSettingPanel;
    private Vector2 openSettingPanelPos;
    private Vector2 closeSettingPanelPos;

    [SerializeField] private Transform keySettingPanel;
    [SerializeField] private UINavigation focusKeySettingPanel;
    [SerializeField] private UINavigation returnKeySettingPanel;
    private Vector2 openKeySettingPanelPos;
    private Vector2 closeKeySettingPanelPos;

    [SerializeField] private Canvas profileCanvas;
    [SerializeField] private UINavigation focusProfilePanel;
    [SerializeField] private UINavigation returnProfilePanel;

    [SerializeField] private Transform rankingPanel;
    [SerializeField] private UINavigation focusRankingPanel;
    [SerializeField] private UINavigation returnRankingPanel;
    private Vector2 openRankingPanelPos;
    private Vector2 closeRankingPanelPos;

    private AudioSource BGMSource;

    private void Awake()
    {
        openMenuPanelPos = menuPanel.localPosition + new Vector3(0, -250, 0);
        closeMenuPanelPos = menuPanel.localPosition;

        openSongSelectPanelPos = songSelectPanel.localPosition + new Vector3(750, 0, 0);
        closeSongSelectPanelPos = songSelectPanel.localPosition;

        openOptionPanelPos = optionPanel.localPosition + new Vector3(0, 1080, 0);
        closeOptionPanelPos = optionPanel.localPosition;

        openSongPanelPos = songPanel.localPosition + new Vector3(-600, 0, 0);
        closeSongPanelPos = songPanel.localPosition;

        openSettingPanelPos = settingPanel.localPosition + new Vector3(700, 0, 0);
        closeSettingPanelPos = settingPanel.localPosition;

        openKeySettingPanelPos = keySettingPanel.localPosition + new Vector3(0, 1080, 0);
        closeKeySettingPanelPos = keySettingPanel.localPosition;

        openRankingPanelPos = rankingPanel.localPosition + new Vector3(0, -1080, 0);
        closeRankingPanelPos = rankingPanel.localPosition;

        profileCanvas.enabled = false;
    }

    private void Start()
    {
        BGMSource = GameObject.Find("Sound").GetComponent<AudioSource>();

        SongSelectUI((int)Information.Instance.CurrentSong);
    }

    public void OpenMenuUI()
    {
        if (Information.Instance.PlayerState != PlayerState.None) return;
        Information.Instance.PlayerState = PlayerState.Menu;
        menuPanel.DOLocalMoveY(openMenuPanelPos.y, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(focusMenuPanel);
        });
    }

    public void CloseMenuUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Menu) return;
        Information.Instance.PlayerState = PlayerState.None;
        menuPanel.DOLocalMoveY(closeMenuPanelPos.y, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(UIManager.Instance.StartUI);
        });
    }

    public void OpenSongSelectUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Menu) return;
        Information.Instance.PlayerState = PlayerState.SongSelect;
        SongSelectContent.localPosition = new Vector3(SongSelectContent.localPosition.x, 0);
        beforeSong = Information.Instance.CurrentSong;
        isSongChange = false;

        menuPanel.DOLocalMoveY(closeMenuPanelPos.y, 0.5f);
        SongSelectUI((int)Information.Instance.CurrentSong);
        songSelectPanel.DOLocalMoveX(openSongSelectPanelPos.x, 0.5f).OnComplete(() =>
        {
            beforeUI = UINavigation.FocusUI;
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(focusSelectSongPanels[(int)Information.Instance.CurrentSong]);
        });
    }

    public void CloseSongSelectUI()
    {
        if (Information.Instance.PlayerState != PlayerState.SongSelect) return;
        Information.Instance.PlayerState = PlayerState.Menu;

        if (!isSongChange)
            SongSelectUI((int)beforeSong);

        menuPanel.DOLocalMoveY(openMenuPanelPos.y, 0.5f);
        songSelectPanel.DOLocalMoveX(closeSongSelectPanelPos.x, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(returnSelectSongPanel);
        });
    }

    public void OpenOptionUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Menu) return;
        Information.Instance.PlayerState = PlayerState.Option;

        menuPanel.DOLocalMoveY(closeMenuPanelPos.y, 0.5f);
        optionPanel.DOLocalMoveY(openOptionPanelPos.y, 0.25f).OnComplete(() =>
        {
            beforeUI = UINavigation.FocusUI;
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(focusOptionPanel);
        });
    }

    public void CloseOptionUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Option) return;
        Information.Instance.PlayerState = PlayerState.Menu;

        menuPanel.DOLocalMoveY(openMenuPanelPos.y, 0.5f);
        optionPanel.DOLocalMoveY(closeOptionPanelPos.y, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(returnOptionPanel);
        });
    }

    public void OpenSongUI()
    {
        if (!Information.Instance.IsGamePoint) return;
        if (Information.Instance.PlayerState != PlayerState.None) return;
        Information.Instance.PlayerState = PlayerState.SelectDiff;
        UIManager.Instance.SongFuncs.DifficultToTravel();

        songPanel.DOLocalMoveX(openSongPanelPos.x, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(travelSongPanel);
        });
    }

    public void CloseSongUI()
    {
        if (Information.Instance.PlayerState != PlayerState.SelectDiff) return;
        Information.Instance.PlayerState = PlayerState.None;

        songPanel.DOLocalMoveX(closeSongPanelPos.x, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(UIManager.Instance.StartUI);
        });
    }

    public void OpenSettingUI()
    {
        if (Information.Instance.PlayerState != PlayerState.SelectDiff) return;
        Information.Instance.PlayerState = PlayerState.SelectMode;

        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(new UINavigation());
        settingPanel.DOLocalMoveX(openSettingPanelPos.x, 0.5f).OnComplete(() =>
        {
            UINavigation.ChangeFocus(focusSettingPanel);
        });
    }

    public void CloseSettingUI()
    {
        if (Information.Instance.PlayerState != PlayerState.SelectMode) return;
        Information.Instance.PlayerState = PlayerState.SelectDiff;

        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(new UINavigation());
        settingPanel.DOLocalMoveX(closeSettingPanelPos.x, 0.5f).OnComplete(() =>
        {
            switch(Information.Instance.DiffcultType)
            {
                case DiffcultType.Travel:
                    UINavigation.ChangeFocus(travelSongPanel);
                    break;
                case DiffcultType.Adventure:
                    UINavigation.ChangeFocus(adventureSongPanel);
                    break;
                case DiffcultType.Special:
                    UINavigation.ChangeFocus(specialSongPanel);
                    break;
            }
        });
    }

    public void OpenKeySettingUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Menu) return;
        Information.Instance.PlayerState = PlayerState.KeySetting;

        menuPanel.DOLocalMoveY(closeMenuPanelPos.y, 0.5f);
        keySettingPanel.DOLocalMoveY(openKeySettingPanelPos.y, 0.25f).OnComplete(() =>
        {
            beforeUI = UINavigation.FocusUI;
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(focusKeySettingPanel);
        });
    }

    public void CloseKeySettingUI()
    {
        if (Information.Instance.PlayerState != PlayerState.KeySetting) return;
        Information.Instance.PlayerState = PlayerState.Menu;

        menuPanel.DOLocalMoveY(openMenuPanelPos.y, 0.5f);
        keySettingPanel.DOLocalMoveY(closeKeySettingPanelPos.y, 0.25f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(returnKeySettingPanel);
        });
    }

    public void OpenProfileUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Menu) return;
        Information.Instance.PlayerState = PlayerState.Profile;

        menuPanel.DOLocalMoveY(closeMenuPanelPos.y, 0.5f);
        UIManager.Instance.ProfileFuncs.SetProfile();
        profileCanvas.enabled = true;
        beforeUI = UINavigation.FocusUI;
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(focusProfilePanel);
    }

    public void CloseProfileUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Profile) return;
        Information.Instance.PlayerState = PlayerState.Menu;

        menuPanel.DOLocalMoveY(openMenuPanelPos.y, 0.5f);
        profileCanvas.enabled = false;
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(returnProfilePanel);
    }

    public void OpenRankingUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Menu) return;
        Information.Instance.PlayerState = PlayerState.Ranking;

        UIManager.Instance.RankingFuncs.UpdateRankingBoard();

        menuPanel.DOLocalMoveY(closeMenuPanelPos.y, 0.5f);
        rankingPanel.DOLocalMoveY(openRankingPanelPos.y, 0.5f).OnComplete(() =>
        {
            beforeUI = UINavigation.FocusUI;
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(focusRankingPanel);
        });
    }

    public void CloseRankingUI()
    {
        if (Information.Instance.PlayerState != PlayerState.Ranking) return;
        Information.Instance.PlayerState = PlayerState.Menu;

        menuPanel.DOLocalMoveY(openMenuPanelPos.y, 0.5f);
        rankingPanel.DOLocalMoveY(closeRankingPanelPos.y, 0.5f).OnComplete(() =>
        {
            UINavigation.FocusUI.ResetColor();
            UINavigation.ChangeFocus(returnRankingPanel);
        });
    }

    public void SongSelectUI(int index)
    {
        if (BGMSource.clip != Information.Instance.SongDictionary[(SongTitle)index].Songfile)
        {
            BGMSource.Stop();
            BGMSource.clip = Information.Instance.SongDictionary[(SongTitle)index].Songfile;
            BGMSource.time = Information.Instance.SongDictionary[(SongTitle)index].Highlight;
            BGMSource.Play();
        }
        Information.Instance.CurrentSong = (SongTitle)index;

        index++;
        int posY = index * 225;
        posY -= 675;

        posY = Mathf.Clamp(posY, 0, 1220);

        SongSelectContent.DOLocalMoveY(posY, 0.25f);
    }


    public void SongSelectEnter(int index)
    {
        isSongChange = true;
        CloseSongSelectUI();
        CloseMenuUI();
        string song = ((SongTitle)index).ToString();
        PlayerManager.Instance.PlayerMove.TargetPosition(song);
    }

    public void MovementSkip()
    {
        PlayerManager.Instance.PlayerMove.MoveSkip();
        CloseMenuUI();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
