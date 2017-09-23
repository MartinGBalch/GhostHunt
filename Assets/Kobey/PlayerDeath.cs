using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, Ikillable {

    // Use this for initialization
    private Vector3 startLocation;
    Movement movement;
    bool Respawning;
    public float RespawnTime;
    private float StartRespawn;
    void Start ()
    {
        StartRespawn = RespawnTime;
        movement = GetComponent<Movement>();
        startLocation = transform.position;
	}
	

    void ReSpawn()
    {
        transform.position = startLocation;
        Respawning = true;
        Debug.Log("Spawned");
    }

    public void Die()
    {
        ReSpawn();
    }

	// Update is called once per frame
	void Update ()
    {
	    if(Respawning == true)
        {
            movement.enabled = false;
            RespawnTime -= Time.deltaTime;
            if(RespawnTime <= 0)
            {
                Respawning = false;
                movement.enabled = true;
                RespawnTime = StartRespawn;
            }
        }
	}
}
