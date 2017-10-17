using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowManyPlayers : MonoBehaviour {

    public int numOfPlayers;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
  
}
