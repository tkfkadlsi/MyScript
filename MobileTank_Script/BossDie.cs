using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossDie : MonoBehaviour
{
    [SerializeField] private ParticleSystem explode;
    [SerializeField] private SpriteRenderer bosseye;
    [SerializeField] private GameObject bosshead;
    [SerializeField] private GameObject bossLArm;

    public IEnumerator Bossexplosion()
    {
        for(int i = 0; i < 10; i++)
        {
            ParticleSystem particle = Instantiate(explode);
            particle.transform.position = new Vector3(Random.Range(-3, 4), Random.Range(-1, 4));
            ParticleSystem particle2 = Instantiate(explode);
            particle2.transform.position = new Vector3(Random.Range(-3, 4), Random.Range(-1, 4));
            yield return new WaitForSeconds(0.125f);
        }
    }

    public IEnumerator BossDown()
    {
        yield return new WaitForSeconds(0.05f);
        StartCoroutine("BossEyeDown");
        BossHeadDown();
        BossLArmDown();
        transform.DOMove(new Vector3(0, -0.5f, 0), 2.5f);
    }

    IEnumerator BossEyeDown()
    {
        for(int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(0.05f);
            bosseye.color = new Color(bosseye.color.r - 0.1f, bosseye.color.g - 0.1f, bosseye.color.b - 0.1f);
        }
    }

    void BossHeadDown()
    {
        //bosshead.transform.DOMove(new Vector3(0, -0.1f, 0), 0.5f);
    }

    void BossLArmDown()
    {
        transform.DORotate(new Vector3(0, 0, 30), 2.5f);
    }
}
