using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBlind : MonoBehaviour
{
    private SpriteRenderer blindSprite;

    private void Awake()
    {
        blindSprite = GetComponent<SpriteRenderer>();
    }
    public IEnumerator Blind(Color targetColor)
    {
        //float lerpTime = 0.35f;
        //float t = 0f;

        //while(t < lerpTime)
        //{
        //    t += Time.deltaTime;
        yield return null;

        //    blindSprite.color = Color.Lerp(blindSprite.color, targetColor, t / lerpTime);
        //}
    }
}
