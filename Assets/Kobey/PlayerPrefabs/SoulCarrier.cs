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
        if(carriedSouls > 0)
        {
            var babySoul = Soul;
            babySoul.transform.position = transform.position;
            babySoul.GetComponent<SoulCollision>().soulAmount = carriedSouls;
            carriedSouls = 0;
            Instantiate(babySoul);
        }
      
        //for(int i = 0; i < carriedSouls; i++)
        //{
        //    var babySoul = Soul;
        //    babySoul.transform.position = transform.position;
        //    Instantiate(babySoul);
        //}
    }

	// Update is called once per frame
	void Update ()
    {
        
	}
}
