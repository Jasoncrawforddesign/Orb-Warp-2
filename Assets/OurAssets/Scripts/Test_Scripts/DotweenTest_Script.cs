using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DotweenTest_Script : MonoBehaviour
{

	private DOTweenAnimation thisAnim;
	public ParticleSystem asteroidParticle;
    // Start is called before the first frame update
    void Start()
    {
		thisAnim = this.GetComponent<DOTweenAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//thisAnim.DOPlay();
			//thisAnim.DORestart();

			asteroidParticle.Play();
			
		}
    }
}
