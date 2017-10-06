using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public int amount;
    int minimumAmount = 0;
    public Light glow;
    public Light flash;
    bool flashing = false;
    public float flashRate;
    public float flashTimer;
    public GameObject GhostSpawner;
    AudioSource aud;
    public AudioClip damageSound;
    public float pitch;
    public bool testSound = false;


    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(flashing == true)
        {
            flash.range += flashRate * Time.deltaTime;
            flashTimer -= Time.deltaTime;

            if (flashTimer <= 0)
            {
                GetComponent<GhostDeath>().isAlive = false;
                GetComponent<GhostAI>().Dieing = true;
                --GhostSpawner.GetComponent<GhostSpawn>().totalGhosts;
                Destroy(gameObject);
            }
        }
    }



    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Test" && GetComponent<GhostDeath>().isAlive)
        {
            if(other.gameObject.GetComponent<SoulCarrier>().carriedSouls > 0)
                other.gameObject.GetComponent<SoulCarrier>().carriedSouls -= amount;
            aud.clip = damageSound;
            aud.pitch = pitch;
            aud.Play();
            other.gameObject.GetComponent<SoulCarrier>().UpdateLight();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            glow.gameObject.SetActive(false);
            flash.gameObject.SetActive(true);
            flashing = true;         
        }
    }

}
