using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : MonoBehaviour
{
    public int score;
    public int HighestScore;
    public Color LoseColor;
    Text Win;
    Text Lose;
	// Use this for initialization
	void Start ()
    {
        Win = GetComponent<Text>();
        Lose = GetComponent<Text>();
        //GameOver();
	}
	
	// Update is called once per frame
	void Update () {}

    public void GameOver()
    {
        if (score == HighestScore)
        {
            Win.text = "You Win" + "\n" + score;
        }
        else
        {
            Lose.text = "You Lose" + "\n" + score;
            Lose.color = LoseColor;
        }
            
    }
}
