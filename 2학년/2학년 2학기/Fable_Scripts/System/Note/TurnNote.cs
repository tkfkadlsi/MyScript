using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class TurnNote : Note
{
    protected void PlayerTurn(int i)
    {
        player.TagDown(gameObject, i);
        Judgement(true);
    }
}
