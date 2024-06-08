using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attribute", menuName = "ScriptableObject/Attribute")]
public class Attribute : ScriptableObject
{
    [SerializeField] private string name_Kor = "";
    public string Name_Kor { get { return name_Kor; } }

    [SerializeField] private string detail_Kor = "";
    public string Detail_Kor { get { return detail_Kor; } }

    [SerializeField] private string name_Eng = "";
    public string Name_Eng { get { return name_Eng; } }

    [SerializeField] private string detail_Eng = "";
    public string Detail_Eng { get { return detail_Eng; } }
}