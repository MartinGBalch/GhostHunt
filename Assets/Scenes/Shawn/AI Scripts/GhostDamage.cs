using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public int amount;
    int minimumAmount = 0;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<SoulCarrier>().carriedSouls > 0)
                other.gameObject.GetComponent<SoulCarrier>().carriedSouls -= amount;
            other.gameObject.GetComponent<SoulCarrier>().UpdateLight();
            //Do flash
            Destroy(gameObject);
        }
    }

}
