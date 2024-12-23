using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNote_Five : EventNote
{
    protected override void Awake()
    {
        base.Awake();
        isDieNote = true;
    }

    protected override void EventFunc()
    {
        base.EventFunc();
        animaionControl.Event();
    }

    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
        if (type != NoteType.EventNote) { return; }
        EventFunc();
        Judgement();
    }
}
