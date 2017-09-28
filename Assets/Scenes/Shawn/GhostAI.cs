using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostAI : MonoBehaviour
{
    public float normalSpeed;
    public float chasingSpeed;

    NavMeshAgent agent;
    Collider coll;
    public Vector3 target;
    Vector3 targetRange;
    public Vector3 primaryPlayer;
    public float minX, maxX, minZ, maxZ;
    public float timer;
    float timerReset;
    public bool playerDetected = false;
    public bool Dieing = false;


    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        coll = GetComponent<Collider>();

        agent.speed = normalSpeed;

        timerReset = timer;

        target = new Vector3(Random.Range(minX, maxX), 4, Random.Range(minZ, maxZ));
    }
	
	void Update ()
    {
        if (!Dieing)
        {
            if (playerDetected)
            {
                agent.destination = primaryPlayer;
                agent.speed = chasingSpeed;
            }
            else
            {
                agent.speed = normalSpeed;
                agent.destination = target;
                targetRange = new Vector3(target.x - 2.0f, 0, target.z - 2.0f);

                timer -= Time.deltaTime;
                if (transform.position.x >= targetRange.x && transform.position.z >= targetRange.z || timer <= 0)
                {
                    target = new Vector3(Random.Range(minX, maxX), 4, Random.Range(minZ, maxZ));
                    timer = timerReset;
                }
            }
        }
        else
        {
            target = Vector3.forward;
            agent.speed = 0;
        }
        
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GhostWall" || other.gameObject.tag == "Ghost")
            Physics.IgnoreCollision(other.collider, coll);
    }
}
