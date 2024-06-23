using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField] private Slider enemyHP;

    [SerializeField] private RuntimeAnimatorController controller4;
    [SerializeField] private RuntimeAnimatorController controller5;

    int stage;

    public void SongStart()
    {
        stage = Information.instance.Stage;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sprite = GameManager.instance.enemySprite;
        switch (stage)
        {
            case 0:
                transform.localScale = new Vector3(1, 1, 1);
                enemyHP.maxValue = 15;
                enemyHP.value = 15;
                break;
            case 1:
                transform.localScale = new Vector3(-1, 1, 1);
                enemyHP.maxValue = 200;
                enemyHP.value = 200;
                break;
            case 2:
                transform.localScale = new Vector3(1, 1, 1);
                enemyHP.maxValue = 60;
                enemyHP.value = 60;
                break;
            case 3:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case 4:
                transform.localScale = new Vector3(-1, 1, 1);
                animator.runtimeAnimatorController = controller4;
                enemyHP.maxValue = 550;
                enemyHP.value = 550;
                break;
            case 5:
                transform.localScale = new Vector3(1, 1, 1);
                transform.position = new Vector3(2, 0.5f, 0);
                animator.runtimeAnimatorController = controller5;
                enemyHP.maxValue = 750;
                enemyHP.value = 750;
                break;
        }
    }

    public void HPDown(int damage)
    {
        spriteRenderer.color = new Color(1, 0, 0, 1);
        spriteRenderer.DOColor(new Color(1, 1, 1, 1), 0.25f);
        enemyHP.value -= damage;
    }

    public void Attack()
    {
        DOTween.Kill(this);
        if (stage == 4)
            animator.SetTrigger("attack");
        if (stage == 5)
        {
            animator.SetTrigger("attack");
            transform.position = new Vector3(-2.75f, 0.5f);
            transform.DOMove(new Vector3(2, 0.5f), 0.25f);
        }
        transform.position = new Vector3(-1.75f, 0);
        transform.DOMove(new Vector3(3, 0), 0.25f);

    }
}
