using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNote : MonoBehaviour
{
    private RectTransform rect;

    private float noteSpeed = 600f;

    private void Awake()
    {
        rect = this.GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.anchoredPosition += new Vector2(-noteSpeed * Time.deltaTime, 0);

        if (rect.anchoredPosition.x <= -600)
        {
            Release();
        }
    }

    private void Release()
    {
        GameManager.Instance.EnemyAction();
        PoolManager.Instance.ReturnObject("EnemyNote", gameObject);
    }
}