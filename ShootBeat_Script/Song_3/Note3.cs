using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note3 : MonoBehaviour
{
    GameObject player;
    PlayerController3 playerController3;

    Transform trm;

    private void Start()
    {
        player = Song3Manager.instance.player;
        playerController3 = player.GetComponent<PlayerController3>();
        trm = GetComponent<Transform>();

    }

    void Update()
    {
        if(transform.tag == "Note")
        {
            if (trm.localPosition.y < 20)
            {
                trm.Translate(Vector3.up * 10 * Time.deltaTime);
            }
            else
            {
                playerController3.Miss();
                Song3Manager.instance.Combo = 0;
                Song3Manager.instance.noteDel(gameObject);
            }
        }
    }
}
