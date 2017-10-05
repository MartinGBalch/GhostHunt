using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    bool doFlicker = false;
    Light lamp;

    float timeOn = 0.1f;
    float timeOff = 0.5f;
    private float changeTime = 0;

    private void Start()
    {
        lamp = GetComponent<Light>();
    }

    void Update()
    {
        if (doFlicker)
        {
            if (Time.time > changeTime)
            {
                lamp.enabled = !lamp.enabled;
                if (lamp.enabled)
                {
                    timeOn = Random.Range(.05f, .2f);
                    changeTime = Time.time + timeOn;
                }
                else
                {
                    timeOff = Random.Range(.05f, .2f);
                    changeTime = Time.time + timeOff;
                }
            }
        }
        else
            lamp.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
            doFlicker = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
            doFlicker = false;
    }

}
