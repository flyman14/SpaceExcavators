using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Causes the camera to follow around a target. 
/// Target can move within the camera area a specified amount before starting to follow.
/// </summary>
public class CameraFollow : MonoBehaviour {
    //Transform the camera is set to follow around.
    public Transform target;
    //Maximum distances the camera can travel in the x direction. 
    public float xBoundary;
    //Maximum distances the camera can travel in the z direction.
    public float zBoundary;
    // Maximum distance the target can move within the camera area without moving the camera in the x direction.
    public float xBounce;
    // Maximum distance the target can move within the camera area without moving the camera in the z direction.
    public float yBounce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
