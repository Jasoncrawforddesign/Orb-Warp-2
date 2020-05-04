using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParticle : MonoBehaviour
{
	public ParticleSystem thisParticleSystem;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Asteroid")
		{
			Debug.Log("BOOM");
			thisParticleSystem.Play();
		}
	}
}
