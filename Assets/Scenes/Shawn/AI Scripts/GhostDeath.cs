using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeath : MonoBehaviour, Ikillable
{
    public GameObject GhostSpawner;
    public GameObject Soul;
    Animator anim;
    bool isAlive = true;
    bool doAnimation = false;
    public float animTimer;
    public bool dieTest = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        if (dieTest == true)
            Die();

		if(doAnimation)
        {
            animTimer -= Time.deltaTime;
            anim.SetBool("Death", true);
        }
	}

    public void Die()
    {
        if(isAlive == true)
        {
            doAnimation = true; //Do animation
            GetComponent<GhostAI>().Dieing = true;

            if (animTimer <= 0)
            {
                --GhostSpawner.GetComponent<GhostSpawn>().totalGhosts;
                Instantiate(Soul, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }
}
