using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class GhostShotGun : MonoBehaviour {

    PlayerIndex pIdx;
    GamePadState state;
    GamePadState prevState;


    public float distance;
    
    public float lineCount;
   
    public float reloadTime;
    private float startReload;
    public int playerNumber;
    public ParticleSystem Pellet;
    AudioSource[] sounds;
    Quaternion startRot;
   
    // Use this for initialization
    void Start()
    {
        switch (playerNumber)
        {
            case 1:
                pIdx = PlayerIndex.One;
                break;
            case 2:
                pIdx = PlayerIndex.Two;
                break;
            case 3:
                pIdx = PlayerIndex.Three;
                break;
            case 4:
                pIdx = PlayerIndex.Four;
                break;
        }



        sounds = GetComponents<AudioSource>();
        

        startReload = reloadTime;
        reloadTime = 0;
        
    }

    void Shoot()
    {
        Pellet.Play();
        sounds[2].Play();
       
        for (int i = 0; i < lineCount; i++)
        {
            float x = Random.Range(-0.4f, 0.6f);
            float z = Random.Range(-0.4f, 0.6f);

            Vector3 End = new Vector3(transform.forward.x + x, transform.forward.y, transform.forward.z + z);
           
            Vector3 start = transform.position;
           
            RaycastHit sphereHit;
            RaycastHit hitInfo;
            if (Physics.SphereCast(start, 0.5f, transform.forward, out sphereHit))
            {
                if (sphereHit.collider.tag != "GhostWALL")
                {
                    if (Physics.Raycast(start, End, out hitInfo, distance))
                    {
                        //Shoot through walls fix?

                        if (hitInfo.collider.tag == "Ghost" || hitInfo.collider.tag == "Pumpkin")
                        {
                           
                            hitInfo.collider.GetComponent<Ikillable>().Die();
                            //break;

                        }
                    }
                }
            }
            Debug.DrawLine(start, (start + (End * distance)));
        }
       
    }

    bool isHeld = false;
   

    // Update is called once per frame
    void Update()
    {
        prevState = state;
        state = GamePad.GetState(pIdx);


        reloadTime -= Time.deltaTime;
        float Trigger = state.Triggers.Left;
       

        
        if(prevState.Triggers.Left == 1)
        {
            isHeld = true;
        }
        else
        {
            isHeld = false;
        }
        if (reloadTime <= 0 && Trigger == 1 && !isHeld)
        {
            Shoot();
            isHeld = false;
            reloadTime = startReload;
        }
        

        
    }
}
