using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] private Slider playerHP;
    [SerializeField] private Slider energySlider;
    [SerializeField] private SongEnd songEnd;
    [SerializeField] private Image image;
    [SerializeField] private GameObject imageObj;
    [SerializeField] private GameObject cross;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        imageObj.SetActive(false);
        cross.SetActive(false); 
    }

    public void HPDown()
    {
        spriteRenderer.color = new Color(1, 0, 0, 1);
        spriteRenderer.DOColor(new Color(1, 1, 1, 1), 0.25f);
    }

    private void Update()
    {
        if (playerHP.value == 0)
        {
            GameManager.instance.isPause = true;
            HPZero();
        }

        energySlider.value += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (energySlider.value == 10)
            {
                energySlider.value = 0;
                StartCoroutine(Escape());
            }
        }
    }

    public void HPZero()
    {
        Information.instance.clearGame = false;
        imageObj.SetActive(true);
        image.DOColor(new Color(0, 0, 0, 1), 0.5f).OnComplete(() =>
        {
            songEnd.CallSongEnd();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            if (gameObject.CompareTag("Hero"))
            {
                playerHP.value -= 5;
                HPDown();
            }
        }
    }

    IEnumerator Escape()
    {
        gameObject.tag = "Escape";
        cross.SetActive(true);

        yield return new WaitForSeconds(1);

        gameObject.tag = "Hero";
        cross.SetActive(false);
    }
}
