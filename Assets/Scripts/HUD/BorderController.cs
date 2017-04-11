using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderController : MonoBehaviour {
    public Text boundsText;
    public ColorFlash boundsFlash;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            boundsText.enabled = true;
            boundsFlash.enabled = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boundsText.enabled = false;
            boundsFlash.enabled = false;
        }
        
    }
}
