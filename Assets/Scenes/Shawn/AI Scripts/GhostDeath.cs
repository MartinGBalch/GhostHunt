using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeath : MonoBehaviour, Ikillable
{
    public GameObject GhostSpawner;
    public GameObject Soul;
    bool isAlive = true;
    public bool dieTest = false;

	void Update ()
    {
        if (dieTest == true)
            Die();
	}

    public void Die()
    {
        if(isAlive == true)
        {
            isAlive = false;
            //Do animation
            GetComponent<GhostAI>().Dieing = true;
            --GhostSpawner.GetComponent<GhostSpawn>().totalGhosts;
            Instantiate(Soul, transform.position, Quaternion.identity);
            Destroy(gameObject);           
        }
    }
}
