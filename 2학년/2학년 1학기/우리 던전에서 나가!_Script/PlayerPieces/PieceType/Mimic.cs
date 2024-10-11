using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mimic : PlayerPieces
{
    private int moveCount = 0;

    private void Start()
    {
        Init();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TMananger.instance.CurrnetState != GameState.PlayerTurn) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePos, transform.position);
        if (distance < 0.5f * TMananger.instance.tileScale)
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
        }
    }

    public override void MovePiece()
    {
        base.MovePiece();
        UseSkill();
    }

    private void UseSkill()
    {
        if (!mySkill.GetIsSkillOn(pieceLevel)) { return; }
        moveCount++;
        if(moveCount == 2)
        {
            moveCount = 0;
            mySkill.Skill();
        }
    }

    protected override void Init()
    {
        pieceIndex = 2;
        base.Init();
    }
}
