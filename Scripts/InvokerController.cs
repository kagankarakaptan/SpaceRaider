using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokerController : MonoBehaviour
{
    public float travelTime;
    public int invokeType;

    public bool lightSpeed;
    public float startFirstMovement;
    public float endFirstMovement;

    public float spaceShipSpeed;

    public float startForInvoke;
    public float endForInvoke;

    public GameObject newAsteroid;
    public GameObject ship;

    private void Start()
    {
        ship = GameObject.Find("Ship");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lightSpeed && !ship.GetComponent<ShipCollisionDetection>().startDying)
            travelTime += Time.fixedDeltaTime;

        if (travelTime < 30f)
            invokeType = 2;
        else if (120f > travelTime && travelTime >= 30f)
            invokeType = 3;
        else if (240f > travelTime && travelTime >= 120f)
            invokeType = 4;
        else if (480f > travelTime && travelTime >= 240f)
            invokeType = 5;
        else if (960f > travelTime && travelTime >= 480f)
            invokeType = 6;
        else if (1920f > travelTime && travelTime >= 960f)
            invokeType = 7;
        else if (travelTime >= 1920f)
            invokeType = 8;



        startForInvoke += Time.fixedDeltaTime;

        if (lightSpeed)
            startFirstMovement += Time.fixedDeltaTime;

        if (lightSpeed && startFirstMovement < endFirstMovement)
        {
            spaceShipSpeed = 20f;
            endForInvoke = 0.005f;
        }

        else if (startFirstMovement > endFirstMovement)
        {
            lightSpeed = false;
            spaceShipSpeed /= 20f;
            endForInvoke *= 20f;
            startFirstMovement = endFirstMovement;
            Destroy(GameObject.Find("LightSpeedEffect"), 2);
            GameObject.Find("MainRoot").GetComponent<MainRootController>().canMove = true;
        }

        if (startForInvoke > endForInvoke)
        {

            //creating new asteroid
            string itemPath = "Prefabs/Asteroids/Asteroid" + Random.Range(1, invokeType).ToString();
            //string itemPath = "Prefabs/Asteroids/Asteroid2";

            float asteroidSizeMultiplierX = Random.Range(1.75f, 5f);
            float asteroidSizeMultiplierY = Random.Range(1.75f, 5f);
            float asteroidSizeMultiplierZ = Random.Range(1.75f, 5f);

            float asteroidInitialSpeed = Random.Range(1f, 1000f);
            //if (!lightSpeed)
            //    asteroidInitialSpeed *= spaceShipSpeed;
            Vector3 initialPos = new Vector3(Random.Range(-35f, 35f), Random.Range(-35f, 35f), 1500f);
            Vector3 asteroidDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            //Vector3 asteroidDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            Vector3 asteroidForce = asteroidDirection * asteroidInitialSpeed;
            newAsteroid = Instantiate(Resources.Load(itemPath), initialPos, Quaternion.identity) as GameObject;
            newAsteroid.AddComponent<AsteroidController>();
            newAsteroid.GetComponent<AsteroidController>().asteroidDamage = Random.Range(20f * invokeType, 30f * invokeType); //setting the asteroid's damage
            newAsteroid.GetComponent<AsteroidController>().asteroidValue = invokeType * invokeType * invokeType * invokeType * invokeType / 16; //setting the asteroid's value
            newAsteroid.GetComponent<AsteroidController>().asteroidType = invokeType; //setting the asteroid's type
            newAsteroid.transform.localScale = new Vector3(asteroidSizeMultiplierX * newAsteroid.transform.localScale.x, asteroidSizeMultiplierY * newAsteroid.transform.localScale.y, asteroidSizeMultiplierZ * newAsteroid.transform.localScale.z);
            newAsteroid.GetComponent<Rigidbody>().AddForce(asteroidForce);

            startForInvoke = 0.0f;
            endForInvoke *= 0.9999f;

            if (!lightSpeed)
            {
                spaceShipSpeed += 0.01f * 1 / invokeType;
                GameObject.Find("MainRoot").GetComponent<MainRootController>().rotateAcceleration += 0.0001f * 1 / invokeType;
            }



        }



    }
}
