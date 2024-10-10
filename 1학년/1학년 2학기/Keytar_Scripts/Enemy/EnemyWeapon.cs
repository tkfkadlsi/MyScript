using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyWeapon", menuName = "ScriptableObject/EnemyWeapon")]
public class EnemyWeapon : ScriptableObject
{
    [SerializeField] private WeaponType weaponType;
    public WeaponType WeaponType { get { return weaponType; } }

    [SerializeField] private int range;
    public int Range { get { return range; } }

    [SerializeField] private float damage;
    public float Damage { get { return damage; } }
}
