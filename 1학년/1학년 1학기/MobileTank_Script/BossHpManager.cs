using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpManager : MonoBehaviour
{
    [SerializeField] private GameObject bossHead;
    [SerializeField] private GameObject bossRArm;
    [SerializeField] private GameObject bossBalKanShoot;
    [SerializeField] private GameObject bossLArm;
    [SerializeField] private Slider bossHpGauge;
    [SerializeField] private Slider bossRArmGauge;
    [SerializeField] private Slider bossBalKanGauge;
    [SerializeField] private Slider bossLArmGauge;
 
    SpriteRenderer bossHeadRenderer;
    SpriteRenderer bossRArmRenderer;
    SpriteRenderer bossBalKanRenderer;
    SpriteRenderer bossLArmRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        bossHeadRenderer = bossHead.GetComponent<SpriteRenderer>();
        bossRArmRenderer = bossRArm.GetComponent<SpriteRenderer>();
        bossBalKanRenderer = bossBalKanShoot.GetComponent<SpriteRenderer>();
        bossLArmRenderer = bossLArm.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletDamage()
    {
        bossHpGauge.value -= 20.0f;
        StartCoroutine("BossHeadHit");
    }

    IEnumerator BossHeadHit()
    {
        bossHeadRenderer.color = new Color(1, 0.2f, 0.2f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.3f, 0.3f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.4f, 0.4f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.5f, 0.5f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.6f, 0.6f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.7f, 0.7f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.8f, 0.8f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 0.9f, 0.9f, 1);
        yield return new WaitForSeconds(0.05f);
        bossHeadRenderer.color = new Color(1, 1, 1, 1);
    }

    public IEnumerator BulletRArmDamage()
    {
        bossRArmGauge.value -= 20f;
        bossRArmRenderer.color = Color.red;

        for(int i = 0; i < 10; i++)
        {
            bossRArmRenderer.color = new Color(bossRArmRenderer.color.r, bossRArmRenderer.color.g+0.1f, bossRArmRenderer.color.b+0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator BulletBalKanShootDamage()
    {
        bossBalKanGauge.value -= 20f;
        bossBalKanRenderer.color = new Color(0.7f, 0, 0);

        for (int i = 0; i < 10; i++)
        {
            bossBalKanRenderer.color = new Color(bossBalKanRenderer.color.r, bossBalKanRenderer.color.g + 0.07f, bossBalKanRenderer.color.b + 0.07f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator BulletLArmDamage()
    {
        bossLArmGauge.value -= 20f;
        bossLArmRenderer.color = Color.red;

        for (int i = 0; i < 10; i++)
        {
            bossLArmRenderer.color = new Color(bossLArmRenderer.color.r, bossLArmRenderer.color.g + 0.1f, bossLArmRenderer.color.b + 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void LaserDamage(float laserDamage)
    {
        bossHpGauge.value -= laserDamage;
        StartCoroutine("BossHeadHit");
    }

    public IEnumerator BoomDamage()
    {
        bossHpGauge.value -= 500;
        bossHeadRenderer.color = Color.red;

        for (int i = 0; i < 20; i++)
        {
            bossHeadRenderer.color = new Color(bossHeadRenderer.color.r, bossHeadRenderer.color.g + 0.05f, bossHeadRenderer.color.b + 0.05f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
