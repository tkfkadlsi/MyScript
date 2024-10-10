using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Radial : MonoBehaviour
{
    [SerializeField] private float defaultATK;
    private float range;

    private SoundEnergy soundEnergy;

    private MeshRenderer meshRenderer;

    private float ATK;

    private void OnEnable()
    {

        soundEnergy = FindObjectOfType<SoundEnergy>();
        meshRenderer = this.GetComponent<MeshRenderer>();
        ATK = defaultATK * (soundEnergy.energySlider.value / 100);
        if (GameManager.Instance.isAtkUp) ATK += 2;
        SizeUp();
        StartCoroutine(destroy());
        transform.localPosition = Vector3.back;
    }

    private void SizeUp()
    {
        range = soundEnergy.energySlider.value / 20;
        transform.DOScale(range, Information.Instance.CurrentChaebo.bpm / 480f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Hit(ATK);
        }
    }

    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(Information.Instance.CurrentChaebo.bpm / 480f);
        Destroy(gameObject);
    }
}
