using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Height : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentHeightText;

    private float currentHeight;

    [SerializeField] private TextMeshProUGUI highHeightText;

    public float highHeight;

    private void Update()
    {
        currentHeight = transform.position.y;

        string str = currentHeight.ToString("0.00");

        currentHeightText.text = $"현재 높이 : {str}m";

        if (currentHeight > highHeight)
        {
            highHeight = currentHeight;

            string hstr = highHeight.ToString("0.00");
            highHeightText.text = $"최고 높이 : {hstr}m";
        }
    }
}
