using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float turnSpeed;

    public bool IsAccelerating { private get; set; }
    public bool IsBreaking { private get; set; }
    public bool IsTurning { private get; set; }
    public float TurnDirection { private get; set; }

    private void FixedUpdate()
    {
        if (IsAccelerating)
        {
            Accelerate();
        }

        if (IsBreaking)
        {
            Break();
        }

        if (IsTurning)
        {
            Turn();
        }
    }

    private void Accelerate()
    {
        transform.position += Time.deltaTime * forwardSpeed * transform.up;
    }

    private void Break()
    {
        transform.position += Time.deltaTime * -forwardSpeed * transform.up;
    }

    private void Turn()
    {
        transform.Rotate(Time.deltaTime * turnSpeed * TurnDirection * Vector3.back);
    }
}
