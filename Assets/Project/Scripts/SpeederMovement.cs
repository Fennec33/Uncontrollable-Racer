using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float breakForce =2.5f;
    [SerializeField] private float turnSpeed = 120f;

    private Rigidbody2D _rigidbody;

    private float _normalDrag;

    public bool IsAccelerating { private get; set; }
    public bool IsTurning { private get; set; }
    public float TurnDirection { private get; set; }

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
        }

        if (IsTurning)
        {
            Turn();
        }
    }

    private void Accelerate()
    {
        _rigidbody.AddForce(forwardSpeed * transform.up);
    }

    private void Turn()
    {
        transform.Rotate(Time.deltaTime * turnSpeed * TurnDirection * Vector3.back);
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
