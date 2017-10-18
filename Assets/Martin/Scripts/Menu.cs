using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //buttons for the MainMenu Canvas
    public Button play;
    public Button how;
    public Button exit;

    //button for How-To menu Canvas
    public Button back;

    //buttons for PlayerSelect Canvas
    public Button twoPlayers;
    public Button threePlayers;
    public Button fourPlayers;
    
    //Canvas
    public Canvas Main;
    public Canvas HowTo;
    public Canvas PlayerSelect;

    public string scene;

    HowManyPlayers playerNum;

	// Use this for initialization
	void Start ()
    {
        play = play.GetComponent<Button>();
        how  = how.GetComponent<Button>();
        exit = exit.GetComponent<Button>();

        Main.gameObject.SetActive(true);
        HowTo.gameObject.SetActive(false);
        PlayerSelect.gameObject.SetActive(false);

        Cursor.visible = enabled;

        playerNum = GameObject.FindObjectOfType<HowManyPlayers>();
    }
	
	// Update is called once per frame
	void Update () {}

    public void Play()
    {
        Main.gameObject.SetActive(false);
        PlayerSelect.gameObject.SetActive(true);
    }

    public void How()
    {
        HowTo.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }

    public void Back()
    {
        Main.gameObject.SetActive(true);
        HowTo.gameObject.SetActive(false);
    }

    public void TwoPlayers()
    {
        playerNum.numOfPlayers = 2;
        SceneManager.LoadScene(scene);
    }

    public void ThreePlayers()
    {
        playerNum.numOfPlayers = 3;
        SceneManager.LoadScene(scene);
    }

    public void FourPlayers()
    {
        playerNum.numOfPlayers = 4;
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
