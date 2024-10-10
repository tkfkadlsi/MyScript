using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardInput : MonoBehaviour
{
    private List<Key> currentKeyList = new List<Key>();
    public Action onKKeyboardMove;
    public Action<Vector2> setDirection;
    public Action onAttack;

    private Vector3 dir;

    private void Awake()
    {
        currentKeyList = Information.Instance.currentKeyList;
    }

    private void Update()
    {
        Forward();
        Left();
        Back();
        Right();
        Attack();
        Skill();
    }

    private void Forward()
    {
        if (Input.GetKeyDown(currentKeyList[0].Code))
        {
            dir = Vector3.up;
            setDirection?.Invoke(dir);
            onKKeyboardMove?.Invoke();
        }
    }

    private void Left()
    {
        if (Input.GetKeyDown(currentKeyList[1].Code))
        {
            dir = Vector3.left;
            setDirection?.Invoke(dir);
            onKKeyboardMove?.Invoke();
        }
    }

    private void Back()
    {
        if (Input.GetKeyDown(currentKeyList[2].Code))
        {
            dir = Vector3.down;
            setDirection?.Invoke(dir);
            onKKeyboardMove?.Invoke();
        }
    }

    private void Right()
    {
        if (Input.GetKeyDown(currentKeyList[3].Code))
        {
            dir = Vector3.right;
            setDirection?.Invoke(dir);
            onKKeyboardMove?.Invoke();
        }
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
