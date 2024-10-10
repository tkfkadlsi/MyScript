using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLanguage : MonoBehaviour
{
    [SerializeField] private string Kor;
    [SerializeField] private string Eng;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();

        if (Information.Instance.Language == "ÇÑ±¹¾î")
            textMeshPro.text = Kor;
        else if(Information.Instance.Language == "English")
            textMeshPro.text = Eng;
    }
}
