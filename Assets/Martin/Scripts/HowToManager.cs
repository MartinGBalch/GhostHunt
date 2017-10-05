using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToManager : MonoBehaviour
{
    public RawImage HowToControls;
    public RawImage HowToGhosts;
    public RawImage HowToPlayers;

    public Button backMenu;
    public Button backControls;
    public Button backGhosts;

    public Button nextGhosts;
    public Button nextPlayers;


    // Use this for initialization
    void Start ()
    {
        HowToControls.gameObject.SetActive(true);
        HowToGhosts.gameObject.SetActive(false);
        HowToPlayers.gameObject.SetActive(false);
        nextGhosts.gameObject.SetActive(true);
        backMenu.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {}

    public void Controls()
    {
        HowToControls.gameObject.SetActive(true);
        nextGhosts.gameObject.SetActive(true);
        backMenu.gameObject.SetActive(true);
        HowToGhosts.gameObject.SetActive(false);
        nextPlayers.gameObject.SetActive(false);
        backControls.gameObject.SetActive(false);
      
    }

    public void Ghosts()
    {
        HowToGhosts.gameObject.SetActive(true);
        backControls.gameObject.SetActive(true);
        nextPlayers.gameObject.SetActive(true);
        HowToControls.gameObject.SetActive(false);
        HowToPlayers.gameObject.SetActive(false);
        nextGhosts.gameObject.SetActive(false);
        backMenu.gameObject.SetActive(false);
        backGhosts.gameObject.SetActive(false);
    }

    public void Players()
    {
        HowToPlayers.gameObject.SetActive(true);
        backGhosts.gameObject.SetActive(true);
        HowToGhosts.gameObject.SetActive(false);
        nextPlayers.gameObject.SetActive(false);
        backControls.gameObject.SetActive(false);
    }


}
