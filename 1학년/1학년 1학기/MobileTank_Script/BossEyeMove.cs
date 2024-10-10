using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEyeMove : MonoBehaviour
{
    GameObject PlayerTank;
    GameObject Boss;

    private void Start()
    {
        Boss = GameManager.instance.boss;
        PlayerTank = GameManager.instance.tank;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = new Vector3((PlayerTank.transform.position.x-gameObject.transform.position.x) / 33 + Boss.transform.position.x, transform.position.y, 0);
    }
}
