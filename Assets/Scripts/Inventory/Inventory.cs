using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[numItemSlots];
    public Image[] itemImages = new Image[numItemSlots];
    int currency = 0;

    public const int numItemSlots = 6;

    /// <summary>
    /// Adds an item to the inventory if possible.
    /// </summary>
    /// <param name="itemToAdd">The item to add.</param>
    /// <returns>Returns true if item was added to inventory.
    /// Returns false if item could not be added.</returns>
    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
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
                return true;
            }
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
}


