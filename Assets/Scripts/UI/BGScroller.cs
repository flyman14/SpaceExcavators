using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public float scrollFactor;
    public float tileSizeX;
    public float tileSizeZ;
    public Transform rootTransform;
    
	// Update is called once per frame
	void FixedUpdate () {
        float newPosX;
        float newPosY;

        newPosX = Mathf.Repeat(rootTransform.position.x * scrollFactor, tileSizeX);
        newPosY = Mathf.Repeat(rootTransform.position.z * scrollFactor, tileSizeZ);
        
        gameObject.transform.localPosition = new Vector3(-newPosX, -newPosY, 40f);
    }
}
