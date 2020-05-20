using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Upgrade_Info : MonoBehaviour
{
	public PowerUpInformation info;

	public TextMeshProUGUI powerUpNameSlot;
	//public TextMeshProUGUI itemDescription;
	public Image imageArtwork;
    // Start is called before the first frame update
    void Start()
    {
		powerUpNameSlot.text = info.powerUpName;
		//itemDescription.text = info.description;

		imageArtwork.sprite = info.artwork;

	}


}
