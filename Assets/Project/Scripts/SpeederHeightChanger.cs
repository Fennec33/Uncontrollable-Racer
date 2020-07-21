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
        lowCollider.SetActive(false);
        highCollider.SetActive(true);

        renderer.sortingOrder = 20;
    }

    public void SetHeightLow()
    {
        highCollider.SetActive(false);
        lowCollider.SetActive(true);

        renderer.sortingOrder = 10;
    }
}
