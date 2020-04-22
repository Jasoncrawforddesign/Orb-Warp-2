using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager: MonoBehaviour
{
	private int playerScore;
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
	}

    // Update is called once per frame
    void Update()
    {

	}

	#region respawnBall function
	public void respawnBall()
	{
		float randNum = Random.Range (1, spawnPointAvailable);

		switch (randNum)
		{
			case 1:
				GameObject clonePrefab1 = Instantiate(asteroidPrefab, (spawnPos1.transform.position + new Vector3(Random.Range(-10, 10), 0, 0)), spawnPos1.transform.rotation) as GameObject;
				clonePrefab1.name = "Asteroid";
				clonePrefab1.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
				Destroy(clonePrefab1, 10);
				break;

			case 2:
				GameObject clonePrefab2 = Instantiate(asteroidPrefab, (spawnPos2.transform.position + new Vector3(0, Random.Range(-10, 10), 0)), spawnPos2.transform.rotation) as GameObject;
				clonePrefab2.name = "Asteroid";
				clonePrefab2.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
				Destroy(clonePrefab2, 10);
				break;

			case 3:
				GameObject clonePrefab3 = Instantiate(asteroidPrefab, (spawnPos3.transform.position + new Vector3(0, Random.Range(-10, 10), 0)), spawnPos3.transform.rotation) as GameObject;
				clonePrefab3.name = "Asteroid";
				clonePrefab3.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
				Destroy(clonePrefab3, 10);
				break;

			case 4:
				GameObject clonePrefab4 = Instantiate(asteroidPrefab, (spawnPos4.transform.position + new Vector3(Random.Range(-10, 10), 0, 0)), spawnPos4.transform.rotation) as GameObject;
				clonePrefab4.name = "Asteroid";
				clonePrefab4.GetComponent<Basic_Asteroid_Function>().moveSpeed = asteroidSpeed;
				Destroy(clonePrefab4, 10);
				break;
		}
	}

	#endregion

	#region adjustVariables function
	public void adjustVariables()
	{
		playerScore = gm.GetComponent<GameManager>().currentScore;
		float newPlayerSpeed;

		switch (playerScore)
		{
			case 0:
				asteroidSpeed = 4;
				repeatSpawning = 2f;
				spawnPointAvailable = 2;

				newPlayerSpeed = 30;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 10:
				asteroidSpeed = 4;
				repeatSpawning = 1.5f;
				spawnPointAvailable = 3;

				newPlayerSpeed = 30;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 20:
				asteroidSpeed = 4;
				repeatSpawning = 1;
				spawnPointAvailable = 4;

				newPlayerSpeed = 30;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 30:
				asteroidSpeed = 5;
				repeatSpawning = 1.5f;
				spawnPointAvailable = 5;

				newPlayerSpeed = 35;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 40:
				asteroidSpeed = 5;
				repeatSpawning = 1.3f;

				newPlayerSpeed = 35;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 50:
				asteroidSpeed = 5;
				repeatSpawning = 1.2f;

				newPlayerSpeed = 35;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 60:
				asteroidSpeed = 5;
				repeatSpawning = 1;

				newPlayerSpeed = 35;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 70:
				asteroidSpeed = 5;
				repeatSpawning = .8f;

				newPlayerSpeed = 35;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 80:
				asteroidSpeed = 5;
				repeatSpawning = .7f;

				newPlayerSpeed = 35;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 90:
				asteroidSpeed = 5.2f;
				repeatSpawning = 1.2f;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 100:
				asteroidSpeed = 5.4f;
				repeatSpawning = 1.1f;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 110:
				asteroidSpeed = 5.6f;
				repeatSpawning = 1;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 120:
				asteroidSpeed = 6;
				repeatSpawning = 1;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 130:
				asteroidSpeed = 6;
				repeatSpawning = .8f;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 140:
				asteroidSpeed = 6;
				repeatSpawning = .6f;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 150:
				asteroidSpeed = 7;
				repeatSpawning = 1.2f;

				newPlayerSpeed = 40;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 160:
				asteroidSpeed = 6.5f;
				repeatSpawning = .8f;

				newPlayerSpeed = 45;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;

			case 170:
				asteroidSpeed = 6.5f;
				repeatSpawning = 0.6f;

				newPlayerSpeed = 50;
				gm.GetComponent<GameManager>().newPlayerSpeed(newPlayerSpeed);

				adjustedVariableInfo();
				break;


			default:
				Debug.Log("spawning variable didn't change");
				break;

		}

	}

	void adjustedVariableInfo()
	{
		Debug.Log("Case:" + playerScore + ".");
		Debug.Log("Asteroid Speed is now: " + asteroidSpeed);
		Debug.Log("Repeat Spawning every " + repeatSpawning + " seconds.");
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


	/*Randomise instantiate positions
	 * Use switches to check score, if higher then eg.50 lower repeatSpawning timer.
	 * Gradually get faster spawning overtime, to increase difficulty.
	 * 
	 * Also need pickups, eg. slow asteroids/slow spawning, provide 2nd space on opposite side of original,
	 * attach laser/gun to space station allows shooting of asteroids.
	 * Ability to upgrade pickups in the store, so pickups last longer.(this will assist players getting higher scores)
	 * Pickups will be activated by floating past on the screen, the player will tap them to activate them.
	 * 
	 * 
	 */
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
	public void startSpawner()
	{
		adjustVariables();
		initialSpawn();
		StartCoroutine(SpawnTimer());
	}

	IEnumerator SpawnTimer()
	{
		
		yield return new WaitForSeconds(repeatSpawning);
		respawnBall();
		isPickupSpawnable();
		StartCoroutine(SpawnTimer());
	}

	public void stopSpawner()
	{
		StopCoroutine(SpawnTimer());
	}



	//Function to check if pickup is able to spawn, 
	//which pickup and the percentage chance of it spawning.

	public void isPickupSpawnable()
	{
		float randNum = Random.Range(1, 101);
		//need to call a function here to check if isPickupAllowed
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

	
	public void pickupAllowed()
	{
		isPickupAllowed = true;
	}


}
