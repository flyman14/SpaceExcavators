using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour {

	public void Close()
    {
        PlayerController.inventoryCanvas.enabled = false;
    }
}
