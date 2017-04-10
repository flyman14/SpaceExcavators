using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[numItemSlots];
    public Image[] itemImages = new Image[numItemSlots];
    public Text[] itemNames = new Text[numItemSlots];

    public int currency = 0;

    public const int numItemSlots = 6;

    /// <summary>
    /// Adds an item to the inventory if possible.
    /// </summary>
    /// <param name="itemToAdd">The item to add.</param>
    /// <returns>Returns true if item was added to inventory.
    /// Returns false if item could not be added.</returns>
    public bool AddItem(Item itemToAdd)
    {
        if (itemToAdd == null)
        {
            Debug.Log("Error: itemToAdd null.");
            return false;
        }
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                if (itemImages[i] == null)
                {
                    Debug.Log("Error: itemImages[i] null");
                }
                if (itemToAdd.sprite == null)
                {
                    Debug.Log("Error: itemToAdd.sprite null");
                }
                itemImages[i].sprite = itemToAdd.sprite;
                
                itemImages[i].enabled = true;
                itemNames[i].text = itemToAdd.itemName;
                itemNames[i].enabled = true;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Removes an item from the inventory.
    /// </summary>
    /// <param name="itemToRemove">The item to remove from the inventory.</param>
    /// <returns>Returns true if item was removed from inventory.
    /// Returns false if item was not removed or does not exist.</returns>
    public bool RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                itemNames[i].text = "";
                itemNames[i].enabled = false;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Removes an item from the inventory.
    /// </summary>
    /// <param name="index">Index of the item.</param>
    /// <returns>Returns true if item was removed from inventory.
    /// Returns false if item does not exist.</returns>
    public bool RemoveItem(int index)
    {
        if (items[index] != null)
        {
            items[index] = null;
            itemImages[index].sprite = null;
            itemImages[index].enabled = false;
            itemNames[index].text = "";
            itemNames[index].enabled = false;
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Adds currency to the inventory.
    /// </summary>
    /// <param name="extraCurrency">The amount of currency to add to the inventory.</param>
    public void AddCurrency(int extraCurrency)
    {
        currency += extraCurrency;
        //Debug.Log("Currency: " + currency);
    }

    public bool RemoveCurrency(int debit)
    {
        if (currency - debit >= 0)
        {
            currency -= debit;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns the number of the specified item currently in the inventory.
    /// </summary>
    /// <param name="itemName">The name of the item. Eg. Gold</param>
    /// <returns>The number of specified items in inventory.</returns>
    public int GetItemCount(string itemName)
    {
        //Debug.Log("Counting items of itemName: " + itemName);
        int count = 0;
        foreach (Item item in items)
        {
            if (item != null)
            {
                //Debug.Log("Item has name: " + item.itemName);
            }
            if (item != null && item.itemName == itemName)
            {
                count++;
            }
        }
        //Debug.Log("Found " + count + " items.");
        return count;
    }

    /// <summary>
    /// Removes all items in the inventory with itemName.
    /// </summary>
    /// <param name="itemName"></param>
    public void RemoveItemsOfType(string itemName)
    {
        foreach (Item item in items)
        {
            if (item != null && item.itemName == itemName)
            {
                RemoveItem(item);
            }
        }
    }

    public int GetCurrency()
    {
        return currency;
    }
}


