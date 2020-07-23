using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederAI : MonoBehaviour
{
    [SerializeField] SpeederMovement speeder;
    [SerializeField] Transform startingWaypoint;
    [SerializeField] float turningSpeed = 150f;
    
    private Vector3 _currentWaypoint;
    private Vector3 _vectorToTarget;

    private void Start()
    {
        _currentWaypoint = startingWaypoint.position;
    }

    private void Update()
    {
        TurnTowardsCurrentWaypoint();
        Accelerate();
    }

    private void TurnTowardsCurrentWaypoint()
    {
        _vectorToTarget = _currentWaypoint - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: _vectorToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);
    }

    private void Accelerate()
    {
        speeder.IsAccelerating = true;
    }

    public void SetNewWaypoint(Transform newPoint)
    {
        _currentWaypoint = newPoint.position;
    }
}
