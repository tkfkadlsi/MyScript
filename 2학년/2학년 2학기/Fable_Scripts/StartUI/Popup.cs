using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct PopupTexts
{
    public Sprite popupSprites;
    public string titleTexts;
    [TextArea] public string infoTexts;
}
public class Popup : MonoBehaviour
{
    [SerializeField] private GameObject popupObj;
    [SerializeField] private List<PopupTexts> popupTexts;
    [SerializeField] private List<PopupTexts> windowTexts;

    [SerializeField] private bool isApplyWindowVersion = false;

    private Image popupImage;

    private TextMeshProUGUI titleText;
    private TextMeshProUGUI descriptionText;

    private Button beforeButton;
    private Button afterButton;
    private Button checkButton;

    private int count;

    private void Awake()
    {
        popupImage = popupObj.transform.Find("PopupImage").GetComponent<Image>();
        titleText = popupObj.transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
        descriptionText = popupObj.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        beforeButton = popupObj.transform.Find("Before").GetComponent<Button>();
        afterButton = popupObj.transform.Find("After").GetComponent<Button>();
        checkButton = popupObj.transform.Find("Check").GetComponent<Button>();
        popupObj.SetActive(false);
    }

    public void OpenTutorialPanel()
    {
        count = 0;
        popupObj.SetActive(true);
        SyncUI();
        ButtonSetting(false, true, false);
    }

    public void BeforeButton()
    {
        count--;
        count = Mathf.Clamp(count, 0, popupTexts.Count);

        SyncUI();
        ButtonSetting(count != 0, true ,false);
    }

    public void AfterButton()
    {
        count++;
        count = Mathf.Clamp(count, 0, popupTexts.Count - 1);
        SyncUI();

        ButtonSetting(true, count != popupTexts.Count - 1, count == popupTexts.Count - 1);
    }

    private void SyncUI()
    {
        List<PopupTexts> popups;
        if (isApplyWindowVersion)
        {
            if (!Information.Instance.IsAndroid()) popups = windowTexts;
            else popups = popupTexts;
        }
        else popups = popupTexts;

        popupObj.SetActive(true);
        popupImage.sprite = popups[count].popupSprites;
        titleText.text = popups[count].titleTexts;
        descriptionText.text = popups[count].infoTexts;
    }

    private void ButtonSetting(bool isbeforeButton, bool isAfterButton, bool isCheckButton)
    {
        beforeButton.gameObject.SetActive(isbeforeButton);
        afterButton.gameObject.SetActive(isAfterButton);
        checkButton.gameObject.SetActive(isCheckButton);
    }

    public void CheckButton()
    {
        popupObj.SetActive(false);
    }
}
