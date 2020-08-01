using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederVFX : MonoBehaviour
{
    [SerializeField] private float maxTurnAngle = 30f;
    [SerializeField] private float turnSpeed = 150f;

    [SerializeField] private GameObject flames;
    [SerializeField] private GameObject collisionSpark;
    
    [SerializeField] private float crashSparkDelayTime = 1;

    private float _currentTurnAngle = 0f;
    private float _timeSinceLastCrash = 0f;

    private void Update()
    {
        _timeSinceLastCrash += Time.deltaTime;
    }

    public void TurnSpeeder(float direction)
    {
        _currentTurnAngle += -direction * turnSpeed * Time.deltaTime;

        if (_currentTurnAngle > maxTurnAngle) _currentTurnAngle = maxTurnAngle;
        if (_currentTurnAngle < -maxTurnAngle) _currentTurnAngle = -maxTurnAngle;

        transform.localRotation = Quaternion.Euler(0f, _currentTurnAngle, 0f);
    }

    public void TurnReset()
    {
        if (_currentTurnAngle > 0)
        {
            _currentTurnAngle += -1f * turnSpeed * Time.deltaTime;
        }

        if (_currentTurnAngle < 0)
        {
            _currentTurnAngle += 1f * turnSpeed * Time.deltaTime;
        }

        transform.localRotation = Quaternion.Euler(0f, _currentTurnAngle, 0f);
    }

    public void TurnFlamesOn()
    {
        flames.SetActive(true);
    }

    public void TurnFlamesOff()
    {
        flames.SetActive(false);
    }

    public void CollisionSparkEffect(ContactPoint2D contact)
    {
        if (_timeSinceLastCrash >= crashSparkDelayTime)
        {
            Instantiate(collisionSpark, contact.point, Quaternion.identity);
            _timeSinceLastCrash = 0f;
        }
    }
}
