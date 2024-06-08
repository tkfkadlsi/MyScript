using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0 : Enemy
{
    [SerializeField] private StageWall stageWall;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Hit(float damage)
    {
        base.Hit(damage);
    }

    public override void Dead()
    {
        stageWall.IsWallOn = false;
        base.Dead();
    }
}
