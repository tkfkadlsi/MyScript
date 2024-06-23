using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    GameObject bossRArm;
    GameObject tank;
    BossPaternManage paternManage;
    GaugeManage gaugeManage;
    Vector3 dir;

    private void OnEnable()
    {
        bossRArm = GameManager.instance.bossRArm;
        tank = GameManager.instance.tank;
        paternManage = GameManager.instance.bossPaternManage;
        gaugeManage = GameManager.instance.gaugeManage;
        transform.position = new Vector3(bossRArm.transform.position.x + 1.0f, bossRArm.transform.position.y + 0.6375f);
        dir = tank.transform.position - gameObject.transform.position;
        dir = dir.normalized;
    }

    private void Update()
    {
        if (transform.position.y >= -7)
        {
            transform.position += dir * 20 * Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            paternManage.APaternEndCall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Tank")
        {
            gaugeManage.StartCoroutine("CannonDamage");
            gameObject.SetActive(false);
            paternManage.APaternEndCall();
        }
    }
}
