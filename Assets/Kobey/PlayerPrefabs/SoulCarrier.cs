using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoulCarrier : MonoBehaviour {

    public int carriedSouls;
    public int playerNum;
    public int maxSoulCount;
    public GameObject Soul;
    
	// Use this for initialization
	void Start ()
    {
        carriedSouls = 0;	
	}
	
    public void DropSouls()
    {
        for(int i =0; i < carriedSouls; i++)
        {
            var babySoul = Soul;
            babySoul.transform.position = transform.position;
            Instantiate(babySoul);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        
	}
}
