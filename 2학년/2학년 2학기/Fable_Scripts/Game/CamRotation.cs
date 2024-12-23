using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CamRotation
{
    public int noteIndex;
    public float duration;
    public float angle;
    public float timing;
    public CamCurveType curveType = CamCurveType.InOutSine;
    public bool isTurn = true;
} 