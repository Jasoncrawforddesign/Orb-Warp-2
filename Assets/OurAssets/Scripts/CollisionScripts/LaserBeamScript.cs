using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamScript : MonoBehaviour
{
	public ParticleSystem asteroidParticlePrefab;
	public GameObject playerPaddle;

	public LayerMask rayCastLayers;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//laserBeamRayCast01();
		//laserBeamRayCast02();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Asteroid")
		{
			ParticleSystem asteroidBoom = Instantiate(asteroidParticlePrefab, collision.transform.position, collision.transform.rotation) as ParticleSystem;
			asteroidBoom.name = "particle";
			asteroidBoom.Play();
			Destroy(asteroidBoom.gameObject, 2);
			collision.gameObject.GetComponent<Basic_Asteroid_Function>().hitByLaser();
		}
	}

	void laserBeamRayCast01()
	{
		RaycastHit2D hit = Physics2D.Raycast(playerPaddle.transform.position, playerPaddle.transform.up * 5, rayCastLayers);
		Debug.DrawRay(playerPaddle.transform.position, playerPaddle.transform.up * 5, Color.green);

		if (hit.collider.gameObject.tag == "Asteroid")
		{
			ParticleSystem asteroidBoom = Instantiate(asteroidParticlePrefab, hit.transform.position, hit.transform.rotation) as ParticleSystem;
			asteroidBoom.name = "particle";
			asteroidBoom.Play();
			Destroy(asteroidBoom.gameObject, 2);
			hit.collider.gameObject.GetComponent<Basic_Asteroid_Function>().hitByLaser();
		}
		else return;
	}

	void laserBeamRayCast02()
	{
		RaycastHit2D hit = Physics2D.Raycast((playerPaddle.transform.position + new Vector3(2,0,0)), playerPaddle.transform.up * 5, rayCastLayers);
		Debug.DrawRay(playerPaddle.transform.position, playerPaddle.transform.up * 5, Color.green);

		if (hit.collider.gameObject.tag == "Asteroid")
		{
			ParticleSystem asteroidBoom = Instantiate(asteroidParticlePrefab, hit.transform.position, hit.transform.rotation) as ParticleSystem;
			asteroidBoom.name = "particle";
			asteroidBoom.Play();
			Destroy(asteroidBoom.gameObject, 2);
			hit.collider.gameObject.GetComponent<Basic_Asteroid_Function>().hitByLaser();
		}
		else return;
	}
}
