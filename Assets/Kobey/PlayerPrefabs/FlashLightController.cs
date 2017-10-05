using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class FlashLightController : MonoBehaviour {


    PlayerIndex pIdx;
    GamePadState state;
    GamePadState prevState;

    new Light light;
    
    private float startIntensity;
    public bool isOn = true;
    public int PlayerNum;
    public bool press;
	// Use this for initialization
	void Start ()
    {
        switch (PlayerNum)
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
        light = gameObject.GetComponent<Light>();
        if (light != null) { Debug.Log("Light attacjed"); }
        startIntensity = light.intensity;
	}
	
    void Switchlight()
    {
        if(isOn)
        {
            light.intensity = startIntensity;
           
            
        }
        else
        {
           
            light.intensity = 0;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(pIdx);


       
        if (state.Buttons.RightShoulder == ButtonState.Released && prevState.Buttons.RightShoulder == ButtonState.Pressed)
        {
           
            isOn = !isOn;
            Switchlight();
        }

        Switchlight();

    }
}
