using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{

	private int isMuteOn = 1;
	private int muteOn = 1;

	public GameObject muteOnImage;
	public GameObject muteOffImage;
	public AudioManager am;


	private int isControlGuiOn = 1;
	private int controlGuiOn = 1;

	public GameObject controlGuiON;
	public GameObject controlGuiOFF;
	public GameObject controlsGUIPanel;


    // Start is called before the first frame update
    void Start()
    {

	}

	public void checkSettings()
	{
		if (PlayerPrefs.HasKey("isMuteOn"))
		{
			isMuteOn = PlayerPrefs.GetInt("isMuteOn");
		}
		else
		{
			isMuteOn = 1;
		}

		if (PlayerPrefs.HasKey("isControlGuiOn"))
		{
			isControlGuiOn = PlayerPrefs.GetInt("isControlGuiOn");
		}
		else
		{
			isControlGuiOn = 1;
		}
		muteCheck();
		controlGuiCheck();
	}

	#region MuteCheck
	void muteCheck()
	{
		if (isMuteOn == 1)
		{
			muteOnImage.SetActive(true);
			muteOffImage.SetActive(false);
			am.unMuteVol();
			Debug.Log("Vol on");

		}

		else if (isMuteOn == 0)
		{
			muteOnImage.SetActive(false);
			muteOffImage.SetActive(true);
			am.muteVol();
			Debug.Log("Vol off");

		}
	}

	public void muteDisable()
	{
		muteOn = 0;
		PlayerPrefs.SetInt("isMuteOn", muteOn);
		Debug.Log(muteOn);
	}

	public void muteEnabled()
	{
		muteOn = 1;
		PlayerPrefs.SetInt("isMuteOn", muteOn);
	}
	#endregion

	#region control GUI Check
	void controlGuiCheck()
	{
		if (isControlGuiOn == 1)
		{
			controlGuiON.SetActive(true);
			controlGuiOFF.SetActive(false);
			controlsGUIPanel.SetActive(true);
			Debug.Log("Control Gui On");
		}

		else if (isControlGuiOn == 0)
		{
			controlGuiON.SetActive(false);
			controlGuiOFF.SetActive(true);
			controlsGUIPanel.SetActive(false);
			Debug.Log("Control Gui Off");
		}
	}

	public void controlGuiDisable()
	{
		controlGuiOn = 0;
		PlayerPrefs.SetInt("isControlGuiOn", controlGuiOn);
	}

	public void controlGuiEnabled()
	{
		controlGuiOn = 1;
		PlayerPrefs.SetInt("isControlGuiOn", controlGuiOn);
	}

	#endregion
}
