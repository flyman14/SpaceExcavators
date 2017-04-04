using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerMain : MonoBehaviour {
    public static Canvas inventoryCanvas;

    bool keyReleaseInventory = true;

	// Use this for initialization
	void Start () {
        if (inventoryCanvas == null)
        {
            inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Inventory"))
        {
            if (keyReleaseInventory)
            {
                inventoryCanvas.enabled = !inventoryCanvas.enabled;
                keyReleaseInventory = false;
            }
            
        }
        else
        {
            keyReleaseInventory = true;
        }
    }
}
