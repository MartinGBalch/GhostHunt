using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPumpkin : MonoBehaviour, Ikillable
{
    Animator anim;
    Collider coll;
    AudioSource aud;
    bool isAlive = true;
	public bool testBreak = false;

	void Start ()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
        aud = GetComponent<AudioSource>();
	}

    void Update()
    {
        if (testBreak == true)
            Die();
    }

    public void Die()
    {
        if (isAlive == true)
        {
            isAlive = false;
            GetComponent<Collider>().enabled = false;
            anim.SetBool("Break", true);
            aud.Play();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ghost" || other.gameObject.tag == "Test")
            Physics.IgnoreCollision(coll, other.collider);
    }
}
