using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public GameObject upgradePage;
    public GameObject upgrade2;
    public GameObject upgrade3;

    public int upgradeType;

    public GameObject Money;
    public GameObject Mine;


    // Start is called before the first frame update
    void Start()
    {

        Money = GameObject.Find("Money");
        Mine = GameObject.Find("Mine");

        //para sıkıntısı yarat !!
        //initial costs

        //body armor
        if (PlayerPrefs.GetFloat("bodyArmorMoneyCost") == 0)
            PlayerPrefs.SetFloat("bodyArmorMoneyCost", 500f);
        if (PlayerPrefs.GetInt("bodyArmorMineCost") == 0)
            PlayerPrefs.SetInt("bodyArmorMineCost", 20);

        //missile
        if (PlayerPrefs.GetFloat("missileMoneyCost") == 0)
            PlayerPrefs.SetFloat("missileMoneyCost", 500f);
        if (PlayerPrefs.GetInt("missileMineCost") == 0)
            PlayerPrefs.SetInt("missileMineCost", 10);

        //shield count
        if (PlayerPrefs.GetFloat("shieldCountMoneyCost") == 0)
            PlayerPrefs.SetFloat("shieldCountMoneyCost", 1000f);
        if (PlayerPrefs.GetInt("shieldCountMineCost") == 0)
            PlayerPrefs.SetInt("shieldCountMineCost", 50);

        //shield lifetime
        if (PlayerPrefs.GetFloat("shieldLifeTimeMoneyCost") == 0)
            PlayerPrefs.SetFloat("shieldLifeTimeMoneyCost", 300f);
        if (PlayerPrefs.GetInt("shieldLifeTimeMineCost") == 0)
            PlayerPrefs.SetInt("shieldLifeTimeMineCost", 15);

        //shield capacity
        if (PlayerPrefs.GetFloat("shieldCapacityMoneyCost") == 0)
            PlayerPrefs.SetFloat("shieldCapacityMoneyCost", 500f);
        if (PlayerPrefs.GetInt("shieldCapacityMineCost") == 0)
            PlayerPrefs.SetInt("shieldCapacityMineCost", 20);

        //revenue
        if (PlayerPrefs.GetFloat("revenueMoneyCost") == 0)
            PlayerPrefs.SetFloat("revenueMoneyCost", 0);
        if (PlayerPrefs.GetInt("revenueMineCost") == 0)
            PlayerPrefs.SetInt("revenueMineCost", 2000);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Money.GetComponent<Text>().text = PlayerPrefs.GetFloat("money").ToString("0.00");
        Mine.GetComponent<Text>().text = PlayerPrefs.GetInt("mine").ToString();
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnUpgradeBodyArmorButton()
    {
        upgradePage.SetActive(true);

        upgradePage.transform.SetParent(GameObject.Find("Canvas").transform);
        upgradePage.transform.localPosition = Vector3.zero;

        upgradePage.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/healthIcon");
        upgradePage.transform.GetChild(2).GetComponent<Text>().text = "Body Armor";
        upgradePage.transform.GetChild(3).GetComponent<Text>().text = "Body armor is the main source of life that will keep your ship alive in asteroid collisions";
        upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current body armor is " + (PlayerPrefs.GetFloat("bodyArmor") + 100f).ToString("0.00");
        upgradePage.transform.GetChild(5).GetComponent<Text>().text = "Upgrading this unit will increase your body armor by 20";


        GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("bodyArmorMoneyCost")).ToString("0.00");
        GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("bodyArmorMineCost")).ToString();

        upgrade2.SetActive(false);
        upgrade3.SetActive(false);

        upgradeType = 1;



    }

    public void OnUpgradeMissileButton()
    {
        upgradePage.SetActive(true);

        upgradePage.transform.SetParent(GameObject.Find("Canvas").transform);
        upgradePage.transform.localPosition = Vector3.zero;

        upgradePage.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/missile");
        upgradePage.transform.GetChild(2).GetComponent<Text>().text = "Missiles";
        upgradePage.transform.GetChild(3).GetComponent<Text>().text = "Missiles are the main weaponaries of your ship that save you from asteroids and get minerals from them";
        upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current missile count is " + (PlayerPrefs.GetInt("missileCount") + 10f).ToString();
        upgradePage.transform.GetChild(5).GetComponent<Text>().text = "Upgrading this unit will increase your missile count by 5";

        GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("missileMoneyCost")).ToString("0.00");
        GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("missileMineCost")).ToString();

        upgrade2.SetActive(false);
        upgrade3.SetActive(false);

        upgradeType = 2;

    }

    public void OnUpgradeShieldButton()
    {
        upgradePage.SetActive(true);

        upgradePage.transform.SetParent(GameObject.Find("Canvas").transform);
        upgradePage.transform.localPosition = Vector3.zero;

        upgradePage.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/shield");
        upgradePage.transform.GetChild(2).GetComponent<Text>().text = "Shield";
        upgradePage.transform.GetChild(3).GetComponent<Text>().text = "Shield is the main defense system of your ship which will prevents your body armor in asteroid collisions, Capacity of your shield determines how many collisions it can sustain";
        upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current shield count is " + (PlayerPrefs.GetInt("shieldCount") + 1).ToString() + ", shield lifetime is " + (PlayerPrefs.GetFloat("shieldLifeTime") + 10f).ToString() + " and shield capacity is " + (PlayerPrefs.GetInt("shieldCapacity") + 3).ToString();
        upgradePage.transform.GetChild(5).GetComponent<Text>().text = "Upgrading this unit will increase your shield count by 1, charging this unit will increase lifetime of your shields by 2 sec, forging this unit will increase capacity of your shield by 2";

        GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("shieldCountMoneyCost")).ToString("0.00");
        GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("shieldCountMineCost")).ToString();

        upgrade2.SetActive(true);
        upgrade3.SetActive(true);

        GameObject.Find("Upgrade2MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("shieldLifeTimeMoneyCost")).ToString("0.00");
        GameObject.Find("Upgrade2MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("shieldLifeTimeMineCost")).ToString();
        GameObject.Find("Upgrade3MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("shieldCapacityMoneyCost")).ToString("0.00");
        GameObject.Find("Upgrade3MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("shieldCapacityMineCost")).ToString();

        upgradeType = 3;



    }

    public void OnUpgradeRevenueButton()
    {
        upgradePage.SetActive(true);

        upgradePage.transform.SetParent(GameObject.Find("Canvas").transform);
        upgradePage.transform.localPosition = Vector3.zero;

        upgradePage.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/travelScoreIcon");
        upgradePage.transform.GetChild(2).GetComponent<Text>().text = "Revenue Coefficient";
        upgradePage.transform.GetChild(3).GetComponent<Text>().text = "This unit affects your revenue while in travel";
        upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current revenue coefficient is " + (PlayerPrefs.GetFloat("revenueCoefficient") + 1f).ToString("0.00");
        upgradePage.transform.GetChild(5).GetComponent<Text>().text = "Upgrading this unit will increase your revenue coefficient by 0.2";

        GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("revenueMoneyCost")).ToString("0.00");
        GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("revenueMineCost")).ToString();

        upgrade2.SetActive(false);
        upgrade3.SetActive(false);

        upgradeType = 4;

    }

    public void OnUpgrade1ButtonClick()
    {
        //body armor
        if (upgradeType == 1)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("bodyArmorMoneyCost") && PlayerPrefs.GetInt("mine") >= PlayerPrefs.GetInt("bodyArmorMineCost"))
            {
                PlayerPrefs.SetFloat("bodyArmor", PlayerPrefs.GetFloat("bodyArmor") + 20f);

                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("bodyArmorMoneyCost"));
                PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - PlayerPrefs.GetInt("bodyArmorMineCost"));

                PlayerPrefs.SetFloat("bodyArmorMoneyCost", 2 * PlayerPrefs.GetFloat("bodyArmorMoneyCost"));
                PlayerPrefs.SetInt("bodyArmorMineCost", 2 * PlayerPrefs.GetInt("bodyArmorMineCost"));

                upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current body armor is " + (PlayerPrefs.GetFloat("bodyArmor") + 100f).ToString("0.00");
                GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("bodyArmorMoneyCost")).ToString("0.00");
                GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("bodyArmorMineCost")).ToString();


            }

        }

        //missile
        else if (upgradeType == 2)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("missileMoneyCost") && PlayerPrefs.GetInt("mine") >= PlayerPrefs.GetInt("missileMineCost"))
            {
                PlayerPrefs.SetInt("missileCount", PlayerPrefs.GetInt("missileCount") + 5);

                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("missileMoneyCost"));
                PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - PlayerPrefs.GetInt("missileMineCost"));

                PlayerPrefs.SetFloat("missileMoneyCost", 2 * PlayerPrefs.GetFloat("missileMoneyCost"));
                PlayerPrefs.SetInt("missileMineCost", 2 * PlayerPrefs.GetInt("missileMineCost"));

                upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current missile count is " + (PlayerPrefs.GetInt("missileCount") + 10f).ToString();
                GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("missileMoneyCost")).ToString("0.00");
                GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("missileMineCost")).ToString();

            }
        }

        //shield count
        else if (upgradeType == 3)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("shieldCountMoneyCost") && PlayerPrefs.GetInt("mine") >= PlayerPrefs.GetInt("shieldCountMineCost"))
            {
                PlayerPrefs.SetInt("shieldCount", PlayerPrefs.GetInt("shieldCount") + 1);

                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("shieldCountMoneyCost"));
                PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - PlayerPrefs.GetInt("shieldCountMineCost"));

                PlayerPrefs.SetFloat("shieldCountMoneyCost", 2 * PlayerPrefs.GetFloat("shieldCountMoneyCost"));
                PlayerPrefs.SetInt("shieldCountMineCost", 2 * PlayerPrefs.GetInt("shieldCountMineCost"));

                upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current shield count is " + (PlayerPrefs.GetInt("shieldCount") + 1).ToString() + ", shield lifetime is " + (PlayerPrefs.GetFloat("shieldLifeTime") + 10f).ToString() + "and shield capacity is " + (PlayerPrefs.GetInt("shieldCapacity") + 3).ToString();
                GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("shieldCountMoneyCost")).ToString("0.00");
                GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("shieldCountMineCost")).ToString();
            }
        }

        //revenue
        else if (upgradeType == 4)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("revenueMoneyCost") && PlayerPrefs.GetInt("mine") >= PlayerPrefs.GetInt("revenueMineCost"))
            {
                PlayerPrefs.SetFloat("revenueCoefficient", PlayerPrefs.GetFloat("revenueCoefficient") + 0.2f);

                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("revenueMoneyCost"));
                PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - PlayerPrefs.GetInt("revenueMineCost"));

                PlayerPrefs.SetFloat("revenueMoneyCost", 2 * PlayerPrefs.GetFloat("revenueMoneyCost"));
                PlayerPrefs.SetInt("revenueMineCost", 2 * PlayerPrefs.GetInt("revenueMineCost"));

                upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current revenue coefficient is " + (PlayerPrefs.GetFloat("revenueCoefficient") + 1f).ToString("0.00");
                GameObject.Find("Upgrade1MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("revenueMoneyCost")).ToString("0.00");
                GameObject.Find("Upgrade1MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("revenueMineCost")).ToString();
            }
        }
    }

    public void OnUpgrade2ButtonClick()
    {
        //shield lifetime
        if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("shieldLifeTimeMoneyCost") && PlayerPrefs.GetInt("mine") >= PlayerPrefs.GetInt("shieldLifeTimeMineCost"))
        {
            PlayerPrefs.SetFloat("shieldLifeTime", PlayerPrefs.GetFloat("shieldLifeTime") + 2f);

            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("shieldLifeTimeMoneyCost"));
            PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - PlayerPrefs.GetInt("shieldLifeTimeMineCost"));

            PlayerPrefs.SetFloat("shieldLifeTimeMoneyCost", 2 * PlayerPrefs.GetFloat("shieldLifeTimeMoneyCost"));
            PlayerPrefs.SetInt("shieldLifeTimeMineCost", 2 * PlayerPrefs.GetInt("shieldLifeTimeMineCost"));

            upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current shield count is " + (PlayerPrefs.GetInt("shieldCount") + 1).ToString() + ", shield lifetime is " + (PlayerPrefs.GetFloat("shieldLifeTime") + 10f).ToString() + "and shield capacity is " + (PlayerPrefs.GetInt("shieldCapacity") + 3).ToString();
            GameObject.Find("Upgrade2MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("shieldLifeTimeMoneyCost")).ToString("0.00");
            GameObject.Find("Upgrade2MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("shieldLifeTimeMineCost")).ToString();

        }
    }

    public void OnUpgrade3ButtonClick()
    {
        //shield capacity
        if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("shieldCapacityMoneyCost") && PlayerPrefs.GetInt("mine") >= PlayerPrefs.GetInt("shieldCapacityMineCost"))
        {
            PlayerPrefs.SetInt("shieldCapacity", PlayerPrefs.GetInt("shieldCapacity") + 2);

            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("shieldCapacityMoneyCost"));
            PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") - PlayerPrefs.GetInt("shieldCapacityMineCost"));

            PlayerPrefs.SetFloat("shieldCapacityMoneyCost", 2 * PlayerPrefs.GetFloat("shieldCapacityMoneyCost"));
            PlayerPrefs.SetInt("shieldCapacityMineCost", 2 * PlayerPrefs.GetInt("shieldCapacityMineCost"));

            upgradePage.transform.GetChild(4).GetComponent<Text>().text = "Current shield count is " + (PlayerPrefs.GetInt("shieldCount") + 1).ToString() + ", shield lifetime is " + (PlayerPrefs.GetFloat("shieldLifeTime") + 10f).ToString() + "and shield capacity is " + (PlayerPrefs.GetInt("shieldCapacity") + 3).ToString();
            GameObject.Find("Upgrade3MoneyCost").GetComponent<Text>().text = (PlayerPrefs.GetFloat("shieldCapacityMoneyCost")).ToString("0.00");
            GameObject.Find("Upgrade3MineCost").GetComponent<Text>().text = (PlayerPrefs.GetInt("shieldCapacityMineCost")).ToString();
        }
    }

    public void OnCloseButtonClick()
    {
        upgradePage.SetActive(false);
    }

}
