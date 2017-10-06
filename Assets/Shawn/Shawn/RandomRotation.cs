using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public Vector3 rotations;
    Transform trans;

	void Start ()
    {
        trans = GetComponent<Transform>();
	}
	
	void Update ()
    {
        trans.Rotate(rotations);
	}
}
