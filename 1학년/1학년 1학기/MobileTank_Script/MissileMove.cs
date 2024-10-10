using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    Pools missileWarningSignPool;
    Pools missileEffectPool;
    Pools missilePool;
    SpriteRenderer spriteRenderer;
    AudioManage audioManage;
    float speed = 7.0f;

    void Start()
    {
        missileWarningSignPool = GameManager.instance.pools;
        missileEffectPool = GameManager.instance.pools;
        missilePool = GameManager.instance.pools;
        audioManage = GameManager.instance.audioManage;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1, 1, 1);
        transform.eulerAngles = new Vector3(0, 0, 90);
        spriteRenderer.sortingLayerName = "BackBoss";
        StartCoroutine("UpMove");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpMove()
    {
        while (true)
        {
            if(transform.position.y <= 8.0f)
            {
                transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                break;
            }
        }
        TargetSetting();
    }

    void TargetSetting()
    {
        float RandomX = Random.Range(-8.5f, 8.5f);
        transform.position = new Vector3(RandomX, transform.position.y ,0);
        transform.eulerAngles = new Vector3(0, 0, 270);
        spriteRenderer.sortingLayerName = "BossPatern";

        StartCoroutine("DownMove");
    }

    IEnumerator DownMove()
    {

        float RandomY = Random.Range(-1.0f, -4.5f);

        transform.localScale = new Vector3(1.5f, 1.5f, 1);

        Vector3 signPosition = new Vector3(transform.position.x, RandomY, 0);

        GameObject Sign = missileWarningSignPool.GetMissileWarningSign();
        Sign.transform.position = signPosition;

        while (true)
        {
            if (transform.position.y >= RandomY)
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                
            }
            else
            {
                break;
            }
            yield return null;
        }
        MisslieDamage();
    }

    void MisslieDamage()
    {
        audioManage.Missile();
        GameObject Missileefc = missileEffectPool.GetMissileEffect();
        Missileefc.transform.position = gameObject.transform.position;
        missilePool.MissileEnqueue(gameObject);
    }


}
