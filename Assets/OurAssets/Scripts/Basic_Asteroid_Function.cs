using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Asteroid_Function : MonoBehaviour
{

	public GameObject gm;

	private Rigidbody2D rb;
	public float moveSpeed;
	public GameObject earth;

	public bool isAsteroid;


	public bool isPickup;
	[Header("What Type of Pickup is it")]

	private int typeNum;
	public bool isRotationPickup;
	public bool isExtraPaddlePickup;
	public bool isOneUseShieldPickup;
	public bool isDoublePointsPickup;
	public bool isLaserBeamPickup;

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
	void Update()
    {
		//rb.AddForce(transform.right * moveSpeed * Time.deltaTime);

		//transform.Translate(earth.transform.position * moveSpeed * Time.deltaTime, Space.Self);
		transform.position = Vector3.MoveTowards(transform.position, earth.transform.position, moveSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (isAsteroid == true)
		{


			if (collision.gameObject.tag == "SpaceStation")
			{
				gm.GetComponent<GameManager>().addScore();
				Destroy(this.gameObject);
			}

			if (collision.gameObject.tag == "Earth")
			{
				//Lose Game Code enter here
				//gm.GetComponent<GameManager>().MainMenu();
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
			}
		}
		
	}

	private void OnDestroy()
	{
		if (isPickup == true)
		{
			gm.GetComponent<GameManager>().pickUpSpawnCooldown();
		}
	}

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
