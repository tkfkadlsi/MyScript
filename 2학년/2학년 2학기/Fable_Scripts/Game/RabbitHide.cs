using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHide : MonoBehaviour
{
    private void Start()
    {
        if (Information.Instance.currentSong.SongID <= 2)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
