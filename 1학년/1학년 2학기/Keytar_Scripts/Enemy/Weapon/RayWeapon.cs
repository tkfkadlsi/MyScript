using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public enum RayDir
{
    Up = 0,
    Down = 1,
    Right = 2,
    Left = 3
}
public class RayWeapon : MonoBehaviour
{
    public EnemyWeapon Weapon;

    [SerializeField] private AudioClip clip;
    [SerializeField] private RayDir dir;
    [SerializeField] private AnimationCurve sizeUp_Curve;
    [SerializeField] private AnimationCurve sizeDown_Curve;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private PlayerController player;
 
    private void OnEnable()
    {
        if (Weapon.WeaponType != WeaponType.rayType)
        {
            Debug.Log("Not match Weapontype");
        }

        spriteRenderer = this.GetComponent<SpriteRenderer>();
        audioSource = transform.root.GetComponent<AudioSource>();
        transform.SetParent(null);
        player = FindObjectOfType<PlayerController>();


        switch (dir)
        {
            case RayDir.Up:
                transform.position += new Vector3(0, 4);
                StartCoroutine(SizeUp(false));
                break;

            case RayDir.Down:
                transform.position += new Vector3(0, -4);
                StartCoroutine(SizeUp(false));
                break;

            case RayDir.Right:
                transform.position += new Vector3(4, 0);
                StartCoroutine(SizeUp(true));
                break;

            case RayDir.Left:
                transform.position += new Vector3(-4, 0);
                StartCoroutine(SizeUp(true));
                break;
        }
    }

    private IEnumerator SizeUp(bool isX)
    {
        float lerpTime = 0.5f;
        float t = 0;


        if (isX)
        {
            Vector3 startScale = new Vector3(transform.localScale.x, 0.01f);
            Vector3 endScale = new Vector3(transform.localScale.x, 1);
            while (t < lerpTime)
            {
                transform.localScale = Vector3.Lerp(startScale, endScale, sizeUp_Curve.Evaluate(t / lerpTime));

                t += Time.deltaTime;
                yield return null;
            }
        }
        else if (!isX)
        {
            Vector3 startScale = new Vector3(0.01f, transform.localScale.y);
            Vector3 endScale = new Vector3(1, transform.localScale.y);
            while (t < lerpTime)
            {
                transform.localScale = Vector3.Lerp(startScale, endScale, sizeUp_Curve.Evaluate(t / lerpTime));

                t += Time.deltaTime;
                yield return null;
            }
        }

        StartCoroutine(SizeDown());
    }

    private IEnumerator SizeDown()
    {
        float lerpTime = 0.5f;
        float t = 0f;

        Color startColor = new Color(1, 1, 1, 1);
        Color endColor = new Color(1, 1, 1, 0);
        audioSource.PlayOneShot(clip);
        while(t < lerpTime)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, sizeDown_Curve.Evaluate(t / lerpTime));

            t += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Hit(Weapon.Damage * Time.deltaTime);
        }
    }
}
