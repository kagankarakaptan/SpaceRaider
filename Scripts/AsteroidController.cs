using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float rotateSpeed;
    public Vector3 rotateVector;
    public GameObject INVOKER;
    public float asteroidDamage;
    public int asteroidValue;
    public int asteroidType;



    void Start()
    {
        INVOKER = GameObject.Find("INVOKER");
        rotateSpeed = 0.1f;
        rotateVector = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range(1f, 10f)) * rotateSpeed;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - INVOKER.GetComponent<InvokerController>().spaceShipSpeed);
        transform.Rotate(rotateVector);

        if (transform.position.z < -10f || transform.position.x > 100f || transform.position.x < -100f || transform.position.y > 100f || transform.position.y < -100f)
            Destroy(gameObject);

        // || transform.position.x > 100f || transform.position.x < -100f || transform.position.y > 100f || transform.position.y < -100f
    }
}
