using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleionSkill : PieceSkill
{
    public override void Skill()
    {
        _mybody.playerEnergy.PlusEnergy(_mybody.SubEnergy);
        _mybody.pieceManager.Resetleadership(_mybody.playerEnergy.GetEnergy());
    }
}
