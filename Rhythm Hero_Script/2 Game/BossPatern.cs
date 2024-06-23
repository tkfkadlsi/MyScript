using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatern : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;

    bool isStage5;
    float coolTime;

    private void Start()
    {
        isStage5 = false;
        coolTime = 15f;
    }

    public void CallBossStage()
    {
        isStage5 = true;
        coolTime = Random.Range(10.0f, 20.0f);
    }

    private void Update()
    {
        if (isStage5 == true)
            coolTime -= Time.deltaTime;

        if (coolTime <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        GameObject stone = Instantiate(stonePrefab);
        stone.transform.position = new Vector3(-3, 10);
        CallBossStage();
    }
}
