using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputs;

public class PlayerInput : MonoBehaviour, IGameInputActions
{
    private CamRig camRig;

    private float delayTime = 0.2f;
    private float[] countDelay = new float[7];

    private void Awake()
    {
        camRig = FindObjectOfType<CamRig>();
        Array.Fill<float>(countDelay, delayTime);
    }

    private void Start()
    {
        Information.Instance.PlayerInputs.GameInput.SetCallbacks(this);
    }

    private void Update()
    {
        for (int i = 0; i < countDelay.Length; i++)
        {
            countDelay[i] -= Time.deltaTime;
        }
    }

    public void OnCamLock(InputAction.CallbackContext context)
    {
        if (context.performed)
            camRig.CamLock();

    }

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressUp();

    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressDown();

    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressLeft();

    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressRight();

    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressEnter();

    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressExit();

    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
            UINavigation.FocusUI.PressSpace();

    }
}
