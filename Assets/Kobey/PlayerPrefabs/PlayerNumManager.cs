using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using XInputDotNetPure;
public class PlayerNumManager : MonoBehaviour {

    public HowManyPlayers howManyPlayers;


    public GameObject[] Players;
    public GameObject[] Cameras;
    //PlayerIndex p1 = PlayerIndex.One;
    //PlayerIndex p2 = PlayerIndex.Two;
    //PlayerIndex p3 = PlayerIndex.Three;
    //PlayerIndex p4 = PlayerIndex.Four;
    //GamePadState p1State;
    //GamePadState p2State;
    //GamePadState p3State;
    //GamePadState p4State;
    public GameObject P4Image;
   // CameraFollow P4Cam;
    // Use this for initialization
    void Start()
    {
        howManyPlayers = GameObject.FindObjectOfType<HowManyPlayers>();


        switch (howManyPlayers.numOfPlayers)
        {
           
            case 2:
                Cameras[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                Cameras[1].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                Players[2].SetActive(false);
                Cameras[2].SetActive(false);
                Players[3].SetActive(false);
                Cameras[3].SetActive(false);
                break;
            case 3:
                Players[3].SetActive(false);
                Cameras[3].SetActive(false);
                //Cameras[2].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                Cameras[3].SetActive(true);
                //P4Cam.enabled = false;
                P4Image.SetActive(true);
                break;
            
        }
        

        //P4Cam = GetComponent<CameraFollow>();
        //p1State = GamePad.GetState(p1);
        //p2State = GamePad.GetState(p2);
        //p3State = GamePad.GetState(p3);
        //p4State = GamePad.GetState(p4);


        //if(!p1State.IsConnected)
        //{
        //    Players[0].SetActive(false);
        //    Cameras[0].SetActive(false);
        //}
        //if (!p2State.IsConnected)
        //{
        //    Players[1].SetActive(false);
        //    Cameras[1].SetActive(false);
        //}
        //if (!p3State.IsConnected)
        //{
        //    Players[2].SetActive(false);
        //    Cameras[2].SetActive(false);
        //}
        //if (!p4State.IsConnected)
        //{
        //    Players[3].SetActive(false);
        //    Cameras[3].SetActive(false);
        //}


        //if(p1State.IsConnected && p2State.IsConnected && !p3State.IsConnected && !p4State.IsConnected)
        //{
        //    Cameras[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
        //    Cameras[1].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
        //}
        //if (p1State.IsConnected && p2State.IsConnected && p3State.IsConnected && !p4State.IsConnected)
        //{
        //    //Cameras[2].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
        //    Cameras[3].SetActive(true);
        //    //P4Cam.enabled = false;
        //    P4Image.SetActive(true);
        //}


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
