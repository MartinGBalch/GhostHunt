using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffEffect : MonoBehaviour {

    // Use this for initialization
    float timer = 2;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 2;
            gameObject.SetActive(false);
        }	
	}
}
