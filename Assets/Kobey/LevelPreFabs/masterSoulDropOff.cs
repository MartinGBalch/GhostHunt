using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterSoulDropOff : MonoBehaviour {

    public int P1storedSouls;
    public int P2storedSouls;
    public int P3storedSouls;
    public int P4storedSouls;

    // Use this for initialization
    void Start()
    {
        P1storedSouls = 0;
        P2storedSouls = 0;
        P3storedSouls = 0;
        P4storedSouls = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Test")
        {
            var soulCarrier = other.GetComponent<SoulCarrier>();
            if (soulCarrier != null)
            {
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

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
