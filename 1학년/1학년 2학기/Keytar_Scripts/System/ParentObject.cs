using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObject : MonoBehaviour
{
    public void OnTransformChildrenChanged()
    {
        if (transform.childCount == 0) return;

        Transform child = transform.GetChild(0);
        child.SetParent(null);
    }
}
