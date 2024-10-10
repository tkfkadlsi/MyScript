using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    BossHpManager hpManager;
    GameObject tower;

    float damage = 0;

    private void Start()
    {
        tower = GameManager.instance.tower;
        hpManager = GameManager.instance.bossHpManager;

        Vector3 vector = (tower.transform.rotation).eulerAngles;

        vector += new Vector3(0, 0, 90);

        transform.rotation = Quaternion.Euler(vector);

    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 10 * Time.deltaTime);
    }

    public void setLaserDamage(float laserDamage)
    {
        damage = laserDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "BossHead")
        {
            hpManager.LaserDamage(damage);
            Destroy(gameObject);
        }
    }
}
