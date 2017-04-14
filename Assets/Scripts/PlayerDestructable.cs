using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDestructable : Destructable {
    public Image bloodSplatterImage;
    public float bloodDisappearTime;

    float timeToDisappear = 0;
    
	// Update is called once per frame
	protected new void Update () {
        base.Update();
        bloodSplatterImage.color = new Color(1, 1, 1, timeToDisappear / bloodDisappearTime);
        timeToDisappear = Mathf.Clamp(timeToDisappear - Time.deltaTime, 0, bloodDisappearTime);
        
	}

    public override void DoDamage(float damage)
    {
        base.DoDamage(damage);
        timeToDisappear = bloodDisappearTime;
        bloodSplatterImage.color = Color.white;
        //Debug.Log("PlayerDestructable doDamage");
    }
}
