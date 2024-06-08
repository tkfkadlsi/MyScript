using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInfo : MonoBehaviour
{
    public static KeyInfo instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }


    public KeyCode _right, _left, _up, _down;

    public Color playerColor;

    public Color laserColor;
}
