using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectArea : MonoBehaviour
{
    private Slime slime;

    private void Awake()
    {
            slime = GetComponentInParent<Slime>();
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
