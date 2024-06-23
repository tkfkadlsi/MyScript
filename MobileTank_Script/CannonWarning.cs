using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWarning : MonoBehaviour
{
    GameObject tank;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        tank = GameManager.instance.tank;
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(tank.transform.position.x - transform.position.x, tank.transform.position.y - transform.position.y);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        transform.rotation = angleAxis;
    }
}
