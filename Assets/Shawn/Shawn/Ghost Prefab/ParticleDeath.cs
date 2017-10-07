using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour {

    float timer = 1;
	// Use this for initialization
	void Start () {
        Invoke("TurnOff", 1);
	}
	
    void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
