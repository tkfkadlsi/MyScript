using Cinemachine;
using System;
using UnityEngine;

public class EventNote_Three : EventNote
{
    protected override void Awake()
    {
        base.Awake();
        isDieNote = true;
    }

    protected override void EventFunc()
    {
        base.EventFunc();
        if (isHit) { return; }

        animaionControl.Event();
        StartEvent();
    }

    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
        if (type != NoteType.EventNote) { return; }
        EventFunc();
        Judgement();
    }

    private void StartEvent()
    {
    }


}
