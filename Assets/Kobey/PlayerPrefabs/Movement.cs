using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class Movement : MonoBehaviour {

    PlayerIndex pIdx;
    GamePadState state;
    GamePadState prevState;
    public int PlayerNumber;

    Rigidbody rb;
    public float speed;
    private float normalSpeed;
    public float sprintSpeed;
    public float SprintTime;
    private float startSprint;

    Animator anim;
   
    float horz;
    float vert;
    float Lookx;
    float lookz;

    // Use this for initialization
    void Start ()
    {
        switch (PlayerNumber)
        {
            case 1:
                pIdx = PlayerIndex.One;
                break;
            case 2:
                pIdx = PlayerIndex.Two;
                break;
            case 3:
                pIdx = PlayerIndex.Three;
                break;
            case 4:
                pIdx = PlayerIndex.Four;
                break;
        }

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        normalSpeed = speed;
        startSprint = SprintTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(pIdx);

       
        horz = -state.ThumbSticks.Left.X;
        vert = -state.ThumbSticks.Left.Y;
        Lookx = state.ThumbSticks.Right.X;
        lookz = -state.ThumbSticks.Right.Y;





        anim.SetFloat("Horz", horz);
        anim.SetFloat("Vert", vert);

        
        if(state.Buttons.LeftShoulder == ButtonState.Pressed && SprintTime > 0)
        {
            SprintTime -= Time.deltaTime;
            speed = sprintSpeed;
            SprintTime = Mathf.Clamp(SprintTime, -0.5f, startSprint);
        }
       
       else if(SprintTime < 0 && state.Buttons.LeftShoulder == ButtonState.Pressed)
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


        rb.velocity = new Vector3(horz * speed, 0, vert * speed);

        Vector3 desireRot = new Vector3(transform.position.x - Lookx, transform.position.y, transform.position.z + lookz);
        transform.forward = Vector3.Slerp(transform.forward, -(transform.position - desireRot).normalized, .2f);
	}
}
