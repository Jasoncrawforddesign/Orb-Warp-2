using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CrossFadeMixers : MonoBehaviour
{

	public AudioMixer mixer;
	bool fading;


    public void CrossfadeGroupsForward(float duration)
	{
		if (!fading)
		{
			StartCoroutine(CrossfadeForward(duration));
		}
	}

	IEnumerator CrossfadeForward(float fadeTime)
	{
		fading = true;
		float currentTime = 0;

		while (currentTime <= fadeTime)
		{
			currentTime += Time.deltaTime;

			mixer.SetFloat("volMenuMusic", Mathf.Log10(Mathf.Lerp(.6f, 0.0001f, currentTime / fadeTime)) * 20);
			mixer.SetFloat("vol2", Mathf.Log10(Mathf.Lerp(0.0001f, .6f, currentTime / fadeTime)) * 20);

			yield return null;
		}


	   fading = false;

	}

	public void CrossfadeGroupsRewind(float duration)
	{
		if (!fading)
		{
			StartCoroutine(CrossfadeBack(duration));
		}
	}

	IEnumerator CrossfadeBack(float fadeTime)
	{
		fading = true;
		float currentTime = 0;

		while (currentTime <= fadeTime)
		{
			currentTime += Time.deltaTime;

			mixer.SetFloat("vol2", Mathf.Log10(Mathf.Lerp(1, 0.0001f, currentTime / fadeTime)) * 20);
			mixer.SetFloat("volMenuMusic", Mathf.Log10(Mathf.Lerp(0.0001f, 1, currentTime / fadeTime)) * 20);

			yield return null;
		}


		fading = false;

	}


}
