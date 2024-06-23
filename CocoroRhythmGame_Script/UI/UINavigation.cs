using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour
{
    public static UINavigation FocusUI { get; private set; }

    public static void ChangeFocus(UINavigation uinav)
    {
        Debug.Log(uinav);
        uinav.SetFocusMy();
    }

    [SerializeField] private UINavigation upUI;
    [SerializeField] private UINavigation downUI;
    [SerializeField] private UINavigation leftUI;
    [SerializeField] private UINavigation rightUI;

    [SerializeField] private UINavigation enterUI;
    [SerializeField] private UINavigation exitUI;
    [SerializeField] private UINavigation spaceUI;

    [SerializeField] private UnityEvent upEvent;
    [SerializeField] private UnityEvent downEvent;
    [SerializeField] private UnityEvent leftEvent;
    [SerializeField] private UnityEvent rightEvent;

    [SerializeField] private UnityEvent enterEvent;
    [SerializeField] private UnityEvent exitEvent;
    [SerializeField] private UnityEvent spaceEvent;

    [SerializeField] private Color originColor = Color.white;
    [SerializeField] private Color focusColor = Color.yellow;

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetFocusMy()
    {
        if (FocusUI != null)
            FocusUI.ResetColor();
        FocusUI = this;
        if (img != null)
            img.color = focusColor;
    }

    public void PressUp()
    {
        upEvent?.Invoke();
        if (upUI != null)
        {
            upUI.SetFocusMy();
            ResetColor();
        }
    }

    public void PressDown()
    {
        downEvent?.Invoke();
        if (downUI != null)
        {
            downUI.SetFocusMy();
            ResetColor();
        }
    }

    public void PressLeft()
    {
        leftEvent?.Invoke();
        if (leftUI != null)
        {
            leftUI.SetFocusMy();
            ResetColor();
        }
    }

    public void PressRight()
    {
        rightEvent?.Invoke();
        if (rightUI != null)
        {
            rightUI.SetFocusMy();
            ResetColor();
        }
    }

    public void PressEnter()
    {
        enterEvent?.Invoke();
        if (enterUI != null)
        {
            enterUI.SetFocusMy();
            ResetColor();
        }
    }

    public void PressExit()
    {
        exitEvent?.Invoke();
        if (exitUI != null)
        {
            exitUI.SetFocusMy();
            ResetColor();
        }
    }

    public void PressSpace()
    {
        spaceEvent?.Invoke();
        if (spaceUI != null)
        {
            spaceUI.SetFocusMy();
            ResetColor();
        }
    }

    public void ResetColor()
    {
        img.color = originColor;
    }
}
