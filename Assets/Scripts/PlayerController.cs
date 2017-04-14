using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the player object.
/// </summary>
public class PlayerController : MonoBehaviour
{
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
    public float recoilForce;

    public bool doubleShotUpgrade = false;
    const float doubleShotSpacing = 0.2f;

    //The object spawned upon firing.
    public GameObject shot;

    public GameObject missileShot;
    //Empty GameObject used for the spawn location of shots.
    public Transform shotSpawn;
    public Transform dropSpawn;
    public GameObject jetObject;

    public static GameObject player;

    private float nextFire;
    public static Canvas inventoryCanvas;
    bool keyReleaseInventory = true;

    public int missileStock;
    public int maxMissiles;

    //Make player persistant through scenes.
    private void Awake()
    {

        //NOT YET IMPLEMENTED
        //if (player == null)
        //{
        //    //DontDestroyOnLoad(gameObject);
        //    player = gameObject;
        //    if (inventoryCanvas == null)
        //    {
        //        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        //    }

        //}
        //else if (player != gameObject)
        //{
        //    Destroy(gameObject);
        //}

        //For debug
        player = gameObject;
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();

    }

    // Use this for initialization
    void Start()
    {
        nextFire = 0;
    }

    // Update is called once per frame
    void Update()
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
                GetComponent<Rigidbody>().AddForce(transform.forward * -recoilForce * 2f);
            }
            else
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<Rigidbody>().AddForce(transform.forward * -recoilForce);
            }

            //newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            GetComponent<AudioSource>().Play();


        }

        if (Input.GetButton("Fire2") && Time.time > nextFire && missileStock > 0)
        {
            nextFire = Time.time + fireRate;
            //GameObject newBolt = 


            Instantiate(missileShot, shotSpawn.position + transform.forward*1, shotSpawn.rotation);
            GetComponent<Rigidbody>().AddForce(transform.forward * -recoilForce);


            //newBolt.GetComponent<Done_Homer>().turnSpeed = bonusHoming;
            GetComponent<AudioSource>().Play();
            missileStock--;

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
            jetObject.SetActive(true);
        }
        else
        {
            jetObject.SetActive(false);
        }

    }

}






