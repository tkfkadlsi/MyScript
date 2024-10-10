using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private Image image;
    private TextMeshProUGUI dieText;
    private SoundEnergy soundEnergy;
    private GameSetter gameSetter;
    private bool isDie = false;

    private void Awake()
    {
        image = this.GetComponent<Image>();
        dieText = GetComponentInChildren<TextMeshProUGUI>();
        gameSetter = FindObjectOfType<GameSetter>();

        image.enabled = false;
        dieText.enabled = false;
    }

    void Start()
    {
        soundEnergy = FindObjectOfType<SoundEnergy>();
    }

    private void Update()
    {
        if (soundEnergy.energySlider.value == 0 && isDie == false)
        {
            isDie = true;
            StartCoroutine(Die());
        } 
    }

    private IEnumerator Die()
    {
        image.enabled = true;
        dieText.enabled = true;
        Information.Instance.ResultCount = gameSetter.resultCount;
        Information.Instance.isClear = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);
    }
}
