using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrowWeapon : MonoBehaviour
{
    public EnemyWeapon Weapon;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip clip2;

    private AudioSource audioSource;
    private BossSlime slime;
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    private PlayerController player;

    private bool isActive = false;

    private void OnEnable()
    {
        if (Weapon.WeaponType != WeaponType.throwType)
        {
            Debug.Log($"Not match WeaponType {transform.root.name}");
        }
        slime = GetComponentInParent<BossSlime>();
        direction = slime.viewDir;
        player = FindObjectOfType<PlayerController>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        audioSource = transform.root.GetComponent<AudioSource>();
        transform.SetParent(null);

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        float t = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(Random.Range(-3, 4), Random.Range(77, 84));
        audioSource.PlayOneShot(clip);
        while (t < 1)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / 1);

            t += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(
            Mathf.Round(endPos.x),
            Mathf.Round(endPos.y));

        Stop();
        StartCoroutine(AlphaDown());

    }

    private void Stop()
    {
        isActive = true;
    }

    private IEnumerator AlphaDown()
    {
        float t = 0f;
        Color startColor = new Color(1, 1, 1, 1);
        Color endColor = new Color(1, 1, 1, 0);
        audioSource.PlayOneShot(clip2);
        while (t < 3)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, t / 3);

            t += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (!isActive) return;

        Vector3 playerPos = new Vector3(
            Mathf.Round(player.transform.position.x),
            Mathf.Round(player.transform.position.y));
        if (playerPos == transform.position)
        {
            player.Hit(Weapon.Damage * Time.deltaTime);
        }
    }
}
