using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSkill : PieceSkill
{
    private int healValue = 1;

    public override void Skill()
    {
        _mybody.HealPiece(healValue);
    }
}
