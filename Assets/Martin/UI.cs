using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public SoulCarrier Carry;

    Text carryCount;

	// Use this for initialization
	void Start ()
    {
        carryCount = GetComponent<Text>();
      
	}
	
	// Update is called once per frame
	void Update ()
    {
		setSoulText ();
	}

    void setSoulText()
    {
        carryCount.text = ": " + Carry.carriedSouls;
    }
}
