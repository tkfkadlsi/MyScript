using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftStepNote : Note
{
    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
        if(type != NoteType.LeftStep) { return; }
        Judgement();
    }
}
