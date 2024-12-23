using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramSetting : MonoBehaviour
{
    private void Start()
    {
        Frame();
    }

    private void Frame()
    {
        Application.targetFrameRate = 60;
    }
} 
