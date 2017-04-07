using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    bool canOpenShop = false;
    bool keyReleaseShop = true;

    public Canvas shopCanvas;
    //public Canvas openShopTextCanvas;
    public GameObject shopText;

    private void Start()
    {
        shopCanvas = ShopController.shopController.GetComponent<Canvas>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpenShop = true;
            //openShopTextCanvas.enabled = true;
            shopText.SetActive(true);
        }
        if (other.tag == "MainCamera")
        {
            Debug.Log("WTF is happening?");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpenShop = false;
            if (shopCanvas.enabled)
            {
                shopCanvas.enabled = false;
            }
            //openShopTextCanvas.enabled = false;
            shopText.SetActive(false);
        }
        
    }

    private void Update()
    {
        if (canOpenShop)
        {
            if (Input.GetButton("ShopToggle"))
            {
                if (keyReleaseShop)
                {
                    shopCanvas.enabled = !shopCanvas.enabled;
                    keyReleaseShop = false;
                    ShopController.shopController.UpdateUI();
                }

            }
            else
            {
                keyReleaseShop = true;
            }
        }
    }

}
