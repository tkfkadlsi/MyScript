using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    radialType = 1,
    rayType = 2,
    throwType = 3,
}


public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    public void Attack()
    {
        GameObject w = Instantiate(weapon, transform);
        
        w.transform.position = transform.position;
    }
}
