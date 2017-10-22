using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulCollision : MonoBehaviour {

    public int soulAmount;
    [HideInInspector]
    public float CollisionDelay = 0;
    public bool inWall = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Test")
        {
            var soulCarrier = other.GetComponent<SoulCarrier>();
            if(soulCarrier.carriedSouls < soulCarrier.maxSoulCount)
            {
                soulCarrier.carriedSouls += soulAmount;
                soulCarrier.UpdateLight();
                Destroy(gameObject);
            }
            //plus souls
            
        }
       
    }

  

    void TurnCollisionOn()
    {
        GetComponent<SphereCollider>().enabled = true;
        //Debug.Log("CollisionOn");
    }

    //void MoveSoul()
    //{
    //    if(inWall)
    //    {
    //        RaycastHit hit;
    //        Physics.SphereCast(transform.position, 1, transform.forward, out hit);
    //        if (hit.collider.tag == "GhostWall")
    //        {
    //            transform.Translate(0.02f, 0, 0);
    //        }
    //        else if(hit.collider.tag != "GhostWall" || hit.collider.tag == null)
    //        {
    //            inWall = false;
    //        }
    //    }
       
    //}

    // Use this for initialization
    void Start ()
    {
       // Debug.Log("CollisionOff");
        GetComponent<SphereCollider>().enabled = false;
        Invoke("TurnCollisionOn", CollisionDelay);

      
       

    }

    // Update is called once per frame
    void Update ()
    {
       
        Collider[] hood = Physics.OverlapSphere(transform.position, 5);
       
        foreach(Collider h in hood)
        {
            if (h.tag == "Test")
            {
                Vector3 dist = h.transform.position - transform.position;
                transform.Translate(dist.normalized/ 50);
            }
        }
       
       
    }
}
