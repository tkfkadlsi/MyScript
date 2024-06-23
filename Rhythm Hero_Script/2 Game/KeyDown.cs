using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KeyDown : MonoBehaviour
{
    [SerializeField] private Image attackPress_1;
    [SerializeField] private Image attackX_1;
    [SerializeField] private Image attackPress_2;
    [SerializeField] private Image attackX_2;
    [SerializeField] private Image attackEffect;

    [SerializeField] private Image defendPress_1;
    [SerializeField] private Image defendO_1;
    [SerializeField] private Image defendPress_2;
    [SerializeField] private Image defendO_2;
    [SerializeField] private Image defendEffect;

    [SerializeField] private RectTransform attackJudgeLine;
    [SerializeField] private RectTransform defendJudgeLine;

    [SerializeField] private Enemy enemy;
    [SerializeField] private Player player;
    [SerializeField] private JudgeText judgeText;

    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip defendSound;

    AudioSource audioSource;

    Animator animator;

    private GameObject closestObject;
    public string targetTag = "AttackNote";
    public string targetTag2 = "DefendNote";

    KeyCode attack1, attack2, defend1, defend2;

    bool isAttackKeyDown;
    bool isDefendKeyDown;

    float noteSpeed;

    private void Awake()
    {
        isAttackKeyDown = false;
        isDefendKeyDown = false;

        attack1 = Information.instance._attack1;
        attack2 = Information.instance._attack2;
        defend1 = Information.instance._defend1;
        defend2 = Information.instance._defend2;

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        noteSpeed = Information.instance._noteSpeed;
    }



    private void Update()
    {
        if (GameManager.instance.isPause == false)
        {
            AttackKeyDown();
            AttackKey();
            AttackColor();
            DefendKeyDown();
            DefendKey();
            DefendColor();
        }
    }

    void AttackKeyDown()
    {
        if (Input.GetKeyDown(attack1) || Input.GetKeyDown(attack2))
        {
            AttackPress();
            audioSource.PlayOneShot(attackSound);
        }
    }

    void AttackKey()
    {
        if (Input.GetKey(attack1) || Input.GetKey(attack2))
        {
            isAttackKeyDown = true;
        }
        else
        {
            isAttackKeyDown = false;
        }
    }

    void AttackColor()
    {
        if (isAttackKeyDown == true)
        {
            attackEffect.color = new Color(1, 0.5f, 0.5f, 1);
        }
        else if (isAttackKeyDown == false)
        {
            attackEffect.color = new Color(1, 0.5f, 0.5f, 0);
        }



        if (Input.GetKey(attack1))
        {
            attackPress_1.color = new Color(0.5f, 0.125f, 0, 1);
            attackX_1.color = new Color(1, 0, 0.5f, 1);
        }
        else
        {
            attackPress_1.color = new Color(0.5f, 0.125f, 0, 0);
            attackX_1.color = new Color(1, 1, 1, 1);
        }

        if (Input.GetKeyDown(attack1))
            animator.SetTrigger("Attack1");


        if (Input.GetKey(attack2))
        {
            attackPress_2.color = new Color(0.5f, 0.125f, 0, 1);
            attackX_2.color = new Color(1, 0, 0.5f, 1);
        }
        else
        {
            attackPress_2.color = new Color(0.5f, 0.125f, 0, 0);
            attackX_2.color = new Color(1, 1, 1, 1);
        }

        if (Input.GetKeyDown(attack2))
            animator.SetTrigger("Attack2");
    }



    void DefendKeyDown()
    {
        if (Input.GetKeyDown(defend1) || Input.GetKeyDown(defend2))
        {
            DefendPress();
            audioSource.PlayOneShot(defendSound);
            animator.SetTrigger("Block");
        }
    }

    void DefendKey()
    {
        if (Input.GetKey(defend1) || Input.GetKey(defend2))
        {
            isDefendKeyDown = true;
        }
        else
        {
            isDefendKeyDown = false;
        }
    }

    void DefendColor()
    {
        if (isDefendKeyDown == true)
        {
            defendEffect.color = new Color(0.5f, 0.5f, 1, 1);
        }
        else if (isDefendKeyDown == false)
        {
            defendEffect.color = new Color(0.5f, 0.5f, 1, 0);
        }



        if (Input.GetKey(defend1))
        {
            defendPress_1.color = new Color(0, 0.125f, 0.5f, 1);
            defendO_1.color = new Color(0, 0.5f, 0.5f, 1);
        }
        else
        {
            defendPress_1.color = new Color(0, 0.125f, 0.5f, 0);
            defendO_1.color = new Color(1, 1, 1, 1);
        }



        if (Input.GetKey(defend2))
        {
            defendPress_2.color = new Color(0, 0.125f, 0.5f, 1);
            defendO_2.color = new Color(0, 0.5f, 0.5f, 1);
        }
        else
        {
            defendPress_2.color = new Color(0, 0.125f, 0.5f, 0);
            defendO_2.color = new Color(1, 1, 1, 1);
        }
    }


    private void Move()
    {
        DOTween.Kill(this);
        transform.position = new Vector3(1.75f, -1);
        transform.DOMove(new Vector3(-3, -1), 0.1f);
    }


    public void AttackPress()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach (GameObject target in targetObjects)
        {
            RectTransform targetTrm = target.GetComponent<RectTransform>();
            float distance = Vector3.Distance(attackJudgeLine.anchoredPosition, targetTrm.anchoredPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = target;
            }
        }

        if (closestObject != null)
        {
            RectTransform closetTrm = closestObject.GetComponent<RectTransform>();
            float distance = Vector3.Distance(attackJudgeLine.anchoredPosition, closetTrm.anchoredPosition);

            if (distance <= noteSpeed * 3) //크리티컬
            {
                enemy.HPDown(2);
                judgeText.Critical();
                GameManager.instance.DelNote(closestObject);
                Move();
            }

            else if (distance <= noteSpeed * 7) //나이스
            {
                enemy.HPDown(1);
                judgeText.Nice();
                GameManager.instance.DelNote(closestObject);
                Move();
            }

            else if (distance <= noteSpeed * 20) //미스
            {
                judgeText.Miss();
                GameManager.instance.DelNote(closestObject);
            }
        }
    }




    public void DefendPress()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag2);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach (GameObject target in targetObjects)
        {
            RectTransform targetTrm = target.GetComponent<RectTransform>();
            float distance = Vector3.Distance(defendJudgeLine.anchoredPosition, targetTrm.anchoredPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = target;
            }
        }

        if (closestObject != null)
        {
            RectTransform closetTrm = closestObject.GetComponent<RectTransform>();
            float distance = Vector3.Distance(defendJudgeLine.anchoredPosition, closetTrm.anchoredPosition);

            if (distance <= noteSpeed * 3) //디펜스
            {
                judgeText.Defense();
                GameManager.instance.DelNote(closestObject);
                enemy.Attack();
            }

            else if (distance <= noteSpeed * 7) //세이프
            {
                judgeText.Safe();
                GameManager.instance.DelNote(closestObject);
                enemy.Attack();
            }

            else if (distance <= noteSpeed * 20) //브레이크
            {
                player.HPDown();
                judgeText.Break();
                GameManager.instance.DelNote(closestObject);
                enemy.Attack();
            }
        }
    }

    public void AttackSound()
    {
        audioSource.PlayOneShot(attackSound);
    }

    public void DefendSound()
    {
        audioSource.PlayOneShot(defendSound);
    }
}
