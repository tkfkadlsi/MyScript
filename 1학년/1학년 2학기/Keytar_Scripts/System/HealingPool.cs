using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPool : MonoBehaviour
{
    private SoundEnergy soundEnergy; 
    void Start()
    {
        soundEnergy = FindObjectOfType<SoundEnergy>();
    }

    void Update()
    {
        soundEnergy.energySlider.value = soundEnergy.energySlider.maxValue;
    }
}
