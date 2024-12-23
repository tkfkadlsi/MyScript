using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private PlayerInput player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        OverX();
        OverZ();
        transform.position = new Vector3(transform.position.x, player.transform.position.y - 9f, transform.position.z);
    }

    private void OverX()
    {
        float Xdistance = player.transform.position.x - transform.position.x;
        if(Xdistance >= 80)
        {
            transform.position += new Vector3(160, 0, 0);
        }
        else if(Xdistance <= -80)
        {
            transform.position += new Vector3(-160, 0, 0);
        }
    }

    private void OverZ()
    {
        float Zdistance = player.transform.position.z - transform.position.z;
        if (Zdistance >= 80)
        {
            transform.position += new Vector3(0, 0, 160);
        }
        else if (Zdistance <= -80)
        {
            transform.position += new Vector3(0, 0, -160);
        }
    }
}
