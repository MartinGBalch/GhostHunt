using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public string replayScene;
    public string menuScene;
    public Button replay;
    public Button mainMenu;

	// Use this for initialization
	void Start ()
    {
        replay.GetComponent<Button>();
        mainMenu.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {}

    public void Replay()
    {
        SceneManager.LoadScene(replayScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
