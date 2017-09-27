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
    int totalGhosts;

	void Start ()
    {
        respawnReset = respawnTimer;

        for(int i = 1; i < startingAmount; ++i)
        {
            Vector3 location = new Vector3(Random.Range(minX,maxX), 3, Random.Range(minZ, maxZ));
            Instantiate(Ghost, location, Quaternion.identity);
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
                Vector3 location = new Vector3(Random.Range(minX, maxX), 3, Random.Range(minZ, maxZ));
                Instantiate(Ghost, location, Quaternion.identity);
                ++totalGhosts;
            }

            respawnTimer = respawnReset;
        }
	}
}
