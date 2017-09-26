using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollision : MonoBehaviour {

    public int soulAmount;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Test")
        {
            var soulCarrier = other.GetComponent<SoulCarrier>();
            if(soulCarrier.carriedSouls < soulCarrier.maxSoulCount)
            {
                other.GetComponent<SoulCarrier>().carriedSouls++;
                Destroy(gameObject);
            }
            //plus souls
            
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
