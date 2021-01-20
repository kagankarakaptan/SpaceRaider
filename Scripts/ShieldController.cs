using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{


    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject.Find("UI").GetComponent<UIController>().shieldLifeTime -= Time.fixedDeltaTime;

        if (GameObject.Find("UI").GetComponent<UIController>().shieldLifeTime <= 0f)
        {
            transform.parent.transform.parent.GetComponent<AbilityController>().isShieldActive = false;
            Destroy(gameObject);

            GameObject.Find("UI").GetComponent<UIController>().shieldLifeTime = PlayerPrefs.GetFloat("shieldLifeTime") + 10f;
            GameObject.Find("UI").GetComponent<UIController>().shieldCapacity = PlayerPrefs.GetInt("shieldCapacity") + 3;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("asteroid"))
        {
            GameObject.Find("UI").GetComponent<UIController>().shieldCapacity--;
            Instantiate(Resources.Load("Prefabs/Effects/DestroyEffects/AsteroidDestroyEffect" + (collision.transform.GetComponent<AsteroidController>().asteroidType - 1).ToString()), transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            if (GameObject.Find("UI").GetComponent<UIController>().shieldCapacity <= 0)
                GameObject.Find("UI").GetComponent<UIController>().shieldLifeTime = 0f;




        }
    }

}
