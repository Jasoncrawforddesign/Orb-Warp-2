﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager: MonoBehaviour
{
	private int playerAsteroidCount;
	public GameObject gm;
	public GameObject asteroidPrefab;
	private float asteroidSpeed;
	public GameObject pickupPrefab_PH;
	public float pickupSpeed;

	public GameObject spawnPos1;
	public GameObject spawnPos2;
	public GameObject spawnPos3;
	public GameObject spawnPos4;
	private int spawnPointAvailable;

	public GameObject[] spawnPositions;
	private GameObject currentSpawn;
	private int spawnPositionsIndex;


	public GameObject rotationSpeedPickupPrefab;
	public GameObject extraPaddlePickupPrefab;
	public GameObject oneUseShieldPickupPrefab;
	public GameObject doublePointsPickupPrefab;
	public GameObject laserBeamPickupPrefab;

	// if this == true pickups are able to spawn, should only be allowed when a pickup is not currently active or one spawned.
	public bool isPickupAllowed;
	[Tooltip("1 being 100%, 100 being 1% chance")]
	public float pickupSpawnChance;
	public float pickupSpawnChancePrivate;

	public float startSpawning;
	public float repeatSpawning;


	// Start is called before the first frame update
    void Start()
    {
		pickupSpawnChancePrivate = pickupSpawnChance;
		spawnPositions = GameObject.FindGameObjectsWithTag("spawnPos");
	}

    // Update is called once per frame
    void Update()
    {

	}

	///-------------------------------BELOW: Respawn Asteroid Function----------------------------------------------------------
	/// This function respawnBall() allows the asteroids to spawn from any 4 spawn locations, it's randomised where they spawn using Random.Range.
	/// However the variable spawnPointAvailable is used to cap which spawn points are accessible 
	/// eg. if spawnPointAvailable = 2, only case 1 of the switch statement will work.
	/// Note: This function can totally be tidied up in the future, it may need to be done to allow spawnPoints to be a complete circle around the centre,
	/// rather then a rectangle. this could stop multiple asteroids hitting the centre at once.
	#region respawnBall function OLD
	//public void respawnBall()
	//{
	//	float randNum = Random.Range (1, spawnPointAvailable);

	//	switch (randNum)
	//	{
	//		case 1:
	//			GameObject clonePrefab1 = Instantiate(asteroidPrefab, (spawnPos1.transform.position + new Vector3(Random.Range(-10, 10), 0, 0)), spawnPos1.transform.rotation) as GameObject;
	//			clonePrefab1.name = "Asteroid";
	//			clonePrefab1.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
	//			Destroy(clonePrefab1, 10);
	//			break;

	//		case 2:
	//			GameObject clonePrefab2 = Instantiate(asteroidPrefab, (spawnPos2.transform.position + new Vector3(0, Random.Range(-10, 10), 0)), spawnPos2.transform.rotation) as GameObject;
	//			clonePrefab2.name = "Asteroid";
	//			clonePrefab2.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
	//			Destroy(clonePrefab2, 10);
	//			break;

	//		case 3:
	//			GameObject clonePrefab3 = Instantiate(asteroidPrefab, (spawnPos3.transform.position + new Vector3(0, Random.Range(-10, 10), 0)), spawnPos3.transform.rotation) as GameObject;
	//			clonePrefab3.name = "Asteroid";
	//			clonePrefab3.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
	//			Destroy(clonePrefab3, 10);
	//			break;

	//		case 4:
	//			GameObject clonePrefab4 = Instantiate(asteroidPrefab, (spawnPos4.transform.position + new Vector3(Random.Range(-10, 10), 0, 0)), spawnPos4.transform.rotation) as GameObject;
	//			clonePrefab4.name = "Asteroid";
	//			clonePrefab4.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
	//			Destroy(clonePrefab4, 10);
	//			break;
	//	}
	//}

	#endregion

	#region current respawnBall function
	public void respawnBall()
	{
		spawnPositionsIndex = Random.Range(0, spawnPositions.Length);
		currentSpawn = spawnPositions[spawnPositionsIndex];

		GameObject clonePrefab1 = Instantiate(asteroidPrefab, currentSpawn.transform.position, Quaternion.identity) as GameObject;
		clonePrefab1.name = "Asteroid";
		clonePrefab1.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
		Destroy(clonePrefab1, 10);
	}
	#endregion

	/// --------------------------BELOW: Adjust Variable Functions-----------------------
	/// This function is called everytime a asteroid is "caught", when a case (num) equals amount of asteroids the player has "caught"
	/// the case will then adjust variables to increase difficulty.
	/// NOTE: if implementing Multiplier counter, this will need to count amount of asteroids caught throughout a run, 
	/// rather than counting the playerAsteroidCount, as checking against the playerAsteroidCount wouldn't be the real difficulty curve.
	#region adjustVariables function
	public void adjustVariables()
	{
		playerAsteroidCount = gm.GetComponent<GameManager>().asteroidCounter;

		switch (playerAsteroidCount)
		{
			case 0:
				asteroidSpeed = 4;
				repeatSpawning = 1.5f;
				spawnPointAvailable = 2;

				adjustedVariableInfo();
				break;

			case 5:
				asteroidSpeed = 4;
				repeatSpawning = 1f;
				spawnPointAvailable = 3;

				adjustedVariableInfo();
				break;

			case 10:
				asteroidSpeed = 4;
				repeatSpawning = .9f;
				spawnPointAvailable = 4;


				adjustedVariableInfo();
				break;

			case 15:
				asteroidSpeed = 4;
				repeatSpawning = .8f;
				spawnPointAvailable = 5;

				adjustedVariableInfo();
				break;

			case 20:
				asteroidSpeed = 4;
				repeatSpawning = .7f;

				adjustedVariableInfo();
				break;

			case 25:
				asteroidSpeed = 4;
				repeatSpawning = .9f;


				adjustedVariableInfo();
				break;

			case 30:
				asteroidSpeed = 5;
				repeatSpawning = 1.2f;

				adjustedVariableInfo();
				break;

			case 35:
				asteroidSpeed = 5;
				repeatSpawning = 1.1f;


				adjustedVariableInfo();
				break;

			case 40:
				asteroidSpeed = 5;
				repeatSpawning = 1f;

				adjustedVariableInfo();
				break;

			case 45:
				asteroidSpeed = 5;
				repeatSpawning = .9f;

				adjustedVariableInfo();
				break;

			case 50:
				asteroidSpeed = 5.2f;
				repeatSpawning = .8f;

				adjustedVariableInfo();
				break;

			case 55:
				asteroidSpeed = 5.4f;
				repeatSpawning = .7f;

				adjustedVariableInfo();
				break;

			case 60:
				asteroidSpeed = 5.6f;
				repeatSpawning = .9f;

				adjustedVariableInfo();
				break;

			case 65:
				asteroidSpeed = 6;
				repeatSpawning = 1;

				//this will plus 5 to the speed
				gm.GetComponent<GameManager>().newPlayerSpeed(5);

				adjustedVariableInfo();
				break;

			case 70:
				asteroidSpeed = 6;
				repeatSpawning = .9f;

				adjustedVariableInfo();
				break;

			case 75:
				asteroidSpeed = 6;
				repeatSpawning = .8f;

				adjustedVariableInfo();
				break;

			case 100:
				asteroidSpeed = 6;
				repeatSpawning = .7f;

				gm.GetComponent<GameManager>().newPlayerSpeed(5);

				adjustedVariableInfo();
				break;

			case 110:
				asteroidSpeed = 6;
				repeatSpawning = .7f;


				adjustedVariableInfo();
				break;

			case 115:
				asteroidSpeed = 6f;
				repeatSpawning = .6f;
				adjustedVariableInfo();
				break;

			case 150:
				asteroidSpeed = 6f;
				repeatSpawning = 0.5f;

				adjustedVariableInfo();
				break;

			default:
				Debug.Log("spawning variable didn't change");
				break;

		}

	}

	void adjustedVariableInfo()
	{
		Debug.Log("Case:" + playerAsteroidCount + ".");
		//Debug.Log("Asteroid Speed is now: " + asteroidSpeed);
		//Debug.Log("Repeat Spawning every " + repeatSpawning + " seconds.");
	}

	//public void adjustVariables()
	//{
	//	playerScore = gm.GetComponent<GameManager>().currentScore;

	//	switch (playerScore)
	//	{
	//		case 0:
	//			asteroidSpeed = 6.5f;
	//			repeatSpawning = .6f;
	//			adjustedVariableInfo();
	//			spawnPointAvailable = 5;
	//			break;

	//		default:
	//			Debug.Log("spawning variable didn't change");
	//			break;

	//	}

	//}

	#endregion


	//This function spawns the initial 2 asteroids for when the player starts a run.
	void initialSpawn()
	{
		GameObject clonePrefab1 = Instantiate(asteroidPrefab, (spawnPos1.transform.position + new Vector3(Random.Range(-2, 2), -4, 0)), spawnPos1.transform.rotation) as GameObject;
		clonePrefab1.name = "Asteroid";
		clonePrefab1.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
		Destroy(clonePrefab1, 10);

		GameObject clonePrefab2 = Instantiate(asteroidPrefab, (spawnPos1.transform.position + new Vector3(Random.Range(-3, 3), -1, 0)), spawnPos1.transform.rotation) as GameObject;
		clonePrefab2.name = "Asteroid";
		clonePrefab2.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
		Destroy(clonePrefab1, 10);

	}

	//This function is called when the player starts a run, it will run initialSpawn(), then start spawning the asteroids
	//and adjust variables when needed.
	public void startSpawner()
	{
		adjustVariables();
		//initialSpawn();
		StartCoroutine(SpawnTimer());

	}

	//This corountine counts down how many seconds have past, if hit zero will run respawnBall() to spawn asteroids.
	//it also runs isPickupSpawnable to see if a pickup is able to be spawned.
	IEnumerator SpawnTimer()
	{
		
		yield return new WaitForSeconds(repeatSpawning);
		respawnBall();
		isPickupSpawnable();
		StartCoroutine(SpawnTimer());
	}

	//This function is/should be called when the player has lost the run, it stops the asteroids from spawning.
	public void stopSpawner()
	{
		StopCoroutine(SpawnTimer());
	}



	//Function to check if pickup is able to spawn, 
	//which pickup and the percentage chance of it spawning.
	public void isPickupSpawnable()
	{
		float randNum = Random.Range(1, 101);
		if ((randNum >= pickupSpawnChancePrivate) && (isPickupAllowed == true))
		{
			isPickupAllowed = false;
			float newRandNum = Random.Range(1, 6);

			switch (newRandNum)
			{

				case 1:
					//pickup 1 = Rotation Speed
					spawnPickup(rotationSpeedPickupPrefab);
					break;

				case 2:
					//pickup 2 = Extra Paddle
					spawnPickup(extraPaddlePickupPrefab);
					break;

				case 3:
					//pickup 3 = One use shield
					spawnPickup(oneUseShieldPickupPrefab);
					break;

				case 4:
					//pickup 4 = double points
					spawnPickup(doublePointsPickupPrefab);
					break;

				case 5:
					//pickup 5 = laser beam
					spawnPickup(laserBeamPickupPrefab);
					break;

			}

			pickupSpawnChancePrivate = pickupSpawnChance;

		}
		else
		{
			pickupSpawnChancePrivate -= 1;
		
		}
	}

	//This function spawns the pickup gameobject from and 4 of the spawnLocations, much like the respawnBall() does.
	public void spawnPickup(GameObject pickUp)
	{
		float randNum = Random.Range(1, spawnPointAvailable);

		switch (randNum)
		{
			case 1:
				GameObject clonePrefab1 = Instantiate(pickUp, (spawnPos1.transform.position + new Vector3(Random.Range(-10, 10), 0, 0)), spawnPos1.transform.rotation) as GameObject;
				clonePrefab1.name = "Pickup";
				clonePrefab1.GetComponent<Basic_Asteroid_Function>().moveSpeed = pickupSpeed;
				Destroy(clonePrefab1, 10);
				break;

			case 2:
				GameObject clonePrefab2 = Instantiate(pickUp, (spawnPos2.transform.position + new Vector3(0, Random.Range(-5, 5), 0)), spawnPos2.transform.rotation) as GameObject;
				clonePrefab2.name = "Pickup";
				clonePrefab2.GetComponent<Basic_Asteroid_Function>().moveSpeed = pickupSpeed;
				Destroy(clonePrefab2, 10);
				break;

			case 3:
				GameObject clonePrefab3 = Instantiate(pickUp, (spawnPos3.transform.position + new Vector3(0, Random.Range(-5, 5), 0)), spawnPos3.transform.rotation) as GameObject;
				clonePrefab3.name = "Pickup";
				clonePrefab3.GetComponent<Basic_Asteroid_Function>().moveSpeed = pickupSpeed;
				Destroy(clonePrefab3, 10);
				
				break;

			case 4:
				GameObject clonePrefab4 = Instantiate(pickUp, (spawnPos4.transform.position + new Vector3(Random.Range(-10, 10), 0, 0)), spawnPos4.transform.rotation) as GameObject;
				clonePrefab4.name = "Pickup";
				clonePrefab4.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
				Destroy(clonePrefab4, 10);
				break;
		}
	}

	
	//This function enables isPickupAllowed = true.
	public void pickupAllowed()
	{
		isPickupAllowed = true;
	}


}

