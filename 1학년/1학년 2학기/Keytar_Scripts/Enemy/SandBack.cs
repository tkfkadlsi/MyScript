using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SandBack : Enemy
{
    private Chaebos chaebos;

    public override void Awake()
    {
        base.Awake();
        chaebos = FindObjectOfType<Chaebos>();
    }

    public override void Dead()
    {
        base.Dead();
        ChangeChaebo();
    }

    private void ChangeChaebo()
    {
        for(int i = 0; i < chaebos.chaebos.Count; i++)
        {
            if(Information.Instance.CurrentChaebo == chaebos.chaebos[i])
            {
                if(i+1 == chaebos.chaebos.Count)
                {
                    Information.Instance.CurrentChaebo = chaebos.chaebos[0];
                }
                else
                {
                    Information.Instance.CurrentChaebo = chaebos.chaebos[i+1];
                }
                break;
            }
        }
    }
}
