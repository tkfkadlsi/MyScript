using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPatern : MonoBehaviour
{
    BossPaternManage bossPaternManage;
    Slider playerHp;

    private void Start()
    {
        gameObject.SetActive(false);
        bossPaternManage = GameManager.instance.bossPaternManage;
        playerHp = GameManager.instance.playerHp.GetComponent<Slider>();
    }

    public IEnumerator CallLaser()
    {
        gameObject.transform.Rotate(0, 0, 120);
        for(int i = 0; i < 30; i++)
        {
            gameObject.transform.Rotate(0, 0, -4);
            yield return new WaitForSeconds(0.02f);
        }
        bossPaternManage.BPaternEndCall();
        gameObject.SetActive(false);
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Tank")
        {
            for(int i = 0; i<10; i++)
            {
                playerHp.value += -2.5f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
