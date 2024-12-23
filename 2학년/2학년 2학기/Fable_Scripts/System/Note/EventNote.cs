using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventNote : Note
{
    protected PlayerAnimaionControl animaionControl;
    private void Start()
    {
        animaionControl = FindObjectOfType<PlayerAnimaionControl>();
    }
    protected virtual void EventFunc()
    {
        if(eventTimingSystem != null)
            eventTimingSystem.EventNoteProduction(noteIndex);
    }
}