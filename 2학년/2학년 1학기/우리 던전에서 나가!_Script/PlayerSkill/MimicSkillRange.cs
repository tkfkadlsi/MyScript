using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicSkillRange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    private PlayerPieces playerPiece;
    private void Start()
    {
        StartCoroutine(Disable());
        playerPiece = GetComponentInParent<PlayerPieces>();
    }

    private IEnumerator Disable()
    {
        float t = 0f;
        float lerpTime = 0.5f;

        while (t < lerpTime)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(Color.white, Color.clear, t / lerpTime);
            }

            t += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
