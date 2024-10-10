using TMPro;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField] private UINavigation StartUI;

    [SerializeField] private GameObject thanksPanel;
    [SerializeField] private GameObject signPanel;

    [SerializeField] private TextMeshProUGUI signTMP;
    [SerializeField] private TMP_InputField IDinput;
    [SerializeField] private TMP_InputField PWinput;

    [SerializeField] private GameObject titleObject;

    public SignType SignType;

    public static TitleUIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Screen.SetResolution(Screen.width, (Screen.width * 9) / 16, true);
        }
    }

    private void Start()
    {
        if (Instance == this)
            UINavigation.ChangeFocus(StartUI);
    }

    public void TutorialFinish()
    {
        UINavigation.ChangeFocus(StartUI);
    }

    public void SignUpButton()
    {
        SignType = SignType.SignUp;
        signPanel.SetActive(true);
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(signPanel.GetComponent<UINavigation>());
        signTMP.text = "아이디 생성";
    }

    public void SignInButton()
    {
        SignType = SignType.SignIn;
        signPanel.SetActive(true);
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(signPanel.GetComponent<UINavigation>());
        signTMP.text = "로그인";
    }

    public void ThanksButton()
    {
        thanksPanel.SetActive(true);
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(thanksPanel.GetComponent<UINavigation>());
    }

    public void SignCheckButton()
    {
        if (IDinput.text.Contains(" ") || PWinput.text.Contains(" "))
        {
            BackendManager.Instance.ErrorMsg("공백은 불가능 합니다.");
            return;
        }

        if (IDinput.text.Length > 16)
        {
            BackendManager.Instance.ErrorMsg("이름과 비밀번호는 최대 16자입니다.");
            return;
        }

        if (SignType == SignType.SignUp)
        {
            BackendManager.Instance.CustomSignUp(IDinput.text, PWinput.text);
            ExitSignPanel();
        }
        else if (SignType == SignType.SignIn)
        {
            BackendManager.Instance.CustomLogin(IDinput.text, PWinput.text);
        }
    }

    public void ExitThanks()
    {
        UINavigation.FocusUI.ResetColor();
        thanksPanel.SetActive(false);
        UINavigation.ChangeFocus(StartUI);
    }

    public void ExitSignPanel()
    {
        UINavigation.FocusUI.ResetColor();
        signPanel.SetActive(false);
        UINavigation.ChangeFocus(StartUI);
    }

    public void LoginSuccess()
    {
        UINavigation.FocusUI.ResetColor();
        UINavigation.ChangeFocus(UIManager.Instance.StartUI);
        titleObject.SetActive(false);
    }
}