using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    int Min;
    int Sec;
    Text RoundTimer;

    // Use this for initialization
    void Start ()
    {
        RoundTimer = GetComponent<Text>();
        
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
            if(Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
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
