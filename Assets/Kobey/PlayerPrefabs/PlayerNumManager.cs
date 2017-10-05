using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class PlayerNumManager : MonoBehaviour {

    public GameObject[] Players;
    public GameObject[] Cameras;
    PlayerIndex p1 = PlayerIndex.One;
    PlayerIndex p2 = PlayerIndex.Two;
    PlayerIndex p3 = PlayerIndex.Three;
    PlayerIndex p4 = PlayerIndex.Four;
    GamePadState p1State;
    GamePadState p2State;
    GamePadState p3State;
    GamePadState p4State;

    // Use this for initialization
    void Start()
    {
        p1State = GamePad.GetState(p1);
        p2State = GamePad.GetState(p2);
        p3State = GamePad.GetState(p3);
        p4State = GamePad.GetState(p4);


        if(!p1State.IsConnected)
        {
            Players[0].SetActive(false);
            Cameras[0].SetActive(false);
        }
        if (!p2State.IsConnected)
        {
            Players[1].SetActive(false);
            Cameras[1].SetActive(false);
        }
        if (!p3State.IsConnected)
        {
            Players[2].SetActive(false);
            Cameras[2].SetActive(false);
        }
        if (!p4State.IsConnected)
        {
            Players[3].SetActive(false);
            Cameras[3].SetActive(false);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
