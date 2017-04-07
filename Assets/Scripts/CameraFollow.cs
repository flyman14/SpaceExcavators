﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Causes the camera to follow around a target. 
/// Target can move within the camera area a specified amount before starting to follow.
/// </summary>
public class CameraFollow : MonoBehaviour {
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            transform.position = new Vector3(transform.position.x, 25f, transform.position.z);
        }

    }


}
