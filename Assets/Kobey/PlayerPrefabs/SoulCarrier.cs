using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoulCarrier : MonoBehaviour {

    public int carriedSouls;
    public int playerNum;
    public int maxSoulCount;
    public GameObject Soul;
    private float lightIntensity;
    private float lightRange;
    public new Light light;
    public ParticleSystem dropOff;

    float maxRange = 8;
    float maxIntensity = 6;
    float rangeIncrement;
    float intensityIncrement;
	// Use this for initialization
	void Start ()
    {
        carriedSouls = 0;
        lightIntensity = 0;
        rangeIncrement = maxIntensity / maxSoulCount;
        intensityIncrement = maxRange / maxSoulCount;
        light.intensity = lightIntensity;
	}
	
    public void UpdateLight()
    {
        lightIntensity = carriedSouls * intensityIncrement;
        lightRange = carriedSouls * rangeIncrement;
        light.intensity = lightIntensity;
        light.range = lightRange;
    }

    public void DropSouls()
    {
        if(carriedSouls > 0)
        {
            var babySoul = Instantiate(Soul);
            babySoul.transform.position = transform.position;
            babySoul.GetComponent<SoulCollision>().soulAmount = carriedSouls;
            babySoul.GetComponent<SoulCollision>().CollisionDelay = 1.3f;
            carriedSouls = 0;
            UpdateLight();
            //Instantiate(babySoul);
        }
      
        //for(int i = 0; i < carriedSouls; i++)
        //{
        //    var babySoul = Soul;
        //    babySoul.transform.position = transform.position;
        //    Instantiate(babySoul);
        //}
    }

	// Update is called once per frame
	void Update ()
    {
        
	}
}
