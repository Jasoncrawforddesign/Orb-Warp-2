﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
	string googlePlayID = "3591480";
	bool testMode = true;

	private int runsCompleted;
    // Start is called before the first frame update
    void Start()
    {
		Advertisement.Initialize(googlePlayID, testMode);
		//Debug.Log(Advertisement.isInitialized);
		//Debug.Log(Advertisement.IsReady());
    }

	public void DisplayAd()
	{
		if (!Advertisement.IsReady("video"))
		{
			//Debug.Log("Ads ready for default placement");
			return;
		} else if (Advertisement.IsReady("video"))
		{
			Advertisement.Show("video");
		}
		//Debug.Log(Advertisement.isShowing);
	
	}

	private void OnApplicationFocus(bool focus)
	{
		if(focus == true)
		{
			Advertisement.Initialize(googlePlayID, testMode);
			Debug.Log("focus test");
		}
	}

	//public void addRunComplete()
	//{
	//	runsCompleted += 1;
	//}

	//public void ForcedAd()
	//{
	//	if(runsCompleted = 5)
	//	{

	//	}
	//}
}
