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
    SoulCarrier carrier;
    Animator anim;
    public int Deaths;
    public bool IsAlive = true;
    void Start ()
    {
        carrier = GetComponent<SoulCarrier>();
        Deaths = 0;
        anim = GetComponent<Animator>();
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
        if(IsAlive == true)
        {
            Deaths++;
            carrier.DropSouls();
            IsAlive = false;
            anim.SetTrigger("Death");
            Invoke("ReSpawn", 1);
            //ReSpawn();
        }
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
                IsAlive = true;
                Respawning = false;
                movement.enabled = true;
                RespawnTime = StartRespawn;
            }
        }
	}
}
