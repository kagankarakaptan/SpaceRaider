using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Camera>().fieldOfView = 500f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Math.Abs(transform.GetComponent<Camera>().fieldOfView - 60f) < 1f)
            transform.GetComponent<Camera>().fieldOfView = 60f;
        else
            transform.GetComponent<Camera>().fieldOfView = Mathf.Lerp(transform.GetComponent<Camera>().fieldOfView, 60f, 0.0075f);
    }
}
