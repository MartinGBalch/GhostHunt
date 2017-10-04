using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public SoulCarrier Carry;

    Text carryCount;
 
    public Color maxSoul;

    public RawImage Counter;
    

	// Use this for initialization
	void Start ()
    {
        carryCount = GetComponent<Text>();
        //Counter = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		setSoulText ();
    }

    public void setSoulText()
    {
        carryCount.text = Carry.carriedSouls.ToString();
        CounterColor();
    }

    void CounterColor()
    {
        if(Carry.carriedSouls >= 15)
        {
            Counter.color = maxSoul;
            Debug.Log("working");
        }
        else
        {
            Counter.color = Color.white;
        }
    }

   
}
