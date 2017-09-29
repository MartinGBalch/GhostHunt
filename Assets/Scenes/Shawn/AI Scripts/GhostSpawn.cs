using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    public GameObject Ghost;
    public float minX, maxX, minZ, maxZ;
    public int maxAmount;
    public int startingAmount;
    public float respawnTimer;
    float respawnReset;
    public int totalGhosts = 0;

	void Start ()
    {
        respawnReset = respawnTimer;
        totalGhosts = 0;

        for (int i = 0; i < startingAmount; ++i)
        {
            Vector3 location = new Vector3(transform.position.x + (Random.Range(minX,maxX)), transform.position.y, transform.position.z + Random.Range(minZ, maxZ));
            Instantiate(Ghost, location, Quaternion.identity);
            Ghost.GetComponent<GhostDeath>().GhostSpawner = gameObject;
            Ghost.GetComponent<GhostDamage>().GhostSpawner = gameObject;
            ++totalGhosts;
        }
	}
	
	void Update ()
    {
        respawnTimer -= Time.deltaTime;

        if(respawnTimer <= 0)
        {
            if(totalGhosts < maxAmount)
            {
                Vector3 location = new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y, transform.position.z + Random.Range(minZ, maxZ));
                Instantiate(Ghost, location, Quaternion.identity);
                Ghost.GetComponent<GhostDeath>().GhostSpawner = gameObject;
                Ghost.GetComponent<GhostDamage>().GhostSpawner = gameObject;
                ++totalGhosts;
            }

            respawnTimer = respawnReset;
        }
	}
}
