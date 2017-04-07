using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour {
    public Text creditText;
    public Slider fuelSlider;
    public Slider shieldSlider;
    public Slider hullSlider;

    public static HUD_Controller hudController;

    private void Awake()
    {
        if (hudController == null)
        {
            hudController = this;
            
        }
        else if (hudController != this)
        {
            Destroy(gameObject);
        }

        
    }

    private void Start()
    {
        UpdateUI();
    }


    public void UpdateUI()
    {
        creditText.text = "CR " + PlayerController.player.GetComponent<Inventory>().GetCurrency();
        hullSlider.value = PlayerController.player.GetComponent<Destructable>().GetHealthPercent();
        
        shieldSlider.value = PlayerController.player.GetComponent<Destructable>().GetShieldPercent();
    }
}
