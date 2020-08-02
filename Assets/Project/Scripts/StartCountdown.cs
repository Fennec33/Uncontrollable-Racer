using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{
    [SerializeField] private SpeederMovement playerMovement;
    [SerializeField] private SpeederAI[] speederAIs;

    private void Start()
    {
        playerMovement.enabled = false;

        for (int i = 0; i < speederAIs.Length; i++)
        {
            speederAIs[i].enabled = false;
        }
    }

    public void StartRace()
    {
        TurnSpeederControllersOn();
    }

    private void TurnSpeederControllersOn()
    {
        playerMovement.enabled = true;

        for (int i = 0; i < speederAIs.Length; i++)
        {
            speederAIs[i].enabled = true;
        }
    }
}
