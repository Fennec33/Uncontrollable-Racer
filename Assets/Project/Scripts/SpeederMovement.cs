using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public void Accelerate()
    {
        Debug.Log("Accelerating");
    }

    public void Break()
    {
        Debug.Log("Breaking");
    }

    public void Turn(float direction)
    {
        Debug.Log("Turning " + direction);
    }
}
