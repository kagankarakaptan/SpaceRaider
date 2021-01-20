using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyEffectController : MonoBehaviour
{
    public GameObject INVOKER;

    void Start()
    {
        INVOKER = GameObject.Find("INVOKER");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - INVOKER.GetComponent<InvokerController>().spaceShipSpeed);

        if (transform.position.z < -10f)
            Destroy(gameObject);
    }
}
