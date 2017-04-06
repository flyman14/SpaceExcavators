using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour {
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;

    public Slider slider;
    public Image fillArea;

    public void UpdateColor()
    {
        fillArea.color = Color.Lerp(MinHealthColor, MaxHealthColor, slider.value / slider.maxValue);
    }


}
