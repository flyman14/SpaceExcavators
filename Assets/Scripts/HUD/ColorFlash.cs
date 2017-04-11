using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFlash : MonoBehaviour {
    Text colorText;
    public float flashSpeed;

    float flashTime = 0;
    Color darkRed = new Color(.8f, .8f, 0);
    bool reverse = false;

	// Use this for initialization
	void Start () {
        colorText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (reverse)
        {
            colorText.color = Color.Lerp(darkRed, Color.red, flashTime);
        }
        else
        {
            colorText.color = Color.Lerp(Color.red, darkRed, flashTime);
        }

        flashTime += flashSpeed * Time.deltaTime;
        if (flashTime >= 1f)
        {
            flashTime = 0;
            reverse = !reverse;
        }
        
	}
}
