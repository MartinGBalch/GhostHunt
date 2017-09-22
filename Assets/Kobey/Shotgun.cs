using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

    public float Damage;
    public GameObject Bullet;
    public GameObject spawnPoint;
    public float arcDegrees;
    public float speed;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
    void Shoot()
    {
       // Quaternion startRot = spawnPoint.transform.rotation;
        var babyBullet = Bullet;
        Bullet.transform.position = spawnPoint.transform.position;
        Bullet.transform.rotation = spawnPoint.transform.rotation;
        Instantiate(babyBullet);
        babyBullet.GetComponent<Rigidbody>().velocity = spawnPoint.transform.forward * speed;
        //call this 3 times in for loop, rotate in for loop
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
