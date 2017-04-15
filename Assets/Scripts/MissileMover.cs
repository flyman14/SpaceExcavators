using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissileMover : MonoBehaviour {
    Transform target;
    public float visionAngle;

    NavMeshAgent agent;
    //Transform[] nearbyTransforms = new Transform[100];
    List<Transform> nearbyTransforms = new List<Transform>();

    const int SHIPS_LAYER_INDEX = 8;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.Log("Error: GameObject with MissileMover script cannot find NavMeshAgent component.");
            return;
        }

        SphereCollider rangeCollider = GetComponent<SphereCollider>();
        int shipLayermask = 1 << SHIPS_LAYER_INDEX;
        //Only return colliders in ship layer.
        Collider[] colliders = Physics.OverlapSphere(transform.position, rangeCollider.radius, shipLayermask);
        Transform closest = null;
        foreach (Collider item in colliders)
        {
            //ignore the player
            if (item.tag == "Player")
            {
                continue;
            }

            Vector3 direction = item.transform.position - transform.position;

            if (Vector3.Angle(direction, transform.forward) <= visionAngle)
            {
                if (closest==null || (closest.position - transform.position).sqrMagnitude < (item.transform.position - transform.position).sqrMagnitude)
                {
                    closest = item.transform;
                }
            }

            nearbyTransforms.Add(item.transform);
        }

        if (closest != null)
        {
            target = closest;
        }

    }

    // Update is called once per frame
    void Update () {
        if (target == null)
        {
            agent.velocity = transform.forward * agent.speed;

            //See if any nearby transforms are now within the COV.
            foreach (Transform item in nearbyTransforms)
            {
                if (item == null)
                {
                    continue;
                }
                Vector3 direction = item.position - transform.position;

                if (Vector3.Angle(direction, transform.forward) <= visionAngle)
                {
                    target = item;
                    break;
                }
            }

        }
        else
        {
            agent.SetDestination(target.position);
            
        }	

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyShip")
        {
            nearbyTransforms.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnemyShip")
        {
            nearbyTransforms.Remove(other.transform);
        }
    }
}
