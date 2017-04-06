using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerMain : MonoBehaviour {
    public static Canvas inventoryCanvas;
    public static Canvas shopCanvas;

    bool keyReleaseInventory = true;
    bool keyReleaseShop = true;

	// Use this for initialization
	void Start () {
        if (inventoryCanvas == null)
        {
            inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        }
        if (shopCanvas == null)
        {
            shopCanvas = GameObject.Find("ShopCanvas").GetComponent<Canvas>();
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

        //if (Input.GetButton("ShopToggle"))
        //{
        //    if (keyReleaseShop)
        //    {
        //        shopCanvas.enabled = !shopCanvas.enabled;
        //        keyReleaseShop = false;
        //    }

        //}
        //else
        //{
        //    keyReleaseShop = true;
        //}
    }
}
