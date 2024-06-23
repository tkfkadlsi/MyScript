using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongPanel : MonoBehaviour
{
    [SerializeField] private Image thumbnail;
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private TextMeshProUGUI artist;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI BPM;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI rate;
    [SerializeField] private TextMeshProUGUI rateClass;

    public void SetSongInfo(SongSO song)
    {
        thumbnail.sprite = song.thumbnail;
        songName.text = song.name;
        artist.text = "작곡가 : " + song.SongArtist;
        switch (Information.Instance.DiffcultType)
        {
            case DiffcultType.Travel:
                level.color = new Color(0, 1, 1);
                level.text = $"레벨 {song.Travel_Difficulty}";
                break;
            case DiffcultType.Adventure:
                level.color = new Color(1, 0, 0);
                level.text = $"레벨 {song.Adventure_Difficulty}";
                break;
            case DiffcultType.Special:
                level.color = new Color(1, 0, 1);
                level.text = $"레벨 {song.Special_Difficulty}";
                break;
        }
        if (song.MaxBPM == 0)
        {
            BPM.text = $"BPM {song.MinBPM}";
        }
        else
        {
            BPM.text = $"BPM {song.MinBPM} ~ {song.MaxBPM}({song.StandardBPM})";
        }
        int highscore = FindHighScore();
        float highrate = FindHighRate();
        score.text = $"점수 : {highscore.ToString("0000000")}";
        rate.text = $"정확도 : {highrate.ToString("#00.00")}%";

        if (highrate >= (int)ClassType.SS)
        {
            rateClass.text = "SS";
        }
        else if (highrate >= (int)ClassType.SP)
        {
            rateClass.text = "S+";
        }
        else if (highrate >= (int)ClassType.S)
        {
            rateClass.text = "S";
        }
        else if (highrate >= (int)ClassType.A)
        {
            rateClass.text = "A";
        }
        else if (highrate >= (int)ClassType.B)
        {
            rateClass.text = "B";
        }
        else if (highrate >= (int)ClassType.C)
        {
            rateClass.text = "C";
        }
        else
        {
            rateClass.text = "D";
        }
    }

    private int FindHighScore()
    {
        string key = DataKey.ReturnKey(Information.Instance.CurrentSong, Information.Instance.DiffcultType);
        if (Information.Instance.GameData.PlayerHighScore.ContainsKey(key))
            return Information.Instance.GameData.PlayerHighScore[key];
        else
        {
            Information.Instance.GameData.PlayerHighScore.Add(key, 0);
            return 0;
        }
    }

    private float FindHighRate()
    {
        string key = DataKey.ReturnKey(Information.Instance.CurrentSong, Information.Instance.DiffcultType);
        if (Information.Instance.GameData.PlayerHighRate.ContainsKey(key))
            return Information.Instance.GameData.PlayerHighRate[key];
        else
        {
            Information.Instance.GameData.PlayerHighRate.Add(key, 0);
            return 0;
        }
    }
}
