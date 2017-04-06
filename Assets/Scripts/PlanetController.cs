using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    bool canOpenShop = false;
    bool keyReleaseShop = true;

    public static Canvas shopCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpenShop = true;
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
                }

            }
            else
            {
                keyReleaseShop = true;
            }
        }
    }

}
