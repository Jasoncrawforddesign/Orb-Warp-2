using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Asteroid_Function : MonoBehaviour
{

	public GameObject gm;

	private Rigidbody2D rb;
	public float moveSpeed;
	public GameObject earth;

	[Header("Is this an asteroid?")]
	public bool isAsteroid;

	[Header("Is this a Pickup Item?")]
	public bool isPickup;
	[Header("What Type of Pickup is it")]
	public bool isRotationPickup;
	public bool isExtraPaddlePickup;
	public bool isOneUseShieldPickup;
	public bool isDoublePointsPickup;
	public bool isLaserBeamPickup;
	private int typeNum;

	// Start is called before the first frame update
	void Start()
    {
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		earth = GameObject.FindGameObjectWithTag("Earth");
		gm = GameObject.FindGameObjectWithTag("GameManager");

		//updateFacingRotation();

		if(isPickup == true)
		{
			checkPickupType();
		}
	}

	// Update is called once per frame
	// This continuely moves this gameObject towards earth.transform.position/ world.position vector (0,0,0)
	void Update()
    {
		//rb.AddForce(transform.right * moveSpeed * Time.deltaTime);

		//transform.Translate(earth.transform.position * moveSpeed * Time.deltaTime, Space.Self);
		transform.position = Vector3.MoveTowards(transform.position, earth.transform.position, moveSpeed * Time.deltaTime);
	}

	//If this gameObject has collider with something it will first check if this GameObject is an Asteroid or Pickup
	//It will then check against tags, and run corresponding functions.
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isAsteroid == true)
		{
			if (collision.gameObject.tag == "SpaceStation")
			{
				gm.GetComponent<GameManager>().addScore();
				gm.GetComponent<GameManager>().countAsteroid();
				Destroy(this.gameObject);
			}

			if (collision.gameObject.tag == "Earth")
			{
				gm.GetComponent<GameManager>().takeDamage();
				Destroy(this.gameObject);
			}

			if (collision.gameObject.tag == "Shield")
			{
				//Commented out to test shield as invinceability rather then one use, since testing shield/health bar.
				//collision.gameObject.SetActive(false);
				//gm.GetComponent<GameManager>().pickUpTextViewable();
				Destroy(this.gameObject);
			}
		}

		if(isPickup == true)
		{
			if (collision.gameObject.tag == "SpaceStation")
			{
				//activate the pickup Ability
				gm.GetComponent<GameManager>().pickupType(typeNum);

				Destroy(this.gameObject);
			}

			if (collision.gameObject.tag == "Earth")
			{
				Destroy(this.gameObject);
				gm.GetComponent<GameManager>().pickUpAllowed();
			}
		}
		
	}


	public void hitByLaser()
	{
		gm.GetComponent<GameManager>().addScore();
		gm.GetComponent<GameManager>().countAsteroid();
		Destroy(this.gameObject);
	}

	// this function checks what the pickup this gameObject is intended to be
	// typeNum is then used in gm.GetComponent<GameManager>().pickupType(typeNum), where the gameManager will call the correct pickUp Function.
	void checkPickupType()
	{
		if (isRotationPickup == true)
		{
			typeNum = 1;
		}

		if (isExtraPaddlePickup == true)
		{
			typeNum = 2;
		}
		if (isOneUseShieldPickup == true)
		{
			typeNum = 3;
		}
		if (isDoublePointsPickup == true)
		{
			typeNum = 4;
		}
		if (isLaserBeamPickup == true)
		{
			typeNum = 5;
		}
	}

	//This function is used to double check if this gameobject is facing the centre.
	//NOTE: if this function is not used the asteroid gameobject or pickup gameobject will not move in the correct direction.
	void updateFacingRotation()
	{
		transform.LookAt(earth.transform.position);
		Quaternion rotation = this.transform.rotation;
		transform.rotation = Quaternion.LookRotation((new Vector3(0, 0, rotation.y)), transform.up);
		if ((transform.rotation.x == 0) && (transform.rotation.y == 0))
		{
			transform.rotation = Quaternion.LookRotation((new Vector3(0, 0, rotation.y)), transform.up);
		}
	}
}
