using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {

    new Light light;
    //Light light;
    private float startIntensity;
    public bool isOn = true;
    public string PlayerNum;
    public bool press;
	// Use this for initialization
	void Start () {
        
        light = gameObject.GetComponent<Light>();
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
        press = Input.GetButtonDown("Xbutton" + PlayerNum);
        if (press)
        {
            Debug.Log("Attempt Switch");
            isOn = !isOn;
            Switchlight();
        }

        Switchlight();

    }
}
