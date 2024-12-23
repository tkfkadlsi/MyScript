using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindCanvas : MonoBehaviour
{
    [SerializeField] private Image leftBlind;
    [SerializeField] private Image rightBlind;

    int screenX, screenY;
    int nonBlindX;
    int uiWidth;

    private void Awake()
    {
        screenX = Screen.width;
        screenY = Screen.height;

        if(!Information.Instance.IsAndroid())
        {
            nonBlindX = screenY / 2;
            uiWidth = (screenX - nonBlindX) / 2;

            leftBlind.rectTransform.sizeDelta = new Vector2(uiWidth, screenY);
            rightBlind.rectTransform.sizeDelta = new Vector2(uiWidth, screenY);
        }
        else
        {
            leftBlind.enabled = false;
            rightBlind.enabled = false;
        }
    }
}
