using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

	public GameManager gm;

	[Header("Speed Powerup")]
	public TextMeshProUGUI speedItemLevelText;
	private int speedCurrentLevel;
	public TextMeshProUGUI speedUpgradeCostText;
	public int speedUpgradeCost01;
	public int speedUpgradeCost02;
	public int speedUpgradeCost03;
	public int speedUpgradeCost04;
	public int speedUpgradeCost05;
	public int speedUpgradeCost06;
	public int speedUpgradeCost07;
	public int speedUpgradeCost08;
	public int speedUpgradeCost09;
	public int speedUpgradeCost10;
	private int currentSpeedUpgradeCost;

	[Header("Invincibility Powerup")]
	public TextMeshProUGUI invincibilityItemLevelText;
	private int invincibilityCurrentLevel;
	public TextMeshProUGUI invincibilityUpgradeCostText;
	public int invincibilityUpgradeCost01;
	public int invincibilityUpgradeCost02;
	public int invincibilityUpgradeCost03;
	public int invincibilityUpgradeCost04;
	public int invincibilityUpgradeCost05;
	public int invincibilityUpgradeCost06;
	public int invincibilityUpgradeCost07;
	public int invincibilityUpgradeCost08;
	public int invincibilityUpgradeCost09;
	public int invincibilityUpgradeCost10;
	private int currentInvincibilityUpgradeCost;

	[Header("Double Points Powerup")]
	public TextMeshProUGUI doubleItemLevelText;
	private int doubleCurrentLevel;
	public TextMeshProUGUI doubleUpgradeCostText;
	public int doubleUpgradeCost01;
	public int doubleUpgradeCost02;
	public int doubleUpgradeCost03;
	public int doubleUpgradeCost04;
	public int doubleUpgradeCost05;
	public int doubleUpgradeCost06;
	public int doubleUpgradeCost07;
	public int doubleUpgradeCost08;
	public int doubleUpgradeCost09;
	public int doubleUpgradeCost10;
	private int currentDoubleUpgradeCost;

	[Header("Laser Beam Powerup")]
	public TextMeshProUGUI laserItemLevelText;
	private int laserCurrentLevel;
	public TextMeshProUGUI laserUpgradeCostText;
	public int laserUpgradeCost01;
	public int laserUpgradeCost02;
	public int laserUpgradeCost03;
	public int laserUpgradeCost04;
	public int laserUpgradeCost05;
	public int laserUpgradeCost06;
	public int laserUpgradeCost07;
	public int laserUpgradeCost08;
	public int laserUpgradeCost09;
	public int laserUpgradeCost10;
	private int currentLaserUpgradeCost;

	[Header("Extra Paddle Powerup")]
	public TextMeshProUGUI extraPaddleLevelText;
	private int extraPaddleLevel;
	public TextMeshProUGUI extraPaddleUpgradeCostText;
	public int extraPaddleUpgradeCost01;
	public int extraPaddleUpgradeCost02;
	public int extraPaddleUpgradeCost03;
	public int extraPaddleUpgradeCost04;
	public int extraPaddleUpgradeCost05;
	public int extraPaddleUpgradeCost06;
	public int extraPaddleUpgradeCost07;
	public int extraPaddleUpgradeCost08;
	public int extraPaddleUpgradeCost09;
	public int extraPaddleUpgradeCost10;
	private int currentExtraPaddleUpgradeCost;

	private bool wasVidWatched;
	public TextMeshProUGUI videoInsentiveText;
	public GameObject vidButton;
	public GameObject adVidFrame;
	private int rewardAmount;

	// Start is called before the first frame update
	void Start()
    {
		//put into this function (need to check players saved game to see what level the upgrades are at, and what price is needed)
		//checkStoreInformation();

	}

	public void checkStoreInformation()
	{
		speedCurrentLevel = gm.speedLevel;
		speedItemLevelText.text = "Lvl. " + speedCurrentLevel + "/10".ToString();
		upgradeSpeed();

		invincibilityCurrentLevel = gm.invincibilityLevel;
		invincibilityItemLevelText.text = "Lvl. " + invincibilityCurrentLevel + "/10".ToString();
		upgradeInvicibility();

		doubleCurrentLevel = gm.doublePointsLevel;
		doubleItemLevelText.text = "Lvl. " + doubleCurrentLevel + "/10".ToString();
		upgradeDoublePoints();

		laserCurrentLevel = gm.laserbeamLevel;
		laserItemLevelText.text = "Lvl. " + laserCurrentLevel + "/10".ToString();
		upgradeLaserBeam();

		extraPaddleLevel = gm.extraPaddleLevel;
		extraPaddleLevelText.text = "Lvl. " + extraPaddleLevel + "/10".ToString();
		upgradeExtraPaddle();

	}

	public void purchaseSpeedUpgrade()
	{
		if ((gm.playerCurrency >= currentSpeedUpgradeCost) && (speedCurrentLevel < 10))
		{
			gm.lessCurrency(currentSpeedUpgradeCost);
			speedCurrentLevel += 1;
			speedItemLevelText.text = "Lvl. " + speedCurrentLevel + "/10".ToString();
			gm.rotationSpeedTimer += 1.5f;
			upgradeSpeed();
			SaveItemLevels();
		}

		else if ((gm.playerCurrency < currentSpeedUpgradeCost) && (speedCurrentLevel < 10))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}
	}
	void upgradeSpeed()
	{
		
			switch (speedCurrentLevel)
			{
				case 0:
				currentSpeedUpgradeCost = speedUpgradeCost01;
				speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 1:
					currentSpeedUpgradeCost = speedUpgradeCost02;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 2:
					currentSpeedUpgradeCost = speedUpgradeCost03;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 3:
					currentSpeedUpgradeCost = speedUpgradeCost04;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 4:
					currentSpeedUpgradeCost = speedUpgradeCost05;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 5:
					currentSpeedUpgradeCost = speedUpgradeCost06;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 6:
					currentSpeedUpgradeCost = speedUpgradeCost07;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 7:
					currentSpeedUpgradeCost = speedUpgradeCost08;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 8:
					currentSpeedUpgradeCost = speedUpgradeCost09;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 9:
					currentSpeedUpgradeCost = speedUpgradeCost10;
					speedUpgradeCostText.text = "<sprite index= 0> " + currentSpeedUpgradeCost.ToString();
					break;

				case 10:
					speedUpgradeCostText.text = "Complete";
					break;

			}

		
	}



	public void purchaseInvincibilityUpgrade()
	{
		if ((gm.playerCurrency >= currentInvincibilityUpgradeCost) && (invincibilityCurrentLevel < 10))
		{
			gm.lessCurrency(currentInvincibilityUpgradeCost);
			invincibilityCurrentLevel += 1;
			invincibilityItemLevelText.text = "Lvl. " + invincibilityCurrentLevel + "/10".ToString();
			gm.shieldObjTimer += 1.5f;
			upgradeInvicibility();
			SaveItemLevels();
		}

		else if ((gm.playerCurrency < currentInvincibilityUpgradeCost) && (invincibilityCurrentLevel < 10))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}

	}
	void upgradeInvicibility()
	{
			switch (invincibilityCurrentLevel)
			{
				case 0:
				currentInvincibilityUpgradeCost = invincibilityUpgradeCost01;
				invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 1:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost02;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 2:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost03;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 3:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost04;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 4:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost05;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 5:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost06;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;


				case 6:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost07;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 7:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost08;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 8:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost09;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 9:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost10;
					invincibilityUpgradeCostText.text = "<sprite index= 0> " + currentInvincibilityUpgradeCost.ToString();
					break;

				case 10:
					invincibilityUpgradeCostText.text = "Complete";
					break;

		}

	}


	public void purchaseDoublePointsUpgrade()
	{
		if ((gm.playerCurrency >= currentDoubleUpgradeCost) && (doubleCurrentLevel < 10))
		{
			gm.lessCurrency(currentDoubleUpgradeCost);
			doubleCurrentLevel += 1;
			doubleItemLevelText.text = "Lvl. " + doubleCurrentLevel + "/10".ToString();
			gm.doublePointsTimer += 1.5f;
			upgradeDoublePoints();
			SaveItemLevels();
		}
		else if ((gm.playerCurrency < currentDoubleUpgradeCost) && (doubleCurrentLevel < 10))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}
	}
	void upgradeDoublePoints()
	{
			switch (doubleCurrentLevel)
		{

			case 0:
				currentDoubleUpgradeCost = doubleUpgradeCost01;
				doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
				break;

			case 1:
					currentDoubleUpgradeCost = doubleUpgradeCost02;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 2:
					currentDoubleUpgradeCost = doubleUpgradeCost03;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 3:
					currentDoubleUpgradeCost = doubleUpgradeCost04;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 4:
					currentDoubleUpgradeCost = doubleUpgradeCost05;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 5:
					currentDoubleUpgradeCost = doubleUpgradeCost06;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 6:
					currentDoubleUpgradeCost = doubleUpgradeCost07;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 7:
					currentDoubleUpgradeCost = doubleUpgradeCost08;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 8:
					currentDoubleUpgradeCost = doubleUpgradeCost09;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 9:
					currentDoubleUpgradeCost = doubleUpgradeCost10;
					doubleUpgradeCostText.text = "<sprite index= 0> " + currentDoubleUpgradeCost.ToString();
					break;

				case 10:
						doubleUpgradeCostText.text = "Complete";
						break;
		}

	}


	public void purchaseLaserBeamUpgrade()
	{
		if ((gm.playerCurrency >= currentLaserUpgradeCost) && (laserCurrentLevel < 10))
		{
			gm.lessCurrency(currentLaserUpgradeCost);
			laserCurrentLevel += 1;
			laserItemLevelText.text = "Lvl. " + laserCurrentLevel + "/10".ToString();
			gm.laserObjTimer += 1.5f;
			upgradeLaserBeam();
			SaveItemLevels();
		}
		else if ((gm.playerCurrency < currentLaserUpgradeCost) && (laserCurrentLevel < 10))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}
	}
	void upgradeLaserBeam()
	{

		switch (laserCurrentLevel)
			{
				case 0:
					currentLaserUpgradeCost = laserUpgradeCost01;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 1:
					currentLaserUpgradeCost = laserUpgradeCost02;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 2:
					currentLaserUpgradeCost = laserUpgradeCost03;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 3:
					currentLaserUpgradeCost = laserUpgradeCost04;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 4:
					currentLaserUpgradeCost = laserUpgradeCost05;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 5:
					currentLaserUpgradeCost = laserUpgradeCost06;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 6:
					currentLaserUpgradeCost = laserUpgradeCost07;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 7:
					currentLaserUpgradeCost = laserUpgradeCost08;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 8:
					currentLaserUpgradeCost = laserUpgradeCost09;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 9:
					currentLaserUpgradeCost = laserUpgradeCost10;
					laserUpgradeCostText.text = "<sprite index= 0> " + currentLaserUpgradeCost.ToString();
					break;

				case 10:
						laserUpgradeCostText.text = "Complete";
						break;
			}

	}


	public void purchaseExtraPaddleUpgrade()
	{
		if ((gm.playerCurrency >= currentExtraPaddleUpgradeCost) && (extraPaddleLevel < 10))
		{
			gm.lessCurrency(currentExtraPaddleUpgradeCost);
			extraPaddleLevel += 1;
			extraPaddleLevelText.text = "Lvl. " + extraPaddleLevel + "/10".ToString();
			gm.extraPaddleTimer += 1.5f;
			upgradeExtraPaddle();
			SaveItemLevels();
		}
		else if ((gm.playerCurrency < currentExtraPaddleUpgradeCost) && (extraPaddleLevel < 10))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}
	}
	public void upgradeExtraPaddle()
	{

		switch (extraPaddleLevel)
			{
				case 0:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost01;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;
				case 1:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost02;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;

				case 2:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost03;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;

				case 3:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost04;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;

				case 4:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost05;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;


				case 5:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost06;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;


				case 6:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost07;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;

				case 7:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost08;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;

				case 8:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost09;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;

				case 9:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost10;
					extraPaddleUpgradeCostText.text = "<sprite index= 0> " + currentExtraPaddleUpgradeCost.ToString();
					break;


				case 10:
						extraPaddleUpgradeCostText.text = "Complete";
						break;
			}


	}




	public void SaveItemLevels()
	{
		gm.speedLevel = speedCurrentLevel;
		gm.invincibilityLevel = invincibilityCurrentLevel;
		gm.doublePointsLevel = doubleCurrentLevel;
		gm.laserbeamLevel = laserCurrentLevel;
		gm.extraPaddleLevel = extraPaddleLevel;

		gm.SaveGame();
	}


	public void rewardedVideo()
	{
		wasVidWatched = true;
		addCurrency();
		videoInsentiveText.text = "<sprite index= 0> " + rewardAmount + " is now yours!";
		vidButton.SetActive(false);
	}

	public void addCurrency()
	{
		if (wasVidWatched == true)
		{
			gm.addCurrency(rewardAmount);
			wasVidWatched = false;
		}
	}

	public void updateAdText()
	{
		if(gm.playerCurrency < 2000)
		{
			int tempInt = Mathf.RoundToInt(gm.playerCurrency / 4);
			rewardAmount = Mathf.RoundToInt(tempInt * 1.5f);
			if (rewardAmount > 500)
			{
				rewardAmount = 500;
			}
		}

		else if (gm.playerCurrency > 2000 && gm.playerCurrency < 4000)
		{
			int tempInt = Mathf.RoundToInt(gm.playerCurrency / 6);
			rewardAmount = Mathf.RoundToInt(tempInt * 1.25f);
			if(rewardAmount > 500)
			{
				rewardAmount = 500;
			}
		}

		else if (gm.playerCurrency > 4000)
		{
			int tempInt = Mathf.RoundToInt(gm.playerCurrency / 8);
			rewardAmount = Mathf.RoundToInt(tempInt);
			if (rewardAmount > 500)
			{
				rewardAmount = 500;
			}
		}

		videoInsentiveText.text = "Watch the sponsored video below for an extra  <sprite index= 0> " + rewardAmount;
	
	}

	public void turnOnAd()
	{
		adVidFrame.SetActive(true);
		vidButton.SetActive(true);
	}

	public void turnOffAd()
	{
		if(wasVidWatched == false)
		{
			adVidFrame.SetActive(false);
		}
	}
}
