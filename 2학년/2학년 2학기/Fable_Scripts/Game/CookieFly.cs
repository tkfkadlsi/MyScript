using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFly : MonoBehaviour
{
    private Vector3 originPos;
    private float t = 0f;
    private void Awake()
    {
        originPos = transform.localPosition;
    }

    private void Start()
    {
        if(Information.Instance.currentSong.SongID <= 1)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        transform.localPosition = new Vector3(originPos.x, originPos.y + Mathf.Sin(t), originPos.z);
        t += Time.deltaTime;
    }
}
