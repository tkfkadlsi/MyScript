using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightStepNote : Note
{
    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
        if (type != NoteType.RightStep) { return; }
        Judgement();
    }
}
