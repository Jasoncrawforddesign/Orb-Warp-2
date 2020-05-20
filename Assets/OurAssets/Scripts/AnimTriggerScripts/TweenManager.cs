using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
	public GameObject MainMenu;

	public GameObject shopPanel;

	public GameObject endResultPanel;

	public GameObject gameComponents;

	public GameObject controlsUI;

	public GameObject gUI;

    public void playGameComponentAnim(bool play)
	{
		if(play == true)
		{
			gameComponents.GetComponent<DOTweenAnimation>().DOPlayForward();
		}
		else
		{
			gameComponents.GetComponent<DOTweenAnimation>().DOPlayBackwards();
		}	
	}

	public void playEndResultPanel(bool play)
	{
		if (play == true)
		{
			endResultPanel.GetComponent<DOTweenAnimation>().DOPlayForward();
		}
		else
		{
			endResultPanel.GetComponent<DOTweenAnimation>().DOPlayBackwards();
		}
	}

	public void playShopPanelAnim(bool play)
	{
		if (play == true)
		{
			shopPanel.GetComponent<DOTweenAnimation>().DOPlayForward();
		}
		else
		{
			shopPanel.GetComponent<DOTweenAnimation>().DOPlayBackwards();
		}
	}

	public void playMainMenuAnim(bool play)
	{
		if (play == true)
		{
			MainMenu.GetComponent<DOTweenAnimation>().DOPlayForward();
		}
		else
		{
			MainMenu.GetComponent<DOTweenAnimation>().DOPlayBackwards();
		}
	}


	public void playControlUIAnim(bool play)
	{
		if(play == true)
		{
			controlsUI.GetComponent<DOTweenAnimation>().DOPlayForward();
		}
		else
		{
			controlsUI.GetComponent<DOTweenAnimation>().DORewind();
		}

	}

	public void playGUIAnim(bool play)
	{
		if (play == true)
		{
			gUI.GetComponent<DOTweenAnimation>().DOPlayForward();
		}
		else
		{
			gUI.GetComponent<DOTweenAnimation>().DORewind();
		}
	}


}
