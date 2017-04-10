using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShipController : MonoBehaviour {
    Transform player;
    public NavMeshAgent agent;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float visionAngle;
    public float visionDistance;

    float timeToFire = 0;

	// Use this for initialization
	void Start () {
        player = PlayerController.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            return;
            
        }

        agent.SetDestination(player.position);

        Vector3 direction = player.position - transform.position;
        //If player is within CoV
        if (direction.magnitude <= visionDistance && 
            Vector3.Angle(transform.forward, direction) <= visionAngle && 
            timeToFire <= 0)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            timeToFire += fireRate;
        }

        timeToFire = Mathf.Clamp(timeToFire - Time.deltaTime, 0, fireRate);

    }
}
