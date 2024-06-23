using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputs;

public class TitlePlayerInput : MonoBehaviour, IGameInputActions
{
    PlayerInputs playerInputs;
    public void OnCamLock(InputAction.CallbackContext context)
    {

    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressUp();
        }
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressDown();
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressLeft();
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressRight();
        }
    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressEnter();
        }
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressExit();
        }
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            UINavigation.FocusUI.PressSpace();
        }
    }
}
