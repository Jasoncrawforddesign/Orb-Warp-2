using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_spawn : MonoBehaviour
{
	public GameObject prefabToSpawn;
	private Vector3 centrePoint = new Vector3(0, 0, 0);

	public GameObject[] spawnPositions;
	private GameObject currentSpawn;
	private int spawnPositionsIndex;

	// Start is called before the first frame update
	void Start()
	{
		spawnPositions = GameObject.FindGameObjectsWithTag("spawnPos");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			spawnTest();
		}
	}

	void spawnTest()
	{
		{
			spawnPositionsIndex = Random.Range(0, spawnPositions.Length);
			currentSpawn = spawnPositions[spawnPositionsIndex];
			
			GameObject clonePrefab1 = Instantiate(prefabToSpawn, currentSpawn.transform.position, Quaternion.identity) as GameObject;
			clonePrefab1.name = "Asteroid";
			Destroy(clonePrefab1, 10);


		}
	}
}
