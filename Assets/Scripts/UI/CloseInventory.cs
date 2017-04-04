using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour {

	public void Close()
    {
        GameControllerMain.inventoryCanvas.enabled = false;
    }
}
