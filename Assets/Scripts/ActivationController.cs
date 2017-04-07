using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationController : MonoBehaviour {
    public MeshRenderer[] renderers;

    public void ToggleActivation(bool active)
    {
        Debug.Log("Toggling activation");
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = active;
        }
    }
}
