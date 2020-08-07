using UnityEngine;

public class SpeederAI : MonoBehaviour
{
    [SerializeField] private SpeederMovement speeder;
    [SerializeField] private Transform startingWaypoint;
    [SerializeField] private float stopAcceleratingAngle = 40;
    
    private Vector3 _currentWaypoint;
    private Vector3 _vectorToTarget;
    private float _turnSpeed;

    private void Start()
    {
        _currentWaypoint = startingWaypoint.position;
        _turnSpeed = speeder.GetTurnSpeed();
    }

    private void Update()
    {
        TurnTowardsCurrentWaypoint();
        AccelerationControl();
    }

    private void TurnTowardsCurrentWaypoint()
    {
        _vectorToTarget = _currentWaypoint - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: _vectorToTarget);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
    }

    private void AccelerationControl()
    {
        _vectorToTarget = _currentWaypoint - transform.position;

        if (Vector3.Angle(_vectorToTarget, transform.up) < stopAcceleratingAngle)
        {
            speeder.StartAccelerating();
        }
        else
        {
            speeder.StopAccelerating();
        }
    }

    public void SetNewWaypoint(Transform newPoint)
    {
        _currentWaypoint = newPoint.position;
    }
}
