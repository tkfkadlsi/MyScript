using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalKanPo : MonoBehaviour
{
    GameObject player;
    Vector2 dir;
    float angle;
    Quaternion angleaxis;

    private void Start()
    {
        player = GameManager.instance.tank;
    }

    private void Update()
    {
        dir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angleaxis = Quaternion.AngleAxis(angle + 115f, Vector3.forward);
        transform.rotation = angleaxis;
    }
}
