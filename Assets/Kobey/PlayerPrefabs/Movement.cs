using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


    Rigidbody rb;
    public float speed;
    public string PlayerNumber;
    public float rollForce;
    Animator anim;
    private float normalSpeed;
    public float sprintSpeed;
    public float SprintTime;
    private float startSprint;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        normalSpeed = speed;
        startSprint = SprintTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        float horz = Input.GetAxis("LeftStickXAxis" + PlayerNumber);
        float vert = Input.GetAxis("LeftStickYAxis" + PlayerNumber);
        float Lookx = Input.GetAxis("RightStickXAxis" + PlayerNumber);
        float lookz = Input.GetAxis("RightStickYAxis" + PlayerNumber);

               
        anim.SetFloat("Horz", horz);
        anim.SetFloat("Vert", vert);

        if(Input.GetButton("Bbutton" + PlayerNumber) && SprintTime > 0)
        {
            SprintTime -= Time.deltaTime;
            speed = sprintSpeed;
            SprintTime = Mathf.Clamp(SprintTime, -0.5f, startSprint);
        }
        else if (SprintTime < 0 && Input.GetButton("Bbutton" + PlayerNumber))
        {
            speed = normalSpeed;
            SprintTime = -0.5f;
        }
        else
        {
            speed = normalSpeed;
            SprintTime += Time.deltaTime;
            SprintTime = Mathf.Clamp(SprintTime, -0.5f, startSprint);
        }


        rb.velocity = new Vector3(-horz * speed, 0, vert * speed);

        Vector3 desireRot = new Vector3(transform.position.x - Lookx, transform.position.y, transform.position.z + lookz);
        transform.forward = Vector3.Slerp(transform.forward, -(transform.position - desireRot).normalized, .2f);
	}
}
