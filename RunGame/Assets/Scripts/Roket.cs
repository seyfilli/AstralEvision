using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    float hiz = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, hiz * Time.deltaTime, 0);
    }
}
