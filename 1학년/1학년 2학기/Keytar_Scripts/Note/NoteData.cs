using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NoteData", menuName = "ScriptableObject/NoteData")]
public class NoteData : ScriptableObject
{
    [SerializeField] private string noteType;
    public string NoteType { get { return noteType; } }

    [SerializeField] private float notePeriod;
    public float NotePeriod { get { return notePeriod; } }
}
