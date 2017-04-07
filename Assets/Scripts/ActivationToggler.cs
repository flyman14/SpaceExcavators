using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationToggler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ActivationController ac = other.gameObject.GetComponent<ActivationController>();
        if (ac != null)
        {
            ac.ToggleActivation(true);
        }
        else
        {
            //Debug.Log("Object with tag: " + other.tag + " has no AC.");
            
        }
        //Debug.Log("OnTriggerEnter owner: " + tag);
        //Debug.Log("OnTriggerEnter other collider owner: " + other.tag);
        //else
        //{
        //    Debug.Log("Wat is happenin?");
        //}
        //ac = GetComponent<ActivationController>();
        //if (ac != null)
        //{
        //    ac.ToggleActivation(true);
        //}
        //if (tag == "Planet")
        //{
        //    Debug.Log("Planet activation");
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        ActivationController ac = other.gameObject.GetComponent<ActivationController>();
        if (ac != null)
        {
            ac.ToggleActivation(false);
        }
        //ac = GetComponent<ActivationController>();
        //if (ac != null)
        //{
        //    ac.ToggleActivation(false);
        //}
    }
}
