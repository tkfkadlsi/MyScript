using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadialWeapon : MonoBehaviour
{
    public EnemyWeapon Weapon;

    [SerializeField] private AudioClip clip;

    private AudioSource audioSource;
    private CircleCollider2D circleCollider2D;
    private MeshRenderer meshRenderer;

    private void OnEnable()
    {
        if(Weapon.WeaponType != WeaponType.radialType)
        {
            Debug.Log($"Not match WeaponType {transform.root.name}");
        }

        audioSource = transform.root.GetComponent<AudioSource>();
        transform.SetParent(null);
        circleCollider2D = this.GetComponent<CircleCollider2D>();
        meshRenderer = this.GetComponent<MeshRenderer>();

        circleCollider2D.enabled = false;
        RotateWait();
    }

    private void RotateWait()
    {
        transform.DORotate(new Vector3(0, 0, 180), 0.5f).OnComplete(()=>
        {
            StartCoroutine(Fin_SizeUp());
        });
    }

    private IEnumerator Fin_SizeUp()
    {
        audioSource.PlayOneShot(clip);
        circleCollider2D.enabled = true;
        meshRenderer.materials[0] = null;

        yield return new WaitForSeconds(0.25f);
        Dead();
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = FindObjectOfType<PlayerController>();

            playerController.Hit(Weapon.Damage);
        }
    }
}