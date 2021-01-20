using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainCamera;
    public static GameObject instanceOfTheme;

    private void Start()
    {
        if (instanceOfTheme == null)
        {
            GameObject theme = Instantiate(Resources.Load("Prefabs/MainTheme"), transform.position, Quaternion.identity) as GameObject;
            instanceOfTheme = theme;
        }

        mainCamera = GameObject.Find("Main Camera");
        GameObject.Find("ScoreValue").GetComponent<Text>().text = PlayerPrefs.GetFloat("maxTravelTime").ToString("0.000") + " sec"; ;
    }
    private void FixedUpdate()
    {
        mainCamera.transform.Rotate(new Vector3(-0.05f, 0.03f, 0f));
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Game");

    }

    public void OnUpgradeClick()
    {
        SceneManager.LoadScene("Upgrade");
    }


}
