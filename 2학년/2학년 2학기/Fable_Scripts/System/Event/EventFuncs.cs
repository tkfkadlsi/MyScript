using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventFuncs : MonoBehaviour
{
    private void Awake()
    {
        player = FindObjectOfType<PlayerInput>();
    }

    protected PlayerInput player;
    public abstract void Event_1(int noteIndex);
    public abstract void Event_2(int noteIndex);
    public abstract void Event_3(int noteIndex);
}