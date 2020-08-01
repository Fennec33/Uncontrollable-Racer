using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtBridgeCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LapTracker lapTracker = collision.GetComponent<LapTracker>();
        lapTracker.PausePositionUpdate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LapTracker lapTracker = collision.GetComponent<LapTracker>();
        lapTracker.UnpausePositionUpdate();
    }
}
