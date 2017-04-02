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
    public GameObject shotSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
