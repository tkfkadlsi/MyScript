using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : Enemy
{
    public enum MoveDir
    {
        Move_X,
        Move_Y
    }

    public GameObject target;
    public GameObject finMessage;
    public bool isDetect = false;
    public bool isRayAttack = false;

    private GameSetter gameSetter;
    private Rigidbody2D rigid;
    private BossAttack bossAttack;
    private float moveTime;
    private MoveDir moveDir;
    public Vector2 viewDir;
    public override void Awake()
    {
        base.Awake();
        moveDir = MoveDir.Move_Y;
        bossAttack = this.GetComponent<BossAttack>();
        gameSetter = FindObjectOfType<GameSetter>();
        finMessage.SetActive(false);
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
        Debug.Log(hp);
    }

    private void Active()
    {
        if (!isDetect) return;

        Vector3 targetPos;
        Vector3 myPos;

        targetPos = new Vector3(Mathf.Round(target.transform.position.x), Mathf.Round(target.transform.position.y));
        myPos = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Vector3 posDif = targetPos - myPos;
        bossAttack.ThrowAttack();

        if (Random.Range(0, 100) <= 30)
        {
            bossAttack.RadialAttack();
        }

        if (posDif.magnitude <= 2.25f)
        {
            if (!isRayAttack)
            {
                bossAttack.RayAttack();
                return;
            }
            
        }

        if (isRayAttack)
        {
            bossAttack.ThrowAttack();
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
        if (difpos.x > 1)
        {
            viewDir = Vector2.right;
            StartCoroutine(MoveLerp(rigid.position + Vector2.right));
        }
        else if (difpos.x < -1)
        {
            viewDir = Vector2.left;
            StartCoroutine(MoveLerp(rigid.position + Vector2.left));
        }
        else
        {
            moveDir = MoveDir.Move_Y;
            Active();
        }
    }

    private void MoveY(Vector3 difpos)
    {
        if (difpos.y > 1)
        {
            viewDir = Vector2.up;
            StartCoroutine(MoveLerp(rigid.position + Vector2.up));
        }
        else if (difpos.y < -1)
        {
            viewDir = Vector2.down;
            StartCoroutine(MoveLerp(rigid.position + Vector2.down));
        }
        else
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
        finMessage.SetActive(true);
        gameSetter.GameFin();
        base.Dead();
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemyAct -= Active;
    }
}