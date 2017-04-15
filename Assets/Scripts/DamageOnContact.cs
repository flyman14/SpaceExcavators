using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour {
    public float damage;
    public bool destroyOnContact;
    public float maxDistance;


    void OnTriggerEnter(Collider other)
    {
        //Make sure the collision is within max allowable distance.
        if (maxDistance != 0 && (other.ClosestPoint(transform.position) - transform.position).sqrMagnitude >= maxDistance * maxDistance)
        {
            return;
        }

        ////Make sure the collision is within max allowable distance.
        //if (maxDistance != 0 && (other.transform.position - transform.position).sqrMagnitude >= maxDistance * maxDistance)
        //{
        //    return;
        //}

        //If object is destructable, do damage.
        Destructable DObject = other.gameObject.GetComponent<Destructable>();
        if (DObject != null)
        {
            //Debug.Log("Do damage");
            DObject.DoDamage(damage);
            if (other.tag != null && other.tag == "Player")
            {
                HUD_Controller.hudController.UpdateUI();
            }
        }

        //if object should destroy itself on contact (eg. bolts).
        if (destroyOnContact)
        {
            try
            {
                GetComponent<SpawnItemOnDestroy>().Spawn();
            }
            catch (System.Exception)
            {

                throw;
            }
            Destroy(gameObject);
        }
    }
}
