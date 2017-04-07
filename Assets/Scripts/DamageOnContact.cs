using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour {
    public float damage;
    public bool destroyOnContact;


    void OnTriggerEnter(Collider other)
    {
        //If object is destructable, do damage.
        Destructable DObject = other.gameObject.GetComponent<Destructable>();
        if (DObject != null)
        {
            //Debug.Log("Do damage");
            DObject.DoDamage(damage);
            if (other.tag == "Player")
            {
                HUD_Controller.hudController.UpdateUI();
            }
        }
        
        //if object should destroy itself on contact (eg. bolts).
        if (destroyOnContact)
            Destroy(gameObject);
    }
}
