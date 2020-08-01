using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private int numberOfLaps = 3;
    [SerializeField] private RaceUI raceUI;
    
    public GameObject player;
    public int numberOfSpeeders = 6;

    private SpeederPlacementData[] _speeders;
    private int _nextID = 0;
    private int _playerID;
    private bool _raceOver = false;
    private int _playerRanking = 0;

    private void Awake()
    {
        _speeders = new SpeederPlacementData[6];
    }

    private void Update()
    {
        _playerRanking = GetPlayerRanking();
        raceUI.DisplayCurrentRanking(_playerRanking);
    }

    public int RequestNewID(GameObject speeder)
    {
        int value = _nextID;
        _nextID++;

        if (speeder == player)
        {
            _playerID = value;
        }

        SpeederPlacementData temp = new SpeederPlacementData(value);
        _speeders[value] = temp;
        return value;
    }

    public void UpdateCurrentPosition(int id, float newDistance)
    {
        _speeders[id].SetPosition(newDistance);
    }

    public void FinishedLap(int id)
    {
        _speeders[id].IncreaseLap();

        if (_speeders[_playerID].GetLap() > numberOfLaps && !_raceOver) EndRace();
    }

    private int GetPlayerRanking()
    {
        int ranking = 1;
        float playerPosition = _speeders[_playerID].GetPosition();
        int playerLap = _speeders[_playerID].GetLap();
        float position;
        int lap;

        for (int i = 0; i < _speeders.Length; i++)
        {
            if (i == _playerID) continue;

            position = _speeders[i].GetPosition();
            lap = _speeders[i].GetLap();

            if (position > playerPosition && lap == playerLap || lap > playerLap)
            {
                ranking++;
            }
        }
        
        return ranking;
    }

    private void EndRace()
    {
        _raceOver = true;
        Debug.Log("Race Over, you placed " + GetPlayerRanking());
    }
}
