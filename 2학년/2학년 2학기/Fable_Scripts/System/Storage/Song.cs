using UnityEngine;
using UnityEngine.Rendering;
[System.Serializable]
public class Song
{
    [Header("Song Info")]
    public int SongID;
    public string SongName;
    public string EngSongName;
    public string ArtistName;
    public int SongBPM;
    public int offsetMS;
    public float Highlight;
    [Header("File Info")]
    public AudioClip AudioFile;
    public TextAsset ChaeboFile_Fairytale;
    public TextAsset ChaeboFile_Dream; 
    public TextAsset ChaeboFile_Nightmare;
    public Sprite Thumbnail;
    public RoadMats RoadMats;
    public GameObject Fairytale_Map;
    public GameObject Dream_Map;
    public GameObject Nightmare_Map;
    public VolumeProfile VolumeProfile;
    public Light DirectionalLigthValue;
    public Sprite LobbyBGSprite;
    [Header("Difficult")]
    public int FairytaleDiffcult;
    public int DreamDifficult;
    public int NightMareDifficult;
}