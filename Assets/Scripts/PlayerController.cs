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
    public float fuel;
    public float maxFuel;
    public float fuelConsumeRate;

    public bool doubleShotUpgrade = false;
    const float doubleShotSpacing = 0.2f;

    //The object spawned upon firing.
    public GameObject shot;
    //Empty GameObject used for the spawn location of shots.
    public Transform shotSpawn;
    public Transform dropSpawn;

    public static GameObject player;

    private float nextFire;
    public static Canvas inventoryCanvas;
    bool keyReleaseInventory = true;

    //Make player persistant through scenes.
    private void Awake()
    {
        if (player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = gameObject;
            if (inventoryCanvas == null)
            {
                inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
            }

        }
        else if (player != gameObject)
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
            if (doubleShotUpgrade)
            {
                Vector3 offset = shotSpawn.right * doubleShotSpacing;
                Instantiate(shot, shotSpawn.position + offset, shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position - offset, shotSpawn.rotation);
            }
            else
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
                
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
        if (Input.GetButton("Inventory"))
        {
            if (keyReleaseInventory)
            {
                inventoryCanvas.enabled = !inventoryCanvas.enabled;
                keyReleaseInventory = false;
            }

        }
        else
        {
            keyReleaseInventory = true;
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
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            fuel -= fuelConsumeRate * Time.deltaTime;
            if (fuel <= 0)
            {
                GetComponent<Destructable>().Die();
            }
            HUD_Controller.hudController.UpdateUI();
        }

    }
    
}






