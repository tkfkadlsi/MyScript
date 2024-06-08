using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeytarInput : MonoBehaviour
{
    private List<Key> currentKeyList = new List<Key>();
    public Action onKeytarMove;
    public Action<Vector2> setDirection;
    public Action onAttack;

    private Vector3 dir;

    public bool readyCommand = false;

    private void Awake()
    {
        currentKeyList = Information.Instance.currentKeyList;
    }

    private void Update()
    {
        Forward();
        SetDir();
        Attack();
        Skill();
    }
    
    private void Forward()
    {
        if (Input.GetKeyDown(currentKeyList[0].Code))
        {
            onKeytarMove?.Invoke();
        }
    }

    private void SetDir()
    {
        if (Input.GetKey(currentKeyList[2].Code))
        {
            dir = Vector3.down;
        }
        else if (Input.GetKey(currentKeyList[1].Code) && Input.GetKey(currentKeyList[3].Code))
        {
            dir = Vector3.up;
        }
        else if (Input.GetKey(currentKeyList[1].Code))
        {
            dir = Vector3.left;
        }
        else if (Input.GetKey(currentKeyList[3].Code))
        {
            dir = Vector3.right;
        }
        else
        {
            dir = Vector3.up;
        }

        setDirection?.Invoke(dir);
    }

    private void Attack()
    {
        if (Input.GetKeyDown(currentKeyList[4].Code))
        {
            onAttack?.Invoke();
        }
    }

    private void Skill()
    {
        if (Input.GetKeyDown(currentKeyList[5].Code))
        {

        }
    }

    
}
