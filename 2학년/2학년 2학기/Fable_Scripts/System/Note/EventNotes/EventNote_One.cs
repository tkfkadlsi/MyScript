using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNote_One : EventNote
{
    protected override void EventFunc()
    {
        base.EventFunc();
        if (isHit) { return; }
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
