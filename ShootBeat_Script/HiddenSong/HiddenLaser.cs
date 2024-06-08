using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HiddenLaser : MonoBehaviour
{
    SpriteRenderer ren;

    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        ren.color = KeyInfo.instance.laserColor;
        StartCoroutine("Del");
    }

    IEnumerator Del()
    {
        transform.localScale = new Vector3(0.2f, 6, 1);
        transform.DOScaleX(0.0f, 0.5f);
        while(ren.color.a >= 0.02f)
        {
            ren.color = new Color(ren.color.r, ren.color.g, ren.color.b, ren.color.a - 0.02f);
            yield return new WaitForSeconds(0.01f);
        }
        HiddenSongManager.instance.LaserDel(gameObject);
    }
}
