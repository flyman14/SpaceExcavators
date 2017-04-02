using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the player object.
/// </summary>
public class PlayerController : MonoBehaviour {
    //Forward thrust speed.
    public float thrustSpeed;
    //Deceleration speed.
    public float stopSpeed;
    //Speed to turn the ship.
    public float turnSpeed;
    //Rate at which weapons can fire.
    public float fireRate;
    

    //The object spawned upon firing.
    public GameObject shot;
    //Empty GameObject used for the spawn location of shots.
    public Transform shotSpawn;

    private float nextFire;

	// Use this for initialization
	void Start () {
        nextFire = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject newBolt = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            GetComponent<AudioSource>().Play();
            
            //if (bonusShots > 0)
            //{
            //    for (int i = 1; i <= bonusShots; i++)
            //    {
            //        newBolt = (GameObject)Instantiate(shot, shotSpawn.position + Vector3.left * i * shotSpread, shotSpawn.rotation);
            //        newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            //        newBolt = (GameObject)Instantiate(shot, shotSpawn.position + Vector3.right * i * shotSpread, shotSpawn.rotation);
            //        newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            //    }
            //}
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rigidbody body = GetComponent<Rigidbody>();
        if (moveVertical > 0)
        {
            body.AddForce(transform.forward * thrustSpeed * moveVertical);
        }
        else
        {
            body.AddForce(transform.forward * stopSpeed * moveVertical);
        }
        transform.Rotate(0, moveHorizontal * turnSpeed, 0);

    }
}
