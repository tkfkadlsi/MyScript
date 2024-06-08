using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public enum MoveDir
    {
        Move_X,
        Move_Y
    }

    public GameObject target;
    public bool isDetect = false;

    [SerializeField] private List<StageWall> stageWalls;
    [SerializeField] private GameSetter gameSetter;
    private Rigidbody2D rigid;
    private EnemyAttack enemyAttack;
    private float moveTime;
    private MoveDir moveDir;
    public Vector2 viewDir;
    public override void Awake()
    {
        base.Awake();
        moveDir = MoveDir.Move_Y;
        enemyAttack = this.GetComponent<EnemyAttack>();
    }

    private void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>().gameObject;
        moveTime = Information.Instance.CurrentChaebo.bpm / 960f;
        GameManager.Instance.enemyAct += Active;
    }

    public override void Hit(float damage)
    {
        base.Hit(damage - def);
    }

    private void Active()
    {
        if (!isDetect) return;

        Vector3 targetPos;
        Vector3 myPos;

        targetPos = new Vector3(Mathf.Round(target.transform.position.x), Mathf.Round(target.transform.position.y));
        myPos = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Vector3 posDif = targetPos - myPos;

        if (posDif.magnitude <= 1)
        {
            enemyAttack.Attack();
            return;
        }

        int rand = Random.Range(0, 5);
        if(rand == 0)
        {
            enemyAttack.Attack();
            return;
        }

        if (moveDir == MoveDir.Move_Y)
        {
            MoveY(posDif);
        }
        else if (moveDir == MoveDir.Move_X)
        {
            MoveX(posDif);
        }
    }

    private void MoveX(Vector3 difpos)
    {
        if (difpos.x > 0)
        {
            viewDir = Vector2.right;
            StartCoroutine(MoveLerp(rigid.position + Vector2.right));
        }
        else if (difpos.x < 0)
        {
            viewDir = Vector2.left;
            StartCoroutine(MoveLerp(rigid.position + Vector2.left));
        }
        else if(difpos.x == 0)
        {
            moveDir = MoveDir.Move_Y;
            Active();
        }
    }

    private void MoveY(Vector3 difpos)
    {
        if (difpos.y > 0)
        {
            viewDir = Vector2.up;
            StartCoroutine(MoveLerp(rigid.position + Vector2.up));
        }
        else if (difpos.y < 0)
        {
            viewDir = Vector2.down;
            StartCoroutine(MoveLerp(rigid.position + Vector2.down));
        }
        else if(difpos.y == 0)
        {
            moveDir = MoveDir.Move_X;
            Active();
        }
    }

    private IEnumerator MoveLerp(Vector3 endPos)
    {
        Vector3 startPos = rigid.position;
        float t = 0f;

        while (t < moveTime)
        {
            t += Time.deltaTime;

            rigid.position = Vector3.Lerp(startPos, endPos, t / moveTime);

            yield return null;
        }
        rigid.position = new Vector3(
            Mathf.Round(rigid.position.x),
            Mathf.Round(rigid.position.y));
    }

    public override void Dead()
    {
        foreach(StageWall stageWall in stageWalls)
        {
            stageWall.IsWallOn = false;
        }

        if(gameSetter != null)
        {
            gameSetter.ChoiceAttribute();
        }

        base.Dead();
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemyAct -= Active;
    }
}
