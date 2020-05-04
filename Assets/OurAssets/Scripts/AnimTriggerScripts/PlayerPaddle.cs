using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Asteroid")
		{
			this.gameObject.GetComponent<DOTweenAnimation>().DOPlay();
			this.gameObject.GetComponent<DOTweenAnimation>().DORestart();
		}
	}
}
