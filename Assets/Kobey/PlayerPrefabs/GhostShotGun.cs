using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShotGun : MonoBehaviour {

    public float distance;
    public float arcDegree;
    public float lineCount;
    private float initRotate;
    public float reloadTime;
    private float startReload;
    public string playerNumber;
    public ParticleSystem Pellet;
    AudioSource sounds;
    Quaternion startRot;
   
    // Use this for initialization
    void Start()
    {

        


        sounds = GetComponent<AudioSource>();
        initRotate = (arcDegree * lineCount) / 2;
        transform.Rotate(0, -initRotate, 0);

        startReload = reloadTime;
        reloadTime = 0;
        
    }

    void Shoot()
    {
        Pellet.Play();
        sounds.Play();
        startRot = transform.rotation;
        for (int i = 0; i < lineCount; i++)
        {
            
            transform.Rotate(0, arcDegree * i, 0);
            Vector3 start = transform.position;
            Vector3 End = (transform.forward);
            RaycastHit sphereHit;
            RaycastHit hitInfo;
            if (Physics.SphereCast(start, 0.5f, transform.forward, out sphereHit))
            {
                if (sphereHit.collider.tag != "GhostWALL")
                {
                    if (Physics.Raycast(start, End, out hitInfo, distance))
                    {
                        //Shoot through walls fix?

                        if (hitInfo.collider.tag == "Ghost")
                        {
                            Debug.Log("Ghost");
                            hitInfo.collider.GetComponent<Ikillable>().Die();
                            break;
                            //Destroy(hitInfo.collider.gameObject);
                        }


                    }
                }
            }




            Debug.DrawLine(start, (start + (End * distance)));
            transform.rotation = startRot;
        }
        transform.rotation = startRot;
    }



    // Update is called once per frame
    void Update()
    {
        reloadTime -= Time.deltaTime;
        float Trigger = Input.GetAxis("LeftTrigger" + playerNumber);

        if (reloadTime <= 0 && Trigger == 1)
        {
            Shoot();
            reloadTime = startReload;
        }

        
    }
}
