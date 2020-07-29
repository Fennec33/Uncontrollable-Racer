using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LapTracker : MonoBehaviour
{
    public PathCreator pathCreator;
    public RaceManager raceManager;

    private bool _startedLap = true;
    private bool _finishingLap = false;

    private int _id;
    private float _positionOnPath;

    void Start()
    {
        _id = raceManager.RequestNewID(this.gameObject);
    }

    void Update()
    {
        _positionOnPath = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        raceManager.UpdateCurrentPosition(_id, _positionOnPath);
        checkLap();
    }

    private void checkLap()
    {
        if (_positionOnPath < 5f && _startedLap && _finishingLap)
        {
            raceManager.FinishedLap(_id);
            _startedLap = false;
            _finishingLap = false;
        }
        
        if (_positionOnPath < 5f && (!_startedLap || !_finishingLap))
        {
            _startedLap = false;
            _finishingLap = false;
        }

        if (_positionOnPath > 5f && _positionOnPath < 10f)
        {
            _startedLap = true;
        }

        if (_positionOnPath > 170f && _startedLap)
        {
            _finishingLap = true;
        }
    }
}
