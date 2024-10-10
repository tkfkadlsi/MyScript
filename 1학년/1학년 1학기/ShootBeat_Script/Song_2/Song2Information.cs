using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song2Information : MonoBehaviour
{
    public static Song2Information instance;

    public int score1 { get; set; }
    public int combo1 { get; set; }
    public int perfect1 { get; set; }
    public int good1 { get; set; }
    public int bad1 { get; set; }
    public int miss1 { get; set; }


    private void Awake()
    {
        instance = this;
    }
}
