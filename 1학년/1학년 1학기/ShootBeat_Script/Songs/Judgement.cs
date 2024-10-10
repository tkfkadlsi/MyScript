using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JudgePos
{
    Top,
    Buttom,
    Left,
    Right
}

public class Judgement : MonoBehaviour
{
    [SerializeField] private JudgePos judgePos;

    [SerializeField] private Transform player;
    [SerializeField] private Transform[] line;

    Transform trm;

    private void Awake()
    {
        trm = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        switch (judgePos)
        {
            case JudgePos.Top:
                Top();
                break;

            case JudgePos.Buttom:
                Buttom();
                break;

            case JudgePos.Left:
                Left();
                break;

            case JudgePos.Right:
                Right();
                break;
        }
    }


    void Top()
    {
        trm.position = new Vector3(player.position.x, line[0].position.y);
    }

    void Buttom()
    {
        trm.position = new Vector3(player.position.x, line[1].position.y);
    }

    void Left()
    {
        trm.position = new Vector3(line[2].position.x, player.position.y);
    }

    void Right()
    {
        trm.position = new Vector3(line[3].position.x, player.position.y);
    }
}
