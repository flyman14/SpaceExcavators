﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {
    public Transform sellListPanel;
    public Transform upgradeListPanel;
    public Text creditsText;
    public Text shieldText;
    public Text fuelText;
    public Text hullText;
    public Text missilesText;

    public GameObject upgradedShotPrefab;

    //public GameObject mineralSlotPrefab;
    Inventory playerInventory;
    public static ShopController shopController;

    const int NAME_TEXT_INDEX = 1;
    const int VALUE_TEXT_INDEX = 2;
    const int CARGO_TEXT_INDEX = 3;

    const int UPGRADE_BUTTON_INDEX = 3;
    const int UPGRADE_PRICE_INDEX = 2;

    const float SPEED_UPGRADE_AMOUNT = 1.5f;

    const int REPAIR_PRICE = 2;
    const int REFUEL_PRICE = 1;
    const int MISSILE_PRICE = 50;
    
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
        missilesText.text = "Missiles: " + PlayerController.player.GetComponent<PlayerController>().missileStock;
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
        mineralString = mineralString.Substring(0, mineralString.Length - (mineralString.Length - mineralString.IndexOf(' ')));
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
        SellMinerals(1);
        SellMinerals(2);
        SellMinerals(3);
        SellMinerals(4);
        SellMinerals(5);
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
                int payable = playerInv.GetCurrency();
                playerDes.health += payable / REPAIR_PRICE;
                playerInv.RemoveCurrency(REPAIR_PRICE * (payable / REPAIR_PRICE));
            }
            UpdateUI();
            HUD_Controller.hudController.UpdateUI();
            
        }
    }

    public void RefillMissiles()
    {
        PlayerController playerCon = PlayerController.player.GetComponent<PlayerController>();
        float canRefill = playerCon.maxMissiles - playerCon.missileStock;
        if (canRefill > 0)
        {
            Inventory playerInv = playerCon.GetComponent<Inventory>();
            int price = (int)canRefill * MISSILE_PRICE;
            if (playerInv.GetCurrency() > price)
            {
                playerInv.RemoveCurrency((int)canRefill * MISSILE_PRICE);
                playerCon.missileStock = playerCon.maxMissiles;
            }
            else
            {
                int payable = playerInv.GetCurrency();
                playerCon.missileStock += payable / MISSILE_PRICE;
                playerInv.RemoveCurrency(MISSILE_PRICE * (payable / MISSILE_PRICE));
                
            }
            UpdateUI();
            HUD_Controller.hudController.UpdateUI();

        }
    }

    public void Refuel()
    {
        PlayerController playerCon = PlayerController.player.GetComponent<PlayerController>();
        float canRefill = playerCon.maxFuel - playerCon.fuel;
        if (canRefill > 0)
        {
            Inventory playerInv = playerCon.GetComponent<Inventory>();
            int price = (int)canRefill * REFUEL_PRICE;
            if (playerInv.GetCurrency() > price)
            {
                playerInv.RemoveCurrency((int)canRefill * REFUEL_PRICE);
                playerCon.fuel = playerCon.maxFuel;
            }
            else
            {
                int payable = playerInv.GetCurrency();
                playerCon.fuel += payable / REFUEL_PRICE;
                playerInv.RemoveCurrency(REFUEL_PRICE * (payable / REFUEL_PRICE));
            }
            UpdateUI();
            HUD_Controller.hudController.UpdateUI();

        }
    }

    public void Upgrade(int index)
    {
        PlayerController playerCon = PlayerController.player.GetComponent<PlayerController>();
        Inventory playerInv = playerCon.GetComponent<Inventory>();

        if (playerCon == null || playerInv == null)
        {
            Debug.Log("Error: player controller or inventory null");
            return;
        }

        string priceString = upgradeListPanel.GetChild(index).GetChild(UPGRADE_PRICE_INDEX).GetComponent<Text>().text;
        priceString = priceString.Substring(0, priceString.Length - (priceString.Length - priceString.IndexOf(' ')));
        int priceValue = 0;
        if (!Int32.TryParse(priceString, out priceValue))
        {
            Debug.Log("Error in parsing upgrade price.");
            return;
        }

        if (playerInv.GetCurrency() >= priceValue)
        {
            Destructable playerDes = playerCon.GetComponent<Destructable>();
            switch (index)
            {
                case 0:
                    playerCon.shot = upgradedShotPrefab;
                    break;
                case 1:
                    playerCon.doubleShotUpgrade = true;
                    break;
                case 2:
                    playerDes.maxShield *= 2;
                    playerDes.shield = playerDes.maxShield;
                    break;
                case 3:
                    playerDes.maxHealth *= 2;
                    playerDes.health = playerDes.maxHealth;
                    break;
                case 4:
                    playerCon.thrustSpeed *= SPEED_UPGRADE_AMOUNT;
                    playerCon.stopSpeed *= SPEED_UPGRADE_AMOUNT;
                    playerCon.turnSpeed *= SPEED_UPGRADE_AMOUNT;
                    break;
                default:
                    Debug.Log("Error: Upgrade given invalid index value.");
                    return;
            }

            playerInventory.RemoveCurrency(priceValue);
            upgradeListPanel.GetChild(index).GetChild(UPGRADE_BUTTON_INDEX).GetComponent<Button>().enabled = false;
            upgradeListPanel.GetChild(index).GetComponent<Image>().color = Color.red;
            UpdateUI();
            HUD_Controller.hudController.UpdateUI();
            
        }
    }
}
