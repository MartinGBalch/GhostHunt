using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostAI : MonoBehaviour
{
    Transform trans;
    NavMeshAgent agent;
    Collider coll;
    Vector3 target;
    Vector3 targetRange;
    public float minX, maxX, minZ, maxZ;
    public float timer;
    float timerReset;
	void Start ()
    {
        trans = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        coll = GetComponent<Collider>();
        timerReset = timer;

        target = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        Debug.Log(target);
    }
	
	void Update ()
    {
        agent.destination = target;
        targetRange = new Vector3(target.x - 2.0f, 0, target.z - 2.0f);

        timer -= Time.deltaTime;
        if (trans.position.x >= targetRange.x && trans.position.z >= targetRange.z || timer <= 0)
        {
            target = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
            Debug.Log(target);
            timer = timerReset;
        }
        
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GhostWall" || other.gameObject.tag == "Ghost")
            Physics.IgnoreCollision(other.collider, coll);
    }
}
