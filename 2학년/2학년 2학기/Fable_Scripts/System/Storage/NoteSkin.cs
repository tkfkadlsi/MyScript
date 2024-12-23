using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteSkin
{
    public Material NoneStep_Mat;
    public Material LeftStep_Mat;
    public Material RightStep_Mat;
    public Material LeftRotate_Mat;
    public Material RightRotate_Mat;
    public Material[] Event_Mats = new Material[99];
}
