using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;

    [HideInInspector] public float hp;
    [HideInInspector] public float def;

    private SpriteRenderer render;
    private GameSetter gameSetter;

    public virtual void Awake()
    {
        gameSetter = FindObjectOfType<GameSetter>();
        render = this.GetComponent<SpriteRenderer>();

        hp = data.HP;
        def = data.DEF;
    }

    public virtual void Hit(float damage)
    {
        if(gameSetter != null)
            gameSetter.resultCount.ATKSuccess++;
        hp -= damage;
        StopCoroutine("ColorCh");
        StartCoroutine("ColorCh");

        if (hp < 0)
            Dead();
    }

    private IEnumerator ColorCh()
    {
        float lerpTime = Information.Instance.CurrentChaebo.bpm / 960f;
        float t = 0;
        while(t <= lerpTime)
        {
            render.color = Color.Lerp(Color.red, Color.white, t / lerpTime);
            t += Time.deltaTime;
            yield return null;
        }
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
    }
}
