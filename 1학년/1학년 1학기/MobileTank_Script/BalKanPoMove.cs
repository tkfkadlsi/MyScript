using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalKanPoMove : MonoBehaviour
{
    public GameObject BalKanAssets;
    GameObject PlayerTank;
    GameObject balKanShoot;
    Pools balKanPool;
    GaugeManage gaugeManage;

    float BalKanPoSpeed;

    private void Start()
    {
        balKanPool = GameManager.instance.pools;
        gaugeManage = GameManager.instance.gaugeManage;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        balKanShoot = GameManager.instance.balKanShoot;
        transform.position = balKanShoot.transform.position;
        PlayerTank = GameManager.instance.tank;
        Vector2 direction = new Vector2(PlayerTank.transform.position.x - BalKanAssets.transform.position.x, PlayerTank.transform.position.y - BalKanAssets.transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        BalKanPoSpeed = Random.Range(6.5f, 10.5f);
        transform.rotation = angleAxis;

        //transform.Rotate(0, 0, Random.Range(transform.rotation.z - 1.0f, transform.rotation.z +1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * BalKanPoSpeed * Time.deltaTime);
        DestroyBalKanPo();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            gaugeManage.StartCoroutine("BalKanDamage");
            balKanPool.BalKanEnqueue(gameObject);
        }
    }

    void DestroyBalKanPo()
    {
        if(transform.position.y > 8 || transform.position.y < -8)
        {
            balKanPool.BalKanEnqueue(gameObject);
        }
    }

    
}
