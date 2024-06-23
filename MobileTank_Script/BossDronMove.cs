using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BossDronMove : MonoBehaviour
{
    GameObject playerTank;
    GameObject bossHead;
    SpriteRenderer spriteRenderer;
    DronLaserShoot dronLaserShoot;


    bool inOut = false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerTank = GameManager.instance.tank;
        bossHead = GameManager.instance.bosshead;
        dronLaserShoot = GameManager.instance.dronLaserShoot;
    }

    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        if (spriteRenderer.enabled == true && inOut == true) 
        {
            Vector3 direction = new Vector3((playerTank.transform.position.x + 1f) - transform.position.x, (playerTank.transform.position.y + 2.5f) - transform.position.y, 0);
            direction = direction.normalized;
            transform.position += direction * 2 * Time.deltaTime;
        }
    }   

    public void Phase3Start()
    {
        spriteRenderer.enabled = true;
        inOut = true;
        StartCoroutine("OnOff");
    }

    IEnumerator OnOff()
    {
        while (true)
        {
            yield return new WaitForSeconds(30.0f);

            GetOut();

            yield return new WaitForSeconds(30.0f);

            GetIn();
        }
    }

    void GetOut()
    {
        inOut = false;
        dronLaserShoot.GetOut();
        transform.DOMove(new Vector3(bossHead.transform.position.x - 2, bossHead.transform.position.y + 1.5f), 1.5f).OnComplete(() =>
        {
            spriteRenderer.enabled = false;
        });
    }

    void GetIn()
    {
        inOut = true;
        dronLaserShoot.GenIn();
        spriteRenderer.enabled = true;
    }
}
