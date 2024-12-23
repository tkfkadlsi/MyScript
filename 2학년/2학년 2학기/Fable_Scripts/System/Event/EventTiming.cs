using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventTiming
{
    public int NoteIndex;
    public EventType Type;
    [HideInInspector] public float Timing;
}
