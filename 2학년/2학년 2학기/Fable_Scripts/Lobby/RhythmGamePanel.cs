using TMPro;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class RhythmGamePanel : PanelSystem
{
    [SerializeField] private Sprite GrayStar;
    [SerializeField] private Sprite YellowStar;
    [SerializeField] private Sprite SkyStar;
    [SerializeField] private Sprite PurpleStar;

    [HideInInspector] public Image noTouchZonePanel;

    private Image thumbnail;
    private TextMeshProUGUI songNameText;
    private TextMeshProUGUI songBPMText;
    private TextMeshProUGUI artistText;
    private TextMeshProUGUI dreamDiffText;
    private TextMeshProUGUI nightmareDiffText;
    private TextMeshProUGUI bestScoreText;
    private TextMeshProUGUI bestAccuraryText;

    private Image OneStar;
    private Image TwoStar;
    private Image ThreeStar;

    private SetCamPosition setCamPosition;

    private void Awake()
    {
        Initialize();
        setCamPosition = FindObjectOfType<SetCamPosition>();
    }

    private void Initialize()
    {
        noTouchZonePanel = transform.parent.Find("NoTouchZone").GetComponent<Image>();
        thumbnail = transform.Find("Thumbnail").GetComponent<Image>();
        songNameText = transform.Find("SongName").GetComponent<TextMeshProUGUI>();
        songBPMText = transform.Find("BPM").GetComponent<TextMeshProUGUI>();
        artistText = transform.Find("Artist").GetComponent<TextMeshProUGUI>();
        dreamDiffText = transform.Find("Dream").GetChild(0).GetComponent<TextMeshProUGUI>();
        nightmareDiffText = transform.Find("Nightmare").GetChild(0).GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        bestAccuraryText = transform.Find("BestAccurary").GetComponent<TextMeshProUGUI>();
        OneStar = transform.Find("ScorePanel/OneStar").GetComponent<Image>();
        TwoStar = transform.Find("ScorePanel/TwoStar").GetComponent<Image>();
        ThreeStar = transform.Find("ScorePanel/ThreeStar").GetComponent<Image>();
    }

    public void SetPanelInfo()
    {
        Song song = Information.Instance.currentSong;

        thumbnail.sprite = song.Thumbnail;
        songNameText.text = song.SongName;
        songBPMText.text = $"BPM : {song.SongBPM}";
        artistText.text = song.ArtistName;
        dreamDiffText.text = $"Dream\n{song.DreamDifficult}";
        nightmareDiffText.text = $"Nightmare\n{song.NightMareDifficult}";

        if (Information.Instance.currentDiff == DifficultType.Fairy)
        {
            SetDiffFairytale();
        }
        else if (Information.Instance.currentDiff == DifficultType.Dream)
        {
            SetDiffDream();
        }
        else
        {
            SetDiffNightmare();
        }
    }

    public void SetDiffFairytale()
    {
        bestScoreText.text = $"Score : {Information.Instance.GameData.BestStarRatingFairytale[Information.Instance.currentSong.SongID].ToString("D7")}";
        bestAccuraryText.text = $"{Information.Instance.GameData.BestFairytaleAccuraries[Information.Instance.currentSong.SongID].ToString("F2")}%";
        DisplayStarRate();
    }

    public void SetDiffDream()
    {
        bestScoreText.text = $"Score : {Information.Instance.GameData.BestStarRatingDream[Information.Instance.currentSong.SongID].ToString("D7")}";
        bestAccuraryText.text = $"{Information.Instance.GameData.BestDreamAccuraries[Information.Instance.currentSong.SongID].ToString("F2")}%";
        DisplayStarRate();
    }

    public void SetDiffNightmare()
    {
        bestScoreText.text = $"Score : {Information.Instance.GameData.BestStarRatingNightmare[Information.Instance.currentSong.SongID].ToString("D7")}";
        bestAccuraryText.text = $"{Information.Instance.GameData.BestNightmareAccuraries[Information.Instance.currentSong.SongID].ToString("F2")}%";
        DisplayStarRate();
    }

    public void PanelOpen()
    {
        OpenPanel(noTouchZonePanel);
    }
    public override void OpenPanel(Image noTouchZonePanel)
    {
        SetPanelInfo();
    }

    public override void ClosePanel(Image noTouchZonePanel)
    {
        noTouchZonePanel.gameObject.SetActive(false);
        setCamPosition.Cancel();
    }

    private void DisplayStarRate()
    {
        int highrate = 0;

        if(Information.Instance.currentDiff == DifficultType.Fairy)
        {
            highrate = Information.Instance.GameData.BestStarRatingFairytale[Information.Instance.currentSong.SongID];
        }
        else if(Information.Instance.currentDiff == DifficultType.Dream)
        {
            highrate = Information.Instance.GameData.BestStarRatingDream[Information.Instance.currentSong.SongID];
        }
        else if (Information.Instance.currentDiff == DifficultType.Nightmare)
        {
            highrate = Information.Instance.GameData.BestStarRatingNightmare[Information.Instance.currentSong.SongID];
        }

        OneStar.sprite = highrate >= 1 ? YellowStar : GrayStar;
        TwoStar.sprite = highrate >= 2 ? YellowStar : GrayStar;
        ThreeStar.sprite = highrate >= 3 ? YellowStar : GrayStar;

        if(highrate == 4)
        {
            OneStar.sprite = TwoStar.sprite = ThreeStar.sprite = SkyStar;
        }
        if(highrate == 5)
        {
            OneStar.sprite = TwoStar.sprite = ThreeStar.sprite = PurpleStar;
        }
    }
}
