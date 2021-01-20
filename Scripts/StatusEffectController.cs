using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour
{
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        transform.GetComponent<ParticleSystem>().emissionRate = (float)(100 - (UI.GetComponent<UIController>().bodyArmor / UI.GetComponent<UIController>().maxBodyArmor * 100)) * 2;
    }
}
