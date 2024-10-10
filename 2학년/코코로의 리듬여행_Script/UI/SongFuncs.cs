using UnityEngine;
using UnityEngine.SceneManagement;

public class SongFuncs : MonoBehaviour
{
    private SongPanel songPanel;

    private void Awake()
    {
        songPanel = FindObjectOfType<SongPanel>();
    }

    public void DifficultToTravel()
    {
        Information.Instance.DiffcultType = DiffcultType.Travel;
        SetSong();
    }

    public void DifficultToAdventure()
    {
        Information.Instance.DiffcultType = DiffcultType.Adventure;
        SetSong();
    }

    public void DifficultToSpecial()
    {
        Information.Instance.DiffcultType = DiffcultType.Special;
        SetSong();
    }

    private void SetSong()
    {
        SongSO currentSong = Information.Instance.SongDictionary[Information.Instance.CurrentSong];
        songPanel.SetSongInfo(currentSong);
    }

    public void GoRhythmGameScene()
    {
        if (Information.Instance.DiffcultType == DiffcultType.Special)
        {
            if (Information.Instance.CurrentSong != SongTitle.Aurelia && Information.Instance.CurrentSong != SongTitle.Witch_Record)
            {
                BackendManager.Instance.ErrorMsg("Special 난이도는 특정 곡에만 있습니다.\n(Aurelia, Witch Record)");
                return;
            }
        }

        SceneManager.LoadScene("2_RhythmGame");
    }
}
