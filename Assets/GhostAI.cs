using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostAI : MonoBehaviour
{
    NavMeshAgent agent;
    Collider coll;
    Vector3 target;
    Vector3 targetRange;
    public Vector3[] players;
    Vector3 primaryPlayer;
    RaycastHit hit;
    public float minX, maxX, minZ, maxZ;
    public float timer;
    float timerReset;
    public bool playerDetected = false;
    float[] distToPlayer;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        coll = GetComponent<Collider>();
        timerReset = timer;

        target = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }
	
	void Update ()
    {
        if (!playerDetected)
        {
            agent.destination = target;
            targetRange = new Vector3(target.x - 2.0f, 0, target.z - 2.0f);

            timer -= Time.deltaTime;
            if (transform.position.x >= targetRange.x && transform.position.z >= targetRange.z || timer <= 0)
            {
                target = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
                timer = timerReset;
            }
        }
        else
        {
            target = primaryPlayer;
        }
        
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GhostWall" || other.gameObject.tag == "Ghost")
            Physics.IgnoreCollision(other.collider, coll);
    }

    public void ClosestPlayer()
    {
        float min = 900000;
        for(int i = 0; i < 3; ++i)
        {
            distToPlayer[i] = Vector3.Distance(transform.position, players[i]);
            if( min > distToPlayer[i])
            {
                min = distToPlayer[i];
                target = players[i];
            }
        }

        //float closestTarget = Mathf.Min(distToPlayer[0], distToPlayer[1], distToPlayer[2], distToPlayer[3]);

        //for(int i = 0; i < 3; ++i)
        //{
        //    if (closestTarget == distToPlayer[i])
        //        target = players[i];
        //}
    }
}
