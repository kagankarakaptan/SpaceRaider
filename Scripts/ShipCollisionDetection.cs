using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShipCollisionDetection : MonoBehaviour
{
    public float startDelay;
    public float endDelay;
    public bool startDying;
    public bool isDead;

    public GameObject UI;

    private readonly string storeId = "3815687";
    private readonly string videoAd = "video";

    private void Start()
    {
        UI = GameObject.Find("UI");

        //initializing the advertisement requests
        Advertisement.Initialize(storeId, false);
    }

    void Update()
    {
        if (startDying)
            startDelay += Time.deltaTime;

        if (startDelay > endDelay)
            isDead = true;

        if (isDead && (Input.touchCount > 0 || Input.GetKey(KeyCode.R)))
            Restart();

    }


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Resources.Load("Prefabs/Effects/DestroyEffects/AsteroidDestroyEffect" + (collision.transform.GetComponent<AsteroidController>().asteroidType - 1).ToString()), transform.position, Quaternion.identity);

        if (collision.transform.CompareTag("asteroid") && !transform.parent.GetComponent<AbilityController>().isShieldActive)
            GetDamage(collision.transform.GetComponent<AsteroidController>().asteroidDamage);

        Destroy(collision.gameObject);
    }

    void GetDamage(float damage)
    {
        GameObject.Find("UI").GetComponent<UIController>().bodyArmor -= damage;

        if (GameObject.Find("UI").GetComponent<UIController>().bodyArmor <= 0)
            Death();
    }

    public void Death()
    {
        //effect instantiate
        GameObject.Find("MainRoot").GetComponent<MainRootController>().canMove = false;
        transform.GetComponent<MeshRenderer>().enabled = false;
        Destroy(GameObject.Find("Other"));

        GameObject.Find("YouDied").GetComponent<Text>().enabled = true;
        startDying = true;


    }

    public void Restart()
    {
        PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + UI.GetComponent<UIController>().travelScore);
        PlayerPrefs.SetInt("mine", PlayerPrefs.GetInt("mine") + UI.GetComponent<UIController>().mineScore);

        //setting the max travel time
        if (GameObject.Find("INVOKER").GetComponent<InvokerController>().travelTime > PlayerPrefs.GetFloat("maxTravelTime"))
            PlayerPrefs.SetFloat("maxTravelTime", GameObject.Find("INVOKER").GetComponent<InvokerController>().travelTime);





        //advertisement
        float adPosibility = Random.value;

        if (Advertisement.IsReady(videoAd) && adPosibility > 0.5f)
        {
            Advertisement.Show(videoAd);
        }



        //
        SceneManager.LoadScene("Menu");

    }
}
