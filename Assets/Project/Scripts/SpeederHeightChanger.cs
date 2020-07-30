using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederHeightChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mainRenderer;
    [SerializeField] private SpriteRenderer flameMain;
    [SerializeField] private SpriteRenderer flameLeft;
    [SerializeField] private SpriteRenderer flameRight;

    private int _layerTrackColliderLow = 9;
    private int _layerTrackColliderHigh = 10;

    public void SetHeightHigh()
    {
        gameObject.layer = _layerTrackColliderHigh;

        SetSortingLayerOfSpeeder(110);
    }

    public void SetHeightLow()
    {
        gameObject.layer = _layerTrackColliderLow;

        SetSortingLayerOfSpeeder(90);
    }

    private void SetSortingLayerOfSpeeder(int layer)
    {
        mainRenderer.sortingOrder = layer;
        flameMain.sortingOrder = layer - 1;
        flameLeft.sortingOrder = layer - 1;
        flameRight.sortingOrder = layer - 1;
    }
}
