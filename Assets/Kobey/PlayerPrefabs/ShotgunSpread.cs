﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSpread : MonoBehaviour {

    public float distance;
    public float arcDegree;
    public float lineCount;
    private float initRotate;
    public float reloadTime;
    private float startReload;
    public string playerNumber;
    public ParticleSystem Pellet;
    public Animator anim;
    public int Kills;
   // AudioSource shotgunBlast;
    AudioSource[] sounds;
    //public LineRenderer line;
    // Use this for initialization
    public Quaternion startRot;
    void Start ()
    {
       //shotgunBlast = GetComponent<AudioSource>();
        sounds = GetComponents<AudioSource>();
        Kills = 0;
        //initRotate = (arcDegree * lineCount) / 2;
        //transform.Rotate(0, -initRotate, 0);
        startReload = reloadTime;
        reloadTime = 0;
	}
	
    

    void Shoot()
    {
        sounds[0].Play();
        Pellet.Play();
        startRot = transform.rotation;
        Vector3 start = transform.position;
        
        for (int i = 0; i < lineCount; i++)
        {
            transform.Rotate(0, arcDegree * i, 0);


            Vector3 End = (transform.forward );
            RaycastHit sphereHit;
            RaycastHit hitInfo;
            Debug.DrawLine(start, (start + (End * distance)));
            if (Physics.SphereCast(start, 0.5f, transform.forward, out sphereHit))
            {
                if(sphereHit.collider.tag != "GhostWall")
                {
                    if (Physics.Raycast(start, End, out hitInfo, distance))
                    {
                       
                        if (hitInfo.collider.tag == "Test")
                        {
                            Debug.Log("SHOTGUN");
                            if (hitInfo.collider.GetComponent<PlayerDeath>().IsAlive == true)
                            {
                                Kills++;
                            }
                            hitInfo.collider.GetComponent<Ikillable>().Die();
                            
                            // Destroy(hitInfo.collider.gameObject);
                        }
                    }
                }
            }



            //var LineBaby = line;
            //LineBaby.transform.position = transform.position;
            //LineBaby.SetPosition(0, start);
            //LineBaby.SetPosition(1, (start+(End * (distance/2))));
            //Instantiate(LineBaby);
            //Destroy(LineBaby, .5f);
            //startRot.SetLookRotation(transform.rotation + * i));
            transform.rotation = startRot;
        }
        transform.rotation = startRot;
        anim.SetTrigger("Reloading");
        sounds[1].PlayDelayed(1);
    }

	// Update is called once per frame
	void Update ()
    {
        reloadTime -= Time.deltaTime;
        float Trigger = Input.GetAxis("RightTrigger" + playerNumber);

        if(reloadTime <= 0 && Trigger == 1)
        {
            Shoot();
            reloadTime = startReload;
        }
    }
}
