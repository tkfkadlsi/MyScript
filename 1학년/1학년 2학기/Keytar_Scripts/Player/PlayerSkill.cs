using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private bool isSkilling = false;

    private void Update()
    {
        if (Input.GetKeyDown(Information.Instance.currentKeyList[5].Code) && isSkilling == false)
        {
            isSkilling = true;
            StartCoroutine(Skill());
        }
    }

    private IEnumerator Skill()
    {
        SoundEnergy soundEnergy = FindObjectOfType<SoundEnergy>();

        soundEnergy.energySlider.maxValue = 300;
        soundEnergy.energySlider.value = 300;

        yield return new WaitForSeconds(3.05f);

        soundEnergy.energySlider.maxValue = 100;
        soundEnergy.energySlider.value = 100;

        PlayerSkill playerSkill = this;
        playerSkill.enabled = false;
    }
}
