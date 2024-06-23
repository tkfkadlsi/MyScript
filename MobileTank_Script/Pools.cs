using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    public static Pools instance = null;
    GameObject poolManager;
    GameObject poolStorage;

    [SerializeField] private GameObject BalKanPrefeb;
    Queue<GameObject> BalKanPoPool = new Queue<GameObject>();
    [SerializeField] private GameObject BulletPrefab;
    Queue<GameObject> BulletAssetsPool = new Queue<GameObject>();
    [SerializeField] private GameObject MissileEffectPrefab;
    Queue<GameObject> MissileEfcPool = new Queue<GameObject>();
    [SerializeField] private GameObject MissilePrefab;
    Queue<GameObject> MissilePool = new Queue<GameObject>();
    [SerializeField] private GameObject MissileWarningSignPreFab;
    Queue<GameObject> SignPool = new Queue<GameObject>();


    private void Start()
    {
        poolManager = GameManager.instance.poolManager;
        poolStorage = GameManager.instance.poolStorage;

        if(instance == null)
        {
            instance = this;

            for(int i = 0; i < 30; i++)
            {
                instance.BalKanPoPool.Enqueue(CreateBalKan());
            }
            for (int i = 0; i < 5; i++)
            {
                instance.BulletAssetsPool.Enqueue(CreateBullet());
            }
            for(int i = 0; i < 12; i++)
            {
                instance.MissileEfcPool.Enqueue(CreateMissileEffect());
                instance.MissilePool.Enqueue(CreateMissile());
                instance.SignPool.Enqueue(CreateMissileWarningSign());
            }
        }
    }

    GameObject CreateBalKan()
    {
        GameObject newObj = Instantiate(BalKanPrefeb);
        newObj.transform.parent = poolManager.transform;
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    GameObject CreateBullet()
    {
        GameObject newObj = Instantiate(BulletPrefab, instance.transform);
        newObj.transform.parent = poolManager.transform;
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    GameObject CreateMissileEffect()
    {
        GameObject newObj = Instantiate(MissileEffectPrefab, instance.transform);
        newObj.transform.parent = poolManager.transform;
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    GameObject CreateMissile()
    {
        GameObject newObj = Instantiate(MissilePrefab, instance.transform);
        newObj.transform.parent = poolManager.transform;
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    GameObject CreateMissileWarningSign()
    {
        GameObject newObj = Instantiate(MissileWarningSignPreFab, instance.transform);
        newObj.transform.parent = poolManager.transform;
        newObj.gameObject.SetActive(false);

        return newObj;
    }

    public GameObject GetBalKan()
    {
        if (BalKanPoPool.Count > 0)
        {
            GameObject objectInPool = BalKanPoPool.Dequeue();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
        else
        {
            GameObject objectInPool = CreateBalKan();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
    }

    public GameObject GetBullet()
    {
        if (BulletAssetsPool.Count > 0)
        {
            GameObject objectInPool = BulletAssetsPool.Dequeue();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
        else
        {
            GameObject objectInPool = CreateBullet();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
    }

    public GameObject GetMissileEffect()
    {
        if (MissileEfcPool.Count > 0)
        {
            GameObject objectInPool = MissileEfcPool.Dequeue();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
        else
        {
            GameObject objectInPool = CreateMissileEffect();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
    }

    public GameObject GetMissile()
    {
        if (MissilePool.Count > 0)
        {
            GameObject objectInPool = MissilePool.Dequeue();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
        else
        {
            GameObject objectInPool = CreateMissile();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
    }

    public GameObject GetMissileWarningSign()
    {
        if (SignPool.Count > 0)
        {
            GameObject objectInPool = SignPool.Dequeue();
            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;

            return objectInPool;
        }
        else
        {
            GameObject objectInPool = CreateMissileWarningSign();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.parent = poolStorage.transform;
            return objectInPool;
        }
    }

    public void BalKanEnqueue(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolManager.transform);
        instance.BalKanPoPool.Enqueue(obj);
    }

    public void BulletEnqueue(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolManager.transform);
        instance.BulletAssetsPool.Enqueue(obj);
    }

    public void MissileEfcEnqueue(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(poolManager.transform);
        instance.MissileEfcPool.Enqueue(obj);
    }

    public void MissileEnqueue(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolManager.transform);
        instance.MissilePool.Enqueue(obj);
    }

    public void MissileWarningSignEnQueue(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(poolManager.transform);
        instance.SignPool.Enqueue(obj);
    }
}
