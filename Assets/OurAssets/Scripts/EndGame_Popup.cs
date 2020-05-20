using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame_Popup : MonoBehaviour
{
	public GameManager gm;

	public int playerScore;
	public TextMeshProUGUI playerScoreText;

	public int asteroidsDestroyed;
	public TextMeshProUGUI asteroidsDestroyedText;

	public int currencyEarned;
	public TextMeshProUGUI currencyEarnedText;

	public int currentHighScore;

	public TextMeshProUGUI newHighScoreText;

	private int rewardCurrency;
	private bool wasVidWatched = false;
	public GameObject vidButton;
	public TextMeshProUGUI videoInsentiveText;
	public TextMeshProUGUI endCurrentCurrency;

	public void updateVariables()
	{
		vidButton.SetActive(true);
		playerScore = gm.currentScore;
		asteroidsDestroyed = gm.asteroidCounter;
		currencyEarned = asteroidsDestroyed + playerScore;

		currentHighScore = gm.highScore;

		rewardCurrency = currencyEarned;
	}

	public void updateText()
	{
		playerScoreText.text = playerScore.ToString();

		asteroidsDestroyedText.text = asteroidsDestroyed.ToString();

		currencyEarnedText.text = "<sprite index= 0> " + currencyEarned.ToString();
		endCurrentCurrency.text = "<sprite index= 0> " + (gm.playerCurrency + currencyEarned).ToString();

		gm.addCurrency(currencyEarned);
		//playerScoreText.text = "Score = " + playerScore.ToString();

		//asteroidsDestroyedText.text = "Asteroids Destroyed = " + asteroidsDestroyed.ToString();

		//currencyEarnedText.text = "Credit earned = $" + currencyEarned.ToString();

		if (playerScore > currentHighScore)
		{
			newHighScoreText.text = "New HighScore " + playerScore.ToString();
		}

		else
		{
			newHighScoreText.text = "Highscore " + currentHighScore.ToString();
		}

		videoInsentiveText.text = "Watch the sponsored video below for an extra $" + rewardCurrency; 
		
	}


	//Called after ad/exiting popup/restart game.
	public void addCurrency()
	{

		gm.addCurrency(currencyEarned);

	}


	public void videoReward()
	{
		wasVidWatched = true;
		videoInsentiveText.text = "$"+ rewardCurrency + " is now yours!";
		vidButton.SetActive(false);
	}

}
