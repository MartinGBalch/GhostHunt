using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button play;
    public Button how;
    public Button exit;

    public Button back;

    public Canvas Main;
    public Canvas HowTo;

    public string scene;

	// Use this for initialization
	void Start ()
    {
        play = play.GetComponent<Button>();
        how  = how.GetComponent<Button>();
        exit = exit.GetComponent<Button>();

        Main.gameObject.SetActive(true);
        HowTo.gameObject.SetActive(false);

        Cursor.visible = enabled;
    }
	
	// Update is called once per frame
	void Update () {}

    public void Play()
    {
        SceneManager.LoadScene(scene);
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

    public void Exit()
    {
        Application.Quit();
    }
}
