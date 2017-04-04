using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the player object.
/// </summary>
public class PlayerController : MonoBehaviour {
    //Forward thrust speed.
    public float thrustSpeed;
    //Deceleration speed.
    public float stopSpeed;
    //Speed to turn the ship.
    public float turnSpeed;
    //Rate at which weapons can fire.
    public float fireRate;
    

    //The object spawned upon firing.
    public GameObject shot;
    //Empty GameObject used for the spawn location of shots.
    public Transform shotSpawn;

    public static PlayerController player;

    private float nextFire;

    //Make player persistant through scenes.
    private void Awake()
    {
        if (player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
        
    }

    // Use this for initialization
    void Start () {
        nextFire = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject newBolt = 
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            //newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            GetComponent<AudioSource>().Play();
            
            //if (bonusShots > 0)
            //{
            //    for (int i = 1; i <= bonusShots; i++)
            //    {
            //        newBolt = (GameObject)Instantiate(shot, shotSpawn.position + Vector3.left * i * shotSpread, shotSpawn.rotation);
            //        newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            //        newBolt = (GameObject)Instantiate(shot, shotSpawn.position + Vector3.right * i * shotSpread, shotSpawn.rotation);
            //        newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            //    }
            //}
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rigidbody body = GetComponent<Rigidbody>();
        if (moveVertical > 0)
        {
            body.AddForce(transform.forward * thrustSpeed * moveVertical);
        }
        else
        {
            body.AddForce(transform.forward * stopSpeed * moveVertical);
        }
        transform.Rotate(0, moveHorizontal * turnSpeed, 0);

    }
}

class Inventory
{
    Item[] items = new Item[maxItems];
    Image[] itemImages = new Image[maxItems];
    int currency = 0;

    const int maxItems = 6;

    public bool AddItem(Item newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;
                itemImages[i].sprite = newItem.sprite;
                itemImages[i].enabled = true;
                return true;
            }
        }

        return false;
    }

    public bool RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return true;
            }
        }

        return false;
    }

    public void AddCurrency(int extraCurrency)
    {
        currency += extraCurrency;
    }

    public bool RemoveCurrency(int debit)
    {
        if (currency - debit >= 0)
        {
            currency -= debit;
            return true;
        }
        return false;
    }
}

class Item
{
    public Sprite sprite;
    public string name;
    public int value;
}


