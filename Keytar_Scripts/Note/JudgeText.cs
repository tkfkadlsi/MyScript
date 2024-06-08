using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JudgeText : MonoBehaviour
{
    private TextMeshProUGUI judgeText;
    public int Combo = 0;

    private void Awake()
    {
        judgeText = this.GetComponent<TextMeshProUGUI>();
    }

    public void Text(string inputText)
    {
        Combo = 0;
        judgeText.text = inputText;
    }

    public void Text()
    {
        Combo++;
        judgeText.text = Combo.ToString();
    }
}
