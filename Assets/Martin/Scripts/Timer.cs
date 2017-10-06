using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    public float endTimer;

    public Canvas GameOver;
    int Min;
    int Sec;
    Text RoundTimer;

    // Use this for initialization
    void Start ()
    {
        RoundTimer = GetComponent<Text>();
        GameOver.gameObject.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
            Min = (int)time / 60;
            Sec = (int)time % 60;
        }
        else
        {
            endTimer -= Time.deltaTime;
        }

        if (endTimer <= 0)
        {
            GameOver.gameObject.SetActive(true);
        }
       
        GameTime();

    }

    void GameTime()
    {
        if (Sec >= 10)
        {
            RoundTimer.text = Min + ":" + Sec;
        }
        else
        {
            RoundTimer.text = Min + ":0" + Sec;
        }
       

    }
}
