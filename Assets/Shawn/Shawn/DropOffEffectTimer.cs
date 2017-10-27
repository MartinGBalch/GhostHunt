using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffEffectTimer : MonoBehaviour
{

    float timer = 2f;
	
	void Update ()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 2f;
            gameObject.SetActive(false);
        }
	}
}
