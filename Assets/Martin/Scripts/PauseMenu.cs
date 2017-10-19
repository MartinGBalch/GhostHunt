using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class PauseMenu : MonoBehaviour
{
    public Canvas Paused;
    public Canvas GameOverCanvas;

    public Button resume;
    public Button mainMenu;

    public bool paused;

    public string scene;

    GamePadState state;
    GamePadState prev;
    PlayerIndex playerIDX = PlayerIndex.One;

    // Use this for initialization
    void Start ()
    {
        Paused.gameObject.SetActive(false);
        paused = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        prev = state;
        state = GamePad.GetState(playerIDX);
        if (prev.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed)
        {
            paused = true;
            Paused.gameObject.SetActive(true);
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
        }

    }

    public void Resume()
    {
        paused = false;
        Paused.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(scene);
    }
}
