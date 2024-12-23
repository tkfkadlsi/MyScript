using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fable_StarFloating : MonoBehaviour
{
    private float t = 0f;
    private Vector3 originPos;

    private void Start()
    {
        t = Random.Range(0f, Mathf.PI * 2f);
        originPos = transform.position;
    }

    private void Update()
    {
        t += Time.deltaTime;

        Vector3 position = transform.position;
        position.y = originPos.y + Mathf.Sin(t) * 0.1f;
        transform.position = position;
    }
}
