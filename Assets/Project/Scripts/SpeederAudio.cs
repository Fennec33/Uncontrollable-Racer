using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederAudio : MonoBehaviour
{
    [SerializeField] private float crashSoudDelayTime = 1;

    [SerializeField] private AudioSource engineSound;
    [SerializeField] private AudioSource crashSound;

    private bool _playing = false;
    private float _timeSinceLastCrash = 0f;

    public void EngineSound(bool on)
    {
        if (on && !_playing)
        {
            engineSound.Play();
            _playing = true;
        }
        else if (!on && _playing)
        {
            engineSound.Stop();
            _playing = false;
        }
    }

    public void playCrashSound()
    {
        if (_timeSinceLastCrash >= crashSoudDelayTime)
        {
            crashSound.Play();
            _timeSinceLastCrash = 0f;
        }
    }

    private void Update()
    {
        _timeSinceLastCrash += Time.deltaTime;
    }
}
