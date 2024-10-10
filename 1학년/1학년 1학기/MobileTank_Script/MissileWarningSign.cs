using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWarningSign : MonoBehaviour
{
    Pools missileWarningSignPool;

    void Awake()
    {
        missileWarningSignPool = GameManager.instance.pools;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("SignDelete");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SignDelete()
    {
        yield return new WaitForSeconds(1.5f);

        missileWarningSignPool.MissileWarningSignEnQueue(gameObject);
    }


}
