using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpeederMovement speeder;

    private InputMaster _controlls;

    private bool _accelerating;
    private bool _breaking;
    private bool _turning;

    private void Awake()
    {
        _controlls = new InputMaster();
    }

    private void OnEnable()
    {
        _controlls.Player.Accelerate.performed += AccelerateOn;
        _controlls.Player.Accelerate.canceled += AccelerateOff;
        _controlls.Player.Accelerate.Enable();

        _controlls.Player.Break.performed += BreakOn;
        _controlls.Player.Break.canceled += BreakOff;
        _controlls.Player.Break.Enable();

        _controlls.Player.Turn.performed += TurnOn;
        _controlls.Player.Turn.canceled += TurnOff;
        _controlls.Player.Turn.Enable();
    }

    private void OnDisable()
    {
        _controlls.Player.Accelerate.performed -= AccelerateOn;
        _controlls.Player.Accelerate.canceled -= AccelerateOff;
        _controlls.Player.Accelerate.Disable();

        _controlls.Player.Break.performed -= BreakOn;
        _controlls.Player.Break.canceled -= BreakOff;
        _controlls.Player.Break.Disable();

        _controlls.Player.Turn.performed -= TurnOn;
        _controlls.Player.Turn.canceled -= TurnOff;
        _controlls.Player.Turn.Disable();
    }

    private void AccelerateOn(InputAction.CallbackContext context)
    {
        speeder.IsAccelerating = true;
    }

    private void AccelerateOff(InputAction.CallbackContext context)
    {
        speeder.IsAccelerating = false;
    }

    private void BreakOn(InputAction.CallbackContext context)
    {
        speeder.IsBreaking = true;
    }

    private void BreakOff(InputAction.CallbackContext context)
    {
        speeder.IsBreaking = false;
    }

    private void TurnOn(InputAction.CallbackContext context)
    {
        speeder.TurnDirection = context.ReadValue<float>();
        speeder.IsTurning = true;
    }

    private void TurnOff(InputAction.CallbackContext context)
    {
        speeder.IsTurning = false;
    }


}
