using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    GameObject attackGear;
    GameObject defendGear;
    Image image;
    JudgeText judgeText;
    Enemy enemy;
    KeyDown keyDown;

    RectTransform rectTransform;

    float noteSpeed;

    private void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        attackGear = GameObject.Find("AttackGear");
        defendGear = GameObject.Find("DefendGear");

        judgeText = GameObject.Find("JudgeText").GetComponent<JudgeText>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        keyDown = GameObject.Find("Player").GetComponent<KeyDown>();
    }

    private void Start()
    {
        noteSpeed = GameManager.instance.noteSpeed;
        noteSpeed *= 100;
    }

    private void Update()
    {
        if (rectTransform.anchoredPosition.y > -400)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - noteSpeed * Time.deltaTime);
        }
        else
        {

            if (gameObject.transform.parent == attackGear.transform)
            {
                GameManager.instance.DelNote(gameObject);
                judgeText.Miss();
            }
            if (gameObject.transform.parent == defendGear.transform)
            {
                GameManager.instance.DelNote(gameObject);
                judgeText.Break();
                enemy.Attack();
            }
        }
    }
}
