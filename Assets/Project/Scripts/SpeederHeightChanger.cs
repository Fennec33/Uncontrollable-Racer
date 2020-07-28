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

        renderer.sortingOrder = 110;
        flameMain.sortingOrder = 109;
        flameLeft.sortingOrder = 109;
        flameRight.sortingOrder = 109;
    }

    public void SetHeightLow()
    {
        lowCollider.SetActive(true);
        highCollider.SetActive(false);

        renderer.sortingOrder = 90;
        flameMain.sortingOrder = 89;
        flameLeft.sortingOrder = 89;
        flameRight.sortingOrder = 89;
    }
}
