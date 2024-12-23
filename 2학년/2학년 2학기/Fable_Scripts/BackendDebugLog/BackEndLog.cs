using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackEndLog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugLogTMP;

    public void PrintLog(string log)
    {
        debugLogTMP.text = log; 
    } 
}
