using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpark : MonoBehaviour
{
    int count = 0;
    void Update()
    {
        count++;
        if (count >= 4) Destroy(gameObject);
    }
}
