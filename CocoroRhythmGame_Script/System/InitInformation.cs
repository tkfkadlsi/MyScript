using System.Collections.Generic;
using UnityEngine;

public class InitInformation : MonoBehaviour
{
    [SerializeField] private List<SongSO> songs = new List<SongSO>();

    public void Init(Information information)
    {
        foreach (var song in songs)
        {
            information.SongDictionary.Add(song.SongTitle, song);
        }
    }
}
