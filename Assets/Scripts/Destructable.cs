using System.Collections;
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

    public float shieldRegen;
    public float regenDelay;

    float timeToRegen = 0;

    public GameObject deathFX;
    
	
	// Update is called once per frame
	protected void Update () {
        if (timeToRegen <= 0 && shield < maxShield)
        {
            shield = Mathf.Clamp(shield + shieldRegen * Time.deltaTime, 0, maxShield);
            HUD_Controller.hudController.UpdateUI();
        }
        else
        {
            timeToRegen -= Time.deltaTime;
        }
	}

    public virtual void DoDamage(float damage)
    {
        //Debug.Log("Try damage");
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

        timeToRegen = regenDelay;

        if (health <= 0)
        {
            //Debug.Log("Die");
            Die();
        }
        
    }

    public void Die()
    {
        SpawnItemOnDestroy spawner = GetComponent<SpawnItemOnDestroy>();
        if (spawner != null)
        {
            spawner.Spawn();
        }
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public float GetHealthPercent()
    {
        return health / maxHealth;
    }

    public float GetShieldPercent()
    {
        return shield / maxShield;
    }
}
