using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightChangerTrigger : MonoBehaviour
{
    [SerializeField] bool highTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Speeder")
        {
            SpeederHeightChanger _speeder = collision.GetComponent<SpeederHeightChanger>();

            if (highTrigger) _speeder.SetHeightHigh();
            else _speeder.SetHeightLow();
        }
    }
}
