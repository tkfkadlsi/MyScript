using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaebos : MonoBehaviour
{
    public List<Chaebo> chaebos;

    private void Awake()
    {
        Information.Instance.CurrentChaebo = chaebos[0];
    }
}


[System.Serializable]
public class Chaebo
{
    public string ChaeboName;
    public float bpm;
    public List<NoteTypeAndTone> noteList;
}

[System.Serializable]
public class NoteTypeAndTone
{
    public NoteType type;
    public int tone;
}