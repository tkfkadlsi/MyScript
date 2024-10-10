using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OffsetChange : MonoBehaviour
{
    [SerializeField] private Slider offsetSlider;
    [SerializeField] private TextMeshProUGUI offsetText;

    int plusoffset;


    private void Awake()
    {
        plusoffset = PlayerPrefs.GetInt("Offset");
        offsetSlider.value = plusoffset;
        offsetText.text = plusoffset.ToString();
        Information.instance._plusOffset = plusoffset;
    }


    public void ChangeOffset()
    {
        plusoffset = (int)offsetSlider.value;
        PlayerPrefs.SetInt("Offset", plusoffset);
        offsetText.text = plusoffset.ToString();
        Information.instance._plusOffset = plusoffset;
    }
}
