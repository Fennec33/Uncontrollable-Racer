using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    private bool _playing = false;

    public void EngineSound(bool on)
    {
        if (on && !_playing)
        {
            source.Play();
            _playing = true;
        }
        else if (!on && _playing)
        {
            source.Stop();
            _playing = false;
        }
    }
}
