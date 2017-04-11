using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyCanvasController : MonoBehaviour {
    public Slider enemyHealthSlider;
    public Slider enemyShieldSlider;

    public Destructable enemyDes;

    Quaternion identity = Quaternion.Euler(90, 0, 0);

	// Use this for initialization
	void Start () {
        enemyHealthSlider.value = 0;
        enemyShieldSlider.value = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Canvas>().enabled)
        {
            enemyHealthSlider.value = enemyDes.health / enemyDes.maxHealth;
            enemyShieldSlider.value = enemyDes.shield / enemyDes.maxShield;
            transform.rotation = identity;
        }

        //if enemy has damage
        if (enemyDes.health == enemyDes.maxHealth && enemyDes.shield == enemyDes.maxShield)
        {
            GetComponent<Canvas>().enabled = false;
        } else
        {
            GetComponent<Canvas>().enabled = true; ;
        }

    }
}
