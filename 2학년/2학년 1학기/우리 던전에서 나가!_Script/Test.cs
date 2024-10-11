using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    Dictionary<int, string> dictionary = new Dictionary<int, string>();
    private object ASDF;

    private void Awake()
    {
        ASDF = TMananger.instance;
        dictionary.Add(1, "¿ë»óÇö 4¹Ý");
        dictionary.Add(2, "Ã¶±Ç ¹ÚÂù¿õ ¹Ø ½ÂÈ£¼º");
    }

    private void Start()
    {
        Debug.Log(dictionary[2]);
    }

}
