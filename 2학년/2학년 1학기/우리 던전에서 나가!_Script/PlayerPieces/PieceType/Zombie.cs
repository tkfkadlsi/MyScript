using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Zombie : PlayerPieces
{
    private int killCount;
    private const int activeCount = 3;

    private void Start()
    {
        Init();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TMananger.instance.CurrnetState != GameState.PlayerTurn) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePos, transform.position);
        if(distance < 0.5f * TMananger.instance.tileScale)
        {
            MovePointONOFF();
            selectPieces.SelectNewPiece(gameObject);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TMananger.instance.CurrnetState != GameState.PlayerTurn) return;

        if (collision.collider.CompareTag("Enemy"))
        {
            Information.instance.killCount++;
            if (pieceLevel != maxLevel)
            {
                pieceManager.PCLevel(1, this);
            }
            Destroy(collision.gameObject);
            killCount++;
            UseSkill();
        }
    }

    private void UseSkill()
    {
        if (!mySkill.GetIsSkillOn(pieceLevel))
            return;
        if (killCount < activeCount)
            return;

        killCount -= activeCount;
        mySkill.Skill();
    }

    protected override void Init()
    {
        pieceIndex = 1;
        base.Init();
    }
}
