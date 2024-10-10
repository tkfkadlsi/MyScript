using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float hp;
    public float HP { get { return hp; } }

    [SerializeField] private float def;
    public float DEF { get { return def; } }
}