using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetXSpinner : MonoBehaviour
{


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0.002f, 0.03f, -0.01f);
    }
}
