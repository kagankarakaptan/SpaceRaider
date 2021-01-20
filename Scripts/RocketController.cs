using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class RocketController : MonoBehaviour
{

    public float rocketSpeed;
    public float rotateSpeed;

    

    // Update is called once per frame
    void FixedUpdate()
    {


        //moving the missile
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + rocketSpeed);
        //rotating the missile
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z + rotateSpeed);

        if (transform.position.z > 500f)
            Destroy(transform.parent.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("asteroid"))
        {
            
            Instantiate(Resources.Load("Prefabs/Effects/DestroyEffects/AsteroidDestroyEffect" + (collision.transform.GetComponent<AsteroidController>().asteroidType-1).ToString()), transform.position, Quaternion.identity);

            GameObject.Find("UI").GetComponent<UIController>().mineScore += collision.transform.GetComponent<AsteroidController>().asteroidValue;

            Destroy(collision.gameObject);
            Destroy(transform.parent.gameObject);

        }
    }
}
