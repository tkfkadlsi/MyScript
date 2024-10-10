using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoomSupport: MonoBehaviour
{
    [SerializeField] private GameObject boomPrefab;
    BossHpManager hpManager;
    GameObject bossHead;
    Vector3 dir;
    private void Start()
    {
        bossHead = GameManager.instance.bosshead;
        hpManager = GameManager.instance.bossHpManager;
    }

    public IEnumerator BoomMove()
    {
        dir = bossHead.transform.position - transform.position;
        dir = dir.normalized;
        for(int i = 0; i<8; i++)
        {
            Time.timeScale -= 0.1f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Time.timeScale = 0.1f;
        for (int i = 0; i < 400; i++)
        {
            transform.position += new Vector3(dir.x * 0.1f, dir.y * 0.1f);
            yield return new WaitForSecondsRealtime(0.01f);

            if(i == 150)
            {
                GameObject boom = Instantiate(boomPrefab, transform.position, Quaternion.identity);
                yield return null;
            }
        }
    }
}
