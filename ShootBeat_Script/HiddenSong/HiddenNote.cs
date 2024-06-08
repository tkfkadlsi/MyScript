using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenNote : MonoBehaviour
{
    GameObject player;
    HiddenPlayerController hiddenPlayerController;

    Transform trm;

    private void Start()
    {
        player = HiddenSongManager.instance.player;
        hiddenPlayerController = player.GetComponent<HiddenPlayerController>();
        trm = GetComponent<Transform>();

    }

    void Update()
    {
        if(transform.tag == "Note")
        {
            if (trm.localPosition.y < 20)
            {
                trm.Translate(Vector3.up * 15 * Time.deltaTime);
            }
            else
            {
                hiddenPlayerController.Miss();
                HiddenSongManager.instance.Combo = 0;
                HiddenSongManager.instance.noteDel(gameObject);
            }
        }
    }
}
