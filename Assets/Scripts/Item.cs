using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public Sprite sprite;
    public int value;
    public string itemName;
    //public GameObject thisGameObject;

    public bool consumed = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !consumed)
        {
            Inventory inventory = other.gameObject.GetComponent<Inventory>();
            if (inventory != null)
            {
                if (inventory.AddItem(this))
                {
                    consumed = true;
                    gameObject.SetActive(false);
                }
            } else
            {
                Debug.Log("Error: Player inventory null.");
            }
        }
    }

    
}
