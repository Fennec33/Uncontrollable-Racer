using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpeederMovement speeder;

    private InputMaster _controlls;

    private void Awake()
    {
        _controlls = new InputMaster();
    }

    private void OnEnable()
    {
        _controlls.Player.Accelerate.performed += Accelerate;
        _controlls.Player.Accelerate.Enable();

        _controlls.Player.Break.performed += Break;
        _controlls.Player.Break.Enable();

        _controlls.Player.Turn.performed += Turn;
        _controlls.Player.Turn.Enable();
    }

    private void OnDisable()
    {
        _controlls.Player.Accelerate.performed -= Accelerate;
        _controlls.Player.Accelerate.Disable();

        _controlls.Player.Break.performed -= Break;
        _controlls.Player.Break.Disable();

        _controlls.Player.Turn.performed -= Turn;
        _controlls.Player.Turn.Disable();
    }

    private void Accelerate(InputAction.CallbackContext context)
    {
        speeder.Accelerate();
    }

    private void Break(InputAction.CallbackContext context)
    {
        speeder.Break();
    }

    private void Turn(InputAction.CallbackContext context)
    {
        speeder.Turn(context.ReadValue<float>());
    }
}
