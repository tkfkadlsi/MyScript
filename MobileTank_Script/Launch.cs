using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    Pools bulletPool;
    AudioManage audioManage;

    //int ammunition = 5;
    void Start()
    {
        bulletPool = GameManager.instance.pools;
        audioManage = GameManager.instance.audioManage;
    }
    float cooltime = 1.5f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) /*&& ammunition != 0*/)
        {
            if(cooltime <= 0)
            {
                audioManage.StartCoroutine("BulletFire");
            }
        }

        cooltime -= Time.deltaTime;
    }

    public void Fire()
    {
        Vector3 CannonPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = CannonPosition;
        bullet.transform.rotation = gameObject.transform.rotation;
        cooltime = 1.5f;
    }
}
