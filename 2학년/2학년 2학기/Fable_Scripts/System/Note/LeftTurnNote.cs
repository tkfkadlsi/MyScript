using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTurnNote : TurnNote
{
    protected override void Awake()
    {
        base.Awake();
        isDieNote = true;
    }

    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
        if (type != NoteType.LeftRotate) { return; }
        PlayerTurn(-90);
    }
}