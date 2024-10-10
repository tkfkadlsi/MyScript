using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    GaugeManage gaugeManage;

    // Start is called before the first frame update
    void Start()
    {
        gaugeManage = GameManager.instance.gaugeManage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gaugeManage.CallLaserDamage();
        }
    }
}
