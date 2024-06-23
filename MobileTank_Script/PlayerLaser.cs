using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public GameObject laserPrefab;
    TankMove tankMove;
    GameObject tank;
    GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameManager.instance.tower;
        tank = GameManager.instance.tank;
        tankMove = GameManager.instance.tankMove;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaserFire(float laserDamage)
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
        Laser laser = FindObjectOfType<Laser>();
        laser.setLaserDamage(laserDamage);
    }
}
