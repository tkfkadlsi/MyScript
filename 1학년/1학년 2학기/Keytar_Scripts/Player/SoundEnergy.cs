using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEnergy : MonoBehaviour
{
    public Slider energySlider { get; private set; }

    private void Awake()
    {
        energySlider = this.GetComponent<Slider>();
    }

    private void Update()
    {
        energySlider.value -= Time.deltaTime * Information.Instance.CurrentChaebo.bpm / 24;
    }

    public void SoundEnergyUp(float plusEnergy)
    {
        energySlider.value += plusEnergy;
    }
}
