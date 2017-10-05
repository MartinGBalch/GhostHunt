using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPumpkin : MonoBehaviour, Ikillable
{
    Animator anim;
    Collider coll;
    bool isAlive = true;
	
	void Start ()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
	}

    public void Die()
    {
        if (isAlive == true)
        {
            isAlive = false;
            GetComponent<Collider>().enabled = false;
            anim.SetBool("Break", true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ghost" || other.gameObject.tag == "Test")
            Physics.IgnoreCollision(coll, other.collider);
    }
}
