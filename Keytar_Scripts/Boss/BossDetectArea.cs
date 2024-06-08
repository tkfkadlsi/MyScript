using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectArea : MonoBehaviour
{
    private BossSlime slime;

    private void Awake()
    {
        slime = GetComponentInParent<BossSlime>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            slime.isDetect = true;
            slime.target = collision.gameObject;
        }
    }
}
