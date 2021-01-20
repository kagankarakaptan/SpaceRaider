using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    GameObject abilityController;
    GameObject mainRoot;
    GameObject INVOKER;

    public int missileCount;

    public int shieldCount;
    public int shieldCapacity;
    public float shieldLifeTime;

    public float bodyArmor;

    public float travelScore;
    public int mineScore;
    public float revenueCoefficient;

    GameObject missileCountText;
    GameObject shieldCountText;
    GameObject shieldCapacityText;
    GameObject shieldLifeTimeText;

    GameObject travelScoreText;
    GameObject mineScoreText;

    GameObject bodyArmorText;
    public float maxBodyArmor;

    public GameObject travelTime;




    // Start is called before the first frame update
    void Start()
    {
        travelTime = GameObject.Find("TravelTime");

        abilityController = GameObject.Find("SpaceShip");
        mainRoot = GameObject.Find("MainRoot");
        INVOKER = GameObject.Find("INVOKER");

        missileCountText = GameObject.Find("MissileCount");
        shieldCountText = GameObject.Find("ShieldCount");
        shieldCapacityText = GameObject.Find("ShieldCapacity");
        shieldLifeTimeText = GameObject.Find("ShieldLifeTime");
        travelScoreText = GameObject.Find("TravelScore");
        mineScoreText = GameObject.Find("MineScore");
        bodyArmorText = GameObject.Find("BodyArmor");

        //upgrade stats + initial stats
        bodyArmor = PlayerPrefs.GetFloat("bodyArmor") + 100f;
        missileCount = PlayerPrefs.GetInt("missileCount") + 5;
        shieldCount = PlayerPrefs.GetInt("shieldCount") + 1;
        shieldLifeTime = PlayerPrefs.GetFloat("shieldLifeTime") + 10f;
        shieldCapacity = PlayerPrefs.GetInt("shieldCapacity") + 3;
        revenueCoefficient = PlayerPrefs.GetFloat("revenueCoefficient") + 1f;






        maxBodyArmor = bodyArmor;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Time
        travelTime.GetComponent<Text>().text = INVOKER.GetComponent<InvokerController>().travelTime.ToString("0.00");

        //HP
        if (bodyArmor <= 0f)
            bodyArmorText.GetComponent<Text>().text = "0%";
        else
            bodyArmorText.GetComponent<Text>().text = (bodyArmor / maxBodyArmor * 100).ToString("0") + "%";



        //money (scores)
        if (mainRoot.GetComponent<MainRootController>().canMove)
        {
            travelScore += INVOKER.GetComponent<InvokerController>().spaceShipSpeed * revenueCoefficient * Time.fixedDeltaTime;
        }

        travelScoreText.GetComponent<Text>().text = travelScore.ToString("0.00");
        mineScoreText.GetComponent<Text>().text = mineScore.ToString();


        //abilities
        missileCountText.GetComponent<Text>().text = missileCount.ToString();
        shieldCountText.GetComponent<Text>().text = shieldCount.ToString();
        shieldCapacityText.GetComponent<Text>().text = shieldCapacity.ToString();
        shieldLifeTimeText.GetComponent<Text>().text = shieldLifeTime.ToString("0.00");

        if (abilityController.GetComponent<AbilityController>().isShieldActive)
        {
            shieldCapacityText.GetComponent<Text>().enabled = true;
            shieldLifeTimeText.GetComponent<Text>().enabled = true;

        }
        else
        {
            shieldCapacityText.GetComponent<Text>().enabled = false;
            shieldLifeTimeText.GetComponent<Text>().enabled = false;
        }



    }
}
