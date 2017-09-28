using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {

    //public GameObject light;
    Light light;
    private float startIntensity;
    public bool isOn = true;
    public string PlayerNum;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        if (light != null) { Debug.Log("Light attacjed"); }
        startIntensity = light.intensity;
	}
	
    void Switchlight()
    {
        if(isOn)
        {
            light.intensity = startIntensity;
            Debug.Log("Light On");

        }
        else
        {
            Debug.Log("Light Off");
            light.intensity = 0;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Xbutton" + PlayerNum))
        {
            Debug.Log("Attempt Switch");
            isOn = !isOn;
            Switchlight();
        }



    }
}
