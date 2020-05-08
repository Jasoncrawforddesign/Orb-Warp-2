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


	public void updateVariables()
	{
		playerScore = gm.currentScore;
		asteroidsDestroyed = gm.asteroidCounter;
		currencyEarned = asteroidsDestroyed + playerScore;

		currentHighScore = gm.highScore;
	}

	public void updateText()
	{
		playerScoreText.text = "Score = " + playerScore.ToString();

		asteroidsDestroyedText.text = "Asteroids Destroyed = " + asteroidsDestroyed.ToString();

		currencyEarnedText.text = "Credit earned = " + currencyEarned.ToString();

		if(playerScore > currentHighScore)
		{
			newHighScoreText.text = "New HighScore " + playerScore.ToString();
		}

		else
		{
			newHighScoreText.text = "Highscore " + currentHighScore.ToString();
		}
		
	}


	//Called after ad/exiting popup/restart game.
	public void addCurrency()
	{
		gm.addCurrency(currencyEarned);
	}

}
