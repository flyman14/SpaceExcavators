﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {
    //Health points.
    public float health;
    //Maximum health points.
    public float maxHealth;
    //Regenerating shield.
    public float shield;
    //Max shield points.
    public float maxShield;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoDamage(float damage)
    {
        if (shield > 0)
        {
            //If shields are strong enough to absorb impact.
            if (shield >= damage)
            {
                shield -= damage;
            }
            else
            {
                float tempdmg = damage - shield;
                shield = 0;
                health -= tempdmg;
            }
        }
        else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
