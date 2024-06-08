using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note1 : MonoBehaviour
{
    GameObject player;
    PlayerController1 playerController1;

    Transform trm;

    private void Start()
    {
        player = Song1Manager.instance.player;
        playerController1 = player.GetComponent<PlayerController1>();
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
                playerController1.Miss();
                Song1Manager.instance.Combo = 0;
                Song1Manager.instance.noteDel(gameObject);
            }
        }
    }
}
