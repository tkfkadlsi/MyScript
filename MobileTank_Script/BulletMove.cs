using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Pools bulletPool;
    BossHpManager bossHpManager;
    GameObject bossRArm;
    GameObject bossLArm;
    GameObject bossHead;
    GameObject balKanShoot;

    void Awake()
    {
        bulletPool = GameManager.instance.pools;
    }

    private void Start()
    {
        bossHpManager =  GameManager.instance.bossHpManager;
        bossRArm = GameManager.instance.bossRArm;
        bossLArm = GameManager.instance.bossLArm;
        bossHead = GameManager.instance.bosshead;
        balKanShoot = GameManager.instance.balKanShoot;
    }

    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 9);

        if (transform.position.y >= 7)
        {
            bulletPool.BulletEnqueue(gameObject);
        }

        if (transform.position.y <= -7)
        {
            bulletPool.BulletEnqueue(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == bossHead)
        {
            bossHpManager.BulletDamage();
            bulletPool.BulletEnqueue(gameObject);
        }
        else if (collision.collider.gameObject == bossRArm)
        {
            bossHpManager.StartCoroutine("BulletRArmDamage");
            bulletPool.BulletEnqueue(gameObject);
        }
        else if (collision.collider.gameObject == balKanShoot)
        {
            bossHpManager.StartCoroutine("BulletBalKanShootDamage");
            bulletPool.BulletEnqueue(gameObject);
        }
        else if(collision.collider.gameObject == bossLArm)
        {
            bossHpManager.StartCoroutine("BulletLArmDamage");
            bulletPool.BulletEnqueue(gameObject);
        }
    }

}
