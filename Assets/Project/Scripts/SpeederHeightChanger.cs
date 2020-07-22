using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederHeightChanger : MonoBehaviour
{
    [SerializeField] private GameObject lowCollider;
    [SerializeField] private GameObject highCollider;

    [SerializeField] private SpriteRenderer renderer;

    public void SetHeightHigh()
    {
        highCollider.SetActive(true);
        lowCollider.SetActive(false);

        renderer.sortingOrder = 20;
    }

    public void SetHeightLow()
    {
        lowCollider.SetActive(true);
        highCollider.SetActive(false);

        renderer.sortingOrder = 10;
    }
}
