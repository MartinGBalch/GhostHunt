using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDropOff : MonoBehaviour {

    public int storedSouls;
    public int playerNum;
	// Use this for initialization
	void Start () {
        storedSouls = 0;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Test")
        {
            var soulCarrier = other.GetComponent<SoulCarrier>();
            if(soulCarrier != null)
            {
                if (soulCarrier.playerNum == playerNum)
                {
                    storedSouls += soulCarrier.carriedSouls;
                    soulCarrier.carriedSouls = 0;
                    soulCarrier.UpdateLight();

                }
            }
           
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
