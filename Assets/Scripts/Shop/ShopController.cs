using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
    public Transform sellListPanel;
    public Text creditsText;
    public Text shieldText;
    public Text fuelText;
    public Text hullText;

    //public GameObject mineralSlotPrefab;
    Inventory playerInventory;
    public static ShopController shopController;

    const int NAME_TEXT_INDEX = 1;
    const int VALUE_TEXT_INDEX = 2;
    const int CARGO_TEXT_INDEX = 3;

    const int REPAIR_PRICE = 2;
    const int REFUEL_PRICE = 1;
    
    private void Awake()
    {
        if (PlayerController.player != null)
        {
            playerInventory = PlayerController.player.GetComponent<Inventory>();
            if (playerInventory == null)
            {
                Debug.Log("Error: Player inventory is null.");
                return;
            }
        }
        else
        {
            Debug.Log("Error: PlayerController.player is null.");
            return;
        }

        if (ShopController.shopController == null)
        {
            shopController = this;
            
        }
        else if (shopController != this)
        {
            Destroy(gameObject);
        }
        //FillSellList();

    }

    public void UpdateUI()
    {
        UpdateSellList();
        creditsText.text = playerInventory.GetCurrency() + "";
        shieldText.text = PlayerController.player.GetComponent<Destructable>().shield + "";
        hullText.text = PlayerController.player.GetComponent<Destructable>().health + "";
        fuelText.text = (int)(PlayerController.player.GetComponent<PlayerController>().fuel) + "";
    }

    

    /// <summary>
    /// Updates current resource cargo.
    /// </summary>
    void UpdateSellList()
    {
        //Debug.Log("Trying to update sell list.");
        //for each mineral slot, update the current available cargo text.
        for (int i = 0; i < sellListPanel.childCount; i++)
        {
            Text nameText = sellListPanel.GetChild(i).GetChild(NAME_TEXT_INDEX).GetComponent<Text>();
            Text cargoText = sellListPanel.GetChild(i).GetChild(CARGO_TEXT_INDEX).GetComponent<Text>();
            cargoText.text = playerInventory.GetItemCount(nameText.text) + "";
        }
    }

    /// <summary>
    /// Sells the mineral at mineralSlot index.
    /// </summary>
    /// <param name="index">Hierarchy index of mineralSlot</param>
    public void SellMinerals(int index)
    {
        //Debug.Log("Trying to sell minerals.");
        int numMinerals = playerInventory.GetItemCount(sellListPanel.GetChild(index).GetChild(NAME_TEXT_INDEX).GetComponent<Text>().text);
        if (numMinerals <= 0)
        {
            return;
        }

        int mineralValue;
        string mineralString = sellListPanel.GetChild(index).GetChild(VALUE_TEXT_INDEX).GetComponent<Text>().text;
        mineralString = mineralString.Substring(0, mineralString.Length - mineralString.IndexOf(' '));
        Int32.TryParse(mineralString, out mineralValue);

        playerInventory.RemoveItemsOfType(sellListPanel.GetChild(index).GetChild(NAME_TEXT_INDEX).GetComponent<Text>().text);
        playerInventory.AddCurrency(mineralValue * numMinerals);

        //Debug.Log("minValue: " + mineralValue);
        //Debug.Log("numMinerals: " + numMinerals);

        UpdateUI();
        HUD_Controller.hudController.UpdateUI();
    }

    /// <summary>
    /// In progress.
    /// </summary>
    public void SellAllMinerals()
    {
        SellMinerals(0);
    }

    public void Repair()
    {
        Destructable playerDes = PlayerController.player.GetComponent<Destructable>();
        float canHeal = playerDes.maxHealth - playerDes.health;
        if (canHeal > 0)
        {
            Inventory playerInv = playerDes.GetComponent<Inventory>();
            int price = (int)canHeal * REPAIR_PRICE;
            if (playerInv.GetCurrency() > price)
            {
                playerInv.RemoveCurrency((int)canHeal * REPAIR_PRICE);
                playerDes.health = playerDes.maxHealth;
            }
            else
            {
                int payable = price - playerInv.GetCurrency();
                playerDes.health += payable / REPAIR_PRICE;
                playerInv.RemoveCurrency(payable);
            }
            UpdateUI();
            HUD_Controller.hudController.UpdateUI();
            
        }
    }

    public void Refuel()
    {
        PlayerController playerCon = PlayerController.player.GetComponent<PlayerController>();
        float canFuel = playerCon.maxFuel - playerCon.fuel;
        if (canFuel > 0)
        {
            Inventory playerInv = playerCon.GetComponent<Inventory>();
            int price = (int)canFuel * REFUEL_PRICE;
            if (playerInv.GetCurrency() > price)
            {
                playerInv.RemoveCurrency((int)canFuel * REFUEL_PRICE);
                playerCon.fuel = playerCon.maxFuel;
            }
            else
            {
                int payable = price - playerInv.GetCurrency();
                playerCon.fuel += payable / REFUEL_PRICE;
                playerInv.RemoveCurrency(payable);
            }
            UpdateUI();
            HUD_Controller.hudController.UpdateUI();

        }
    }
}
