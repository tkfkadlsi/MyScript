using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;

    Transform trm;

    private void Start()
    {
        player = Song2Manager.instance.player;
        playerController = player.GetComponent<PlayerController>();
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
                playerController.Miss();
                Song2Manager.instance.Combo = 0;
                Song2Manager.instance.noteDel(gameObject);
            }
        }
    }
}
