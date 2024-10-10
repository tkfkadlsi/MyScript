using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossLeftArm : MonoBehaviour
{
    BossManager boss;
    SpriteRenderer spriteRenderer;
    GaugeManage gaugeManage;

    bool punching1 = false;
    bool punching2 = false;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameManager.instance.bossManager;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gaugeManage = GameManager.instance.gaugeManage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallPunch()
    {
        boss.StartCoroutine("MoveForPunch");
        transform.DORotate(new Vector3(0, 0, 100), 2.0f);
    }

    public void CallPunch2()
    {
        boss.MoveForPunch2();
        spriteRenderer.sortingLayerName = "BossArm";
    }

    public IEnumerator Punch()
    {
        yield return new WaitForSeconds(1.75f);
        punching1 = true;
        transform.DORotate(new Vector3(0, 0, -30), 0.2f).OnComplete(() =>
        {
            punching1 = false;
            transform.DORotate(new Vector3(0, 0, 0), 2.0f).OnComplete(() =>
            {
                boss.PunchEnd();
            });
        });
    }

    public IEnumerator Punch2()
    {
        transform.position += new Vector3(0, 0.5f, 0);
        yield return new WaitForSeconds(1);
        punching2 = true;
        boss.StartCoroutine("Punch2Move");
        yield return new WaitForSeconds(1.5f);
        punching2 = false;
        transform.position += new Vector3(0, -0.5f, 0);
        spriteRenderer.sortingLayerName = "Boss";
    }

    public void Punch2End()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(punching1 == true && collision.collider.gameObject.CompareTag("Player"))
        {
            gaugeManage.CallPunch1Damage();
        }
        if (punching2 == true && collision.collider.gameObject.CompareTag("Player"))
        {
            gaugeManage.CallPunch2Damage();
        }
    }
}
