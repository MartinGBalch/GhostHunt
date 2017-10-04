using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeath : MonoBehaviour, Ikillable
{
    public GameObject death;
    public GameObject GhostSpawner;
    public GameObject Soul;
    public GameObject glow;
    Vector3 deathPosition;
    public float deathTimer;
    public bool isAlive = true;
    public bool dieTest = false;

	void Update ()
    {
        if (dieTest)
            Die();
        if(!isAlive)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                SpawnSoul();
            }
        }
	}

    public void Die()
    {
        if(isAlive == true)
        {
            GetComponent<GhostAI>().Dieing = true;
            isAlive = false;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<ParticleSystem>().gameObject.SetActive(false);
            glow.gameObject.SetActive(false);
            deathPosition = transform.position;
            Instantiate(death, transform.position, Quaternion.identity);           
        }
    }

    void SpawnSoul()
    {
        --GhostSpawner.GetComponent<GhostSpawn>().totalGhosts;
        var spawnBaby = Soul;
        Instantiate(spawnBaby, deathPosition, Quaternion.identity);
        Destroy(death);
        Destroy(gameObject);
    }
}
