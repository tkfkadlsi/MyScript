using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInStage : MonoBehaviour
{
    private BoxCollider2D stageArea;

    private void Awake()
    {
        stageArea = this.GetComponent<BoxCollider2D>();
        stageArea.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
