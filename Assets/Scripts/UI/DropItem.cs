using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
    public void Drop(int index)
    {
        //Debug.Log("Try to drop");
        Inventory inventory = PlayerController.player.GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.Log("Error: Player inventory null.");
            return;
        }
        PlayerController player = PlayerController.player.GetComponent<PlayerController>();
        if (inventory.items[index] != null)
        {
            //Instantiate(inventory.items[index], player.dropSpawn.transform.position, player.dropSpawn.transform.rotation);
            inventory.items[index].transform.position = player.dropSpawn.transform.position;
            inventory.items[index].consumed = false;
            inventory.items[index].gameObject.SetActive(true);
            inventory.RemoveItem(index);
        }
        
    }
	
}
