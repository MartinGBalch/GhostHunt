using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollision : MonoBehaviour {

    public int soulAmount;
    [HideInInspector]
    public float CollisionDelay = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Test")
        {
            var soulCarrier = other.GetComponent<SoulCarrier>();
            if(soulCarrier.carriedSouls < soulCarrier.maxSoulCount)
            {
                soulCarrier.carriedSouls++;
                soulCarrier.UpdateLight();
                Destroy(gameObject);
            }
            //plus souls
            
        }
    }

    void TurnCollisionOn()
    {
        GetComponent<SphereCollider>().enabled = true;
        //Debug.Log("CollisionOn");
    }

    // Use this for initialization
    void Start ()
    {
       // Debug.Log("CollisionOff");
        GetComponent<SphereCollider>().enabled = false;
        Invoke("TurnCollisionOn", CollisionDelay);
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}
}
