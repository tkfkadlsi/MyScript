using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceSkill : MonoBehaviour
{
    private const int maxLevel = 1;
    protected PlayerPieces _mybody;

    private void Awake()
    {
        _mybody = GetComponent<PlayerPieces>();
    }

    public bool GetIsSkillOn(int level)
    {
        return level == maxLevel;
    }

    public abstract void Skill();
}
