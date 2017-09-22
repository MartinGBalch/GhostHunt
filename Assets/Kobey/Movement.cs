using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


    Rigidbody rb;
    public float speed;
    public string PlayerNumber;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        float horz = Input.GetAxis("LeftStickXAxis" + PlayerNumber);
        float vert = Input.GetAxis("LeftStickYAxis" + PlayerNumber);
        float Lookx = Input.GetAxis("RightStickXAxis" + PlayerNumber);
        float lookz = Input.GetAxis("RightStickYAxis" + PlayerNumber);

        rb.velocity = new Vector3(-horz * speed, 0, vert * speed);

        Vector3 desireRot = new Vector3(transform.position.x - Lookx, transform.position.y, transform.position.z + lookz);
        transform.forward = Vector3.Slerp(transform.forward, -(transform.position - desireRot).normalized, .2f);
	}
}
