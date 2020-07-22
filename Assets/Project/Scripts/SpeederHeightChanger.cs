using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederHeightChanger : MonoBehaviour
{
    [SerializeField] private GameObject lowCollider;
    [SerializeField] private GameObject highCollider;

    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer flameMain;
    [SerializeField] private SpriteRenderer flameLeft;
    [SerializeField] private SpriteRenderer flameRight;

    public void SetHeightHigh()
    {
        highCollider.SetActive(true);
        lowCollider.SetActive(false);

        renderer.sortingOrder = 20;
        flameMain.sortingOrder = 19;
        flameLeft.sortingOrder = 19;
        flameRight.sortingOrder = 19;
    }

    public void SetHeightLow()
    {
        lowCollider.SetActive(true);
        highCollider.SetActive(false);

        renderer.sortingOrder = 10;
        flameMain.sortingOrder = 9;
        flameLeft.sortingOrder = 9;
        flameRight.sortingOrder = 9;
    }
}
