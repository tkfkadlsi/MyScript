using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject throwWeapon;
    [SerializeField] private GameObject rayWeapon;
    [SerializeField] private GameObject radialWeapon;

    public void ThrowAttack()
    {
        GameObject t = Instantiate(throwWeapon, transform);

        t.transform.position = transform.position;
    }

    public void RayAttack()
    {
        GameObject ry = Instantiate(rayWeapon, transform);

        ry.transform.position = transform.position;
    }

    public void RadialAttack()
    {
        GameObject rl = Instantiate(radialWeapon, transform);

        rl.transform.position = new Vector3(Random.Range(-2, 3), Random.Range(78, 83));
    }
}
