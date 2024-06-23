using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLaunch : MonoBehaviour
{
    Pools missilePool;
    BossPaternManage bossPaternManage;
    Transform bossTransform;
    AudioManage audioManage;

    // Start is called before the first frame update
    void Start()
    {
        missilePool = GameManager.instance.pools;
        bossTransform = GameManager.instance.boss.transform;
        bossPaternManage = GameManager.instance.bossPaternManage;
        audioManage = GameManager.instance.audioManage;
    }
    public void MissileLaunchCall()
    {
        StartCoroutine("MisslieLaunchStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MisslieLaunchStart()
    {
        for(int i = 0; i < 5; i++)
        {
            audioManage.MissileLaunch();
            yield return new WaitForSeconds(0.1f);
            Vector3 lBossPosition = new Vector3(bossTransform.position.x - 1, bossTransform.position.y + 2, 0);
            Vector3 rBossPosition = new Vector3(bossTransform.position.x + 1, bossTransform.position.y + 2, 0);

            GameObject lMissile = missilePool.GetMissile();
            GameObject rMissile = missilePool.GetMissile();
            rMissile.transform.position = rBossPosition;
            lMissile.transform.position = lBossPosition;

            yield return new WaitForSeconds(0.75f);
        }

        yield return new WaitForSeconds(2.5f);

        bossPaternManage.APaternEndCall();
    }
}
