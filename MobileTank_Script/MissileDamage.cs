using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDamage : MonoBehaviour
{
    GaugeManage gaugeManage;
    Pools missileEffectPool;

    private void Start()
    {
        missileEffectPool = GameManager.instance.pools;
        gaugeManage = GameManager.instance.gaugeManage;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.7f);
        missileEffectPool.MissileEfcEnqueue(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            gaugeManage.CallMissileDamage();
        }
    }


}
