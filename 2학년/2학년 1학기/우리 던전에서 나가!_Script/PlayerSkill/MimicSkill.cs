using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicSkill : PieceSkill
{
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private GameObject skillPrefab;
    public override void Skill()
    {
        if (skillPrefab != null)
        {
            GameObject obj = Instantiate(skillPrefab, transform);
            obj.transform.localScale *= TMananger.instance.tileScale;

        }
        if (effectPrefab != null)
            Instantiate(effectPrefab);
    }
}
