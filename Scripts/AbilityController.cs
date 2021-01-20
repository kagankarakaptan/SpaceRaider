using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public GameObject mainRoot;

    public GameObject missileHolder;
    public GameObject newMissile;
    public bool launchMissileOrder;
    public bool isMissileOnTheRight;
    public bool isMissileReady;

    public float startForMissile;
    public float endForMissile;
    public bool startCounting;

    public bool isShieldActive;


    // Start is called before the first frame update
    void Start()
    {

        mainRoot = GameObject.Find("MainRoot");
        missileHolder = GameObject.Find("MainRoot");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            launchMissileOrder = true;
        else
            launchMissileOrder = false;

        if (Input.GetKey(KeyCode.Alpha1))
            ShieldCall();
    }

    void FixedUpdate()
    {
        if (startCounting)
            startForMissile += Time.fixedDeltaTime;

        if (startForMissile > endForMissile)
        {
            isMissileReady = true;
            startForMissile = 0f;
            startCounting = false;
        }

        if (launchMissileOrder)
            MissileShot();
    }

    public void MissileShot()
    {
        if (isMissileReady && mainRoot.GetComponent<MainRootController>().canMove && GameObject.Find("UI").GetComponent<UIController>().missileCount > 0)
        {
            GameObject.Find("UI").GetComponent<UIController>().missileCount--;

            float rocketBodyLocalPosX;
            string itemPath = "Prefabs/Abilities/Rocket";

            if (isMissileOnTheRight)
                rocketBodyLocalPosX = 0.75f;
            else
                rocketBodyLocalPosX = -0.75f;

            newMissile = Instantiate(Resources.Load(itemPath), missileHolder.transform.position, missileHolder.transform.rotation) as GameObject;
            newMissile.transform.GetChild(0).transform.localPosition = new Vector3(rocketBodyLocalPosX, newMissile.transform.GetChild(0).transform.localPosition.y, newMissile.transform.GetChild(0).transform.localPosition.z);

            isMissileOnTheRight = !isMissileOnTheRight;
            isMissileReady = false;
            startCounting = true;
        }

    }

    public void ShieldCall()
    {
        if (!isShieldActive && mainRoot.GetComponent<MainRootController>().canMove && GameObject.Find("UI").GetComponent<UIController>().shieldCount > 0)
        {
            GameObject.Find("UI").GetComponent<UIController>().shieldCount--;

            Vector3 shieldSpawnPos = new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, transform.GetChild(0).position.z + 1.75f);
            GameObject shield = Instantiate(Resources.Load("Prefabs/Abilities/Shield"), shieldSpawnPos, transform.rotation) as GameObject;
            
            shield.transform.SetParent(transform.GetChild(0));
            isShieldActive = true;
        }
    }
}
