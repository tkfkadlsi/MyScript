using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneStepNote : Note
{
    protected override void Awake()
    {
        base.Awake();
        isNoneStep = true;
    }

    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
    }
}