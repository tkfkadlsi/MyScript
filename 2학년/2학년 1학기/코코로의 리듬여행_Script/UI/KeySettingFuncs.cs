using System.Collections;
using TMPro;
using UnityEngine;

public class KeySettingFuncs : MonoBehaviour
{
    [SerializeField] private GameObject WaitPanel;
    [SerializeField] private UINavigation FocusWaitPanel;

    [SerializeField] private TextMeshProUGUI LSText;
    [SerializeField] private TextMeshProUGUI LLText;
    [SerializeField] private TextMeshProUGUI LMText;
    [SerializeField] private TextMeshProUGUI RMText;
    [SerializeField] private TextMeshProUGUI RRText;
    [SerializeField] private TextMeshProUGUI RSText;

    [SerializeField] private TextMeshProUGUI ErrorText;

    private UINavigation BeforeUI;

    private void Awake()
    {
        WaitPanel.SetActive(false);
    }

    private void Start()
    {
        SetTexts();
    }

    public void ChangeKey(int number)
    {
        WaitPanel.SetActive(true);
        UINavigation.FocusUI.ResetColor();
        BeforeUI = UINavigation.FocusUI;
        UINavigation.ChangeFocus(FocusWaitPanel);

        StartCoroutine(ChangeKeyCoroutine(number));
    }

    private IEnumerator ChangeKeyCoroutine(int number)
    {
        KeyCode presskey = KeyCode.None;
        yield return new WaitForSeconds(0.1f);

        yield return new WaitUntil(() => Input.anyKeyDown);
        for (int i = 0; i < 509; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                presskey = (KeyCode)i;
            }
        }

        if (presskey != Information.Instance.OptionData.LS && presskey != Information.Instance.OptionData.LL &&
            presskey != Information.Instance.OptionData.LM && presskey != Information.Instance.OptionData.RM &&
            presskey != Information.Instance.OptionData.RR && presskey != Information.Instance.OptionData.RS)
        {
            switch (number)
            {
                case 0:
                    Information.Instance.OptionData.LS = presskey;
                    break;
                case 1:
                    Information.Instance.OptionData.LL = presskey;
                    break;
                case 2:
                    Information.Instance.OptionData.LM = presskey;
                    break;
                case 3:
                    Information.Instance.OptionData.RM = presskey;
                    break;
                case 4:
                    Information.Instance.OptionData.RR = presskey;
                    break;
                case 5:
                    Information.Instance.OptionData.RS = presskey;
                    break;
            }
            Information.Instance.GetComponent<SaveLoad>().SaveData();
        }
        else
        {
            StartCoroutine(ErrorMsg("키 중복은 지원하지 않습니다."));
        }

        UINavigation.ChangeFocus(BeforeUI);
        WaitPanel.SetActive(false);
        SetTexts();
    }

    private IEnumerator ErrorMsg(string msg)
    {
        ErrorText.text = msg;
        yield return new WaitForSeconds(0.5f);
        ErrorText.text = "";
    }

    private void SetTexts()
    {
        LSText.text = Information.Instance.OptionData.LS.ToString();
        LLText.text = Information.Instance.OptionData.LL.ToString();
        LMText.text = Information.Instance.OptionData.LM.ToString();
        RMText.text = Information.Instance.OptionData.RM.ToString();
        RRText.text = Information.Instance.OptionData.RR.ToString();
        RSText.text = Information.Instance.OptionData.RS.ToString();

        Parsing(LSText);
        Parsing(LLText);
        Parsing(LMText);
        Parsing(RMText);
        Parsing(RRText);
        Parsing(RSText);
    }

    private void Parsing(TextMeshProUGUI text)
    {
        if (text.text == "Quote") text.text = "\'";
        if (text.text == "BackQuote") text.text = "`";
        if (text.text == "Comma") text.text = ",";
        if (text.text == "Period") text.text = ".";
        if (text.text == "Slash") text.text = "/";
        if (text.text == "Semicolon") text.text = ";";
    }
}
