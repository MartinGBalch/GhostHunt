using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.UI;
public class ControllerSelection : MonoBehaviour
{
    public Button[] clickAbles;

    PlayerIndex pIdx = PlayerIndex.One;
    GamePadState state;
    GamePadState prevState;
    public int activeIndex;
  
    // Use this for initialization
    void Start ()
    {

        for(int i =0; i < clickAbles.Length; i++)
        {
            
            //clickAbles[i].gameObject.SetActive(false);
        }
        //activeIndex = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        prevState = state;
        state = GamePad.GetState(pIdx);

        if(prevState.ThumbSticks.Left.Y == 0 && state.ThumbSticks.Left.Y > 0)
        {
            
            activeIndex--;
        }
        if (prevState.ThumbSticks.Left.Y == 0 && state.ThumbSticks.Left.Y < 0)
        {
            
            activeIndex++;
        }

        if (activeIndex == 3)
        {
            activeIndex = 0;
        }
        if (activeIndex == -1)
        {
            activeIndex = 2;
        }
        
        if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        {
            clickAbles[activeIndex].onClick.Invoke();
        }
        
        clickAbles[activeIndex].Select();
       
    }
}




