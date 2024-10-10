using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    GameObject bossHead;
    BossHpManager hpManager;
    Vector3 dir;
    private void Start()
    {
        bossHead = GameManager.instance.bosshead;
        hpManager = GameManager.instance.bossHpManager;
    }

    private void Update()
    {
        dir = bossHead.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        Quaternion rotate = angleAxis;
        gameObject.transform.rotation = rotate;
        gameObject.transform.position += dir.normalized * 30.0f * Time.deltaTime;
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boss"))
        {
            hpManager.StartCoroutine("BoomDamage");
            for (int i = 0; i < 8; i++)
            {
                Time.timeScale += 0.1f;
                yield return new WaitForSecondsRealtime(0.05f);
            }
            Time.timeScale = 1;

            Destroy(gameObject);
        }
    }
}
