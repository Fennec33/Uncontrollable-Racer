using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederVFX : MonoBehaviour
{
    [SerializeField] private float maxTurnAngle = 30f;
    [SerializeField] private float turnSpeed = 150f;

    [SerializeField] private GameObject flames;

    private float _currentTurnAngle = 0;

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
}
