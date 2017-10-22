using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class ShotgunSpread : MonoBehaviour {


    PlayerIndex pIdx;
    GamePadState state;
    GamePadState prevState;


    public float distance;
   
    public float lineCount;
   
    public float reloadTime;
    private float startReload;
    public int playerNumber;
    public ParticleSystem Pellet;
    public GameObject Player;
    PlayerDeath death;
    public Animator anim;
    public int Kills;
  
    AudioSource[] sounds;

    // Use this for initialization
    public Quaternion startRot;
    void Start ()
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
        death = Player.GetComponent<PlayerDeath>();
       
        sounds = GetComponents<AudioSource>();
        Kills = 0;
       
        startReload = reloadTime;
        reloadTime = 0;
	}

    

    void Shoot()
    {
        if(death.IsAlive == true)
        {
            sounds[0].Play();
            Pellet.Play();
           
            Vector3 start = transform.position;

            for (int i = 0; i < lineCount; i++)
            {
               
                float x = Random.Range(-0.4f, 0.6f);
                float z = Random.Range(-0.4f, 0.6f);

                Vector3 End = new Vector3(transform.forward.x + x, transform.forward.y, transform.forward.z + z);
           

                RaycastHit sphereHit;
                RaycastHit hitInfo;
                Debug.DrawLine(start, (start + (End * distance)));
                if (Physics.SphereCast(start, 0.5f, transform.forward, out sphereHit))
                {
                    if (sphereHit.collider.tag != "GhostWall")
                    {
                        if (Physics.Raycast(start, End, out hitInfo, distance))
                        {

                            if (hitInfo.collider.tag == "Test" || hitInfo.collider.tag == "Pumpkin")
                            {

                                if (hitInfo.collider.GetComponent<PlayerDeath>().IsAlive == true)
                                {
                                    Kills++;
                                   
                                }
                                //Debug.Log("Hit Player");

                                hitInfo.collider.GetComponent<Ikillable>().Die();
                                
                            }
                            
                        }
                    }
                }
            }
           
            anim.SetTrigger("Reloading");
            sounds[1].PlayDelayed(1);
        }
        
    }

    bool isHeld = false;

	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(pIdx);
        reloadTime -= Time.deltaTime;
        float Trigger = state.Triggers.Right;

        if (prevState.Triggers.Right == 1)
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
