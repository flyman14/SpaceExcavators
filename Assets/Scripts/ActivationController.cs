﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationController : MonoBehaviour {
    public MeshRenderer[] renderers;
    public MonoBehaviour[] behaviours;

    public void ToggleActivation(bool active)
    {
        //Debug.Log("Toggling activation");
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = active;
        }

        foreach (MonoBehaviour behaviour in behaviours)
        {
            behaviour.enabled = active;
        }
    }
}