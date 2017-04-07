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
    }

    private void OnTriggerExit(Collider other)
    {
        ActivationController ac = other.gameObject.GetComponent<ActivationController>();
        if (ac != null)
        {
            ac.ToggleActivation(false);
        }
    }
}
