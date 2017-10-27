using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterSoulDropOff : MonoBehaviour {

    public int P1storedSouls;
    public int P2storedSouls;
    public int P3storedSouls;
    public int P4storedSouls;



    public Light winLight;

    public Color p1;
    public Color p2;
    public Color p3;
    public Color p4;
    Color Winner;


    public Timer time;
    public WinState[] winStates;

    // Use this for initialization
    void Start()
    {
        P1storedSouls = 0;
        P2storedSouls = 0;
        P3storedSouls = 0;
        P4storedSouls = 0;
    }
    void UpdateMasterLight()
    {
        int highScore = Mathf.Max(P1storedSouls, P2storedSouls, P3storedSouls, P4storedSouls);
        if (P1storedSouls == highScore)
        {
            winLight.color = p1;
        }
        if (P2storedSouls == highScore)
        {
            winLight.color = p2;
        }
        if (P3storedSouls == highScore)
        {
            winLight.color = p3;
        }
        if (P4storedSouls == highScore)
        {
            winLight.color = p4;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Test")
        {
            var soulCarrier = other.GetComponent<SoulCarrier>();
            if (soulCarrier != null)
            {
                ParticleSystem ps = other.GetComponent<SoulCarrier>().dropOff;
                var emission = ps.emission;

                if (soulCarrier.carriedSouls > 0)
                {
                    ps.gameObject.SetActive(true);
                    emission.rateOverTime = soulCarrier.carriedSouls;
                }

                switch (soulCarrier.playerNum)
                {
                    case 1:
                        P1storedSouls += soulCarrier.carriedSouls;
                        soulCarrier.carriedSouls = 0;
                        soulCarrier.UpdateLight();
                        break;
                    case 2:
                        P2storedSouls += soulCarrier.carriedSouls;
                        soulCarrier.carriedSouls = 0;
                        soulCarrier.UpdateLight();
                        break;
                    case 3:
                        P3storedSouls += soulCarrier.carriedSouls;
                        soulCarrier.carriedSouls = 0;
                        soulCarrier.UpdateLight();
                        break;
                    case 4:
                        P4storedSouls += soulCarrier.carriedSouls;
                        soulCarrier.carriedSouls = 0;
                        soulCarrier.UpdateLight();
                        break;
                }

            }

            UpdateMasterLight();
        }
    }
    

    void CalculateWinner()
    {
        int highestScore = Mathf.Max(P1storedSouls, P2storedSouls, P3storedSouls, P4storedSouls);
        
        winStates[0].score = P1storedSouls;
        winStates[1].score = P2storedSouls;
        winStates[2].score = P3storedSouls;
        winStates[3].score = P4storedSouls;

        for (int i = 0; i < 4; i++)
        {
            winStates[i].HighestScore = highestScore;
            winStates[i].GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        


        if(time.time < 0)
        {
            CalculateWinner();
        }
    }
}
