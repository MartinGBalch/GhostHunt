using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public Vector3[] players;
    public float[] distToPlayer;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            findVisibleTargets();
        }
    }

    void findVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    players[i] = target.position;
                    visibleTargets.Add(target);
                }
            }
        }
    }

    void chooseTarget()
    {
        if (visibleTargets.Count > 0)
            ClosestPlayer();
        else
            GetComponent<GhostAI>().playerDetected = false;
    }

    public void ClosestPlayer()
    {
        float min = 900000;
        for (int i = 0; i < visibleTargets.Count; ++i)
        {
            distToPlayer[i] = Vector3.Distance(transform.position, players[i]);
            if (min > distToPlayer[i])
            {
                min = distToPlayer[i];
                GetComponent<GhostAI>().primaryPlayer = players[i];
                GetComponent<GhostAI>().playerDetected = true;
            }
        }
    }

    public Vector3 dirFromAngle(float angleDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angleDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }

	void Start ()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
	}

    void Update()
    {
        chooseTarget();
    }
}
