using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 80f;
    [SerializeField] private float breakForce =3f;
    [SerializeField] private float turnSpeed = 150f;

    [SerializeField] private SpeederVFX speederVFX;
    [SerializeField] private SpeederAudio audio;

    private Rigidbody2D _rigidbody;

    private float _normalDrag;

    public bool IsAccelerating { private get; set; }
    public bool IsTurning { private get; set; }
    public float TurnDirection { private get; set; }
    public float GetTurnSpeed() { return turnSpeed; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _normalDrag = _rigidbody.drag;
    }

    private void FixedUpdate()
    {
        if (IsAccelerating)
        {
            Accelerate();
            audio.EngineSound(true);
        }
        else
        {
            NoAccelerate();
            audio.EngineSound(false);
        }

        if (IsTurning)
        {
            Turn();
        }
        else
        {
            NoTurn();
        }
    }

    private void Accelerate()
    {
        _rigidbody.AddForce(forwardSpeed * transform.up);
        speederVFX.TurnFlamesOn();
    }

    private void NoAccelerate()
    {
        speederVFX.TurnFlamesOff();
    }

    private void Turn()
    {
        transform.Rotate(Time.deltaTime * turnSpeed * TurnDirection * Vector3.back);
        speederVFX.TurnSpeeder(TurnDirection);
    }

    public void NoTurn()
    {
        speederVFX.TurnReset();
    }

    public void StartBreaking()
    {
        _rigidbody.drag = breakForce;
    }

    public void StopBreaking()
    {
        _rigidbody.drag = _normalDrag;
    }
}
