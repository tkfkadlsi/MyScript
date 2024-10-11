using UnityEngine;

[CreateAssetMenu(menuName = "SO/Song")]
public class SongSO : ScriptableObject
{
    [Header("Song Information")]
    public SongTitle SongTitle;
    public Sprite thumbnail;
    public string SongName;
    public string SongDescription;
    public string SongArtist;
    public int StandardBPM;
    public int MinBPM;
    public int MaxBPM;
    public float Highlight;
    public AudioClip Songfile;
    [Header("Chaebo")]
    public TextAsset Travel;
    public int Travel_Difficulty;
    public TextAsset Adventure;
    public int Adventure_Difficulty;
    public TextAsset Special;
    public int Special_Difficulty;
    public TextAsset Timing;
    public TextAsset Bell;
}