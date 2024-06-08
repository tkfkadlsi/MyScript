using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Interface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI text;

    [SerializeField] private string In_Kor;
    [SerializeField] private string Out_Kor;
    [SerializeField] private string In_Eng;
    [SerializeField] private string Out_Eng;

    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();

        if(Information.Instance.Language == "한국어")
        {
            text.text = Out_Kor;
        }
        else if(Information.Instance.Language == "English")
        {
            text.text = Out_Eng;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Information.Instance.Language == "한국어")
        {
            text.text = In_Kor;
        }
        else if(Information.Instance.Language == "English")
        {
            text.text = In_Eng;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(Information.Instance.Language == "한국어")
        {
            text.text = Out_Kor;
        }
        else if(Information.Instance.Language == "English")
        {
            text.text = Out_Eng;
        }
    }
}
