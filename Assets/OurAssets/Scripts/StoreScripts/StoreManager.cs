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
	private int currentExtraPaddleUpgradeCost;

	// Start is called before the first frame update
	void Start()
    {
		//put into this function (need to check players saved game to see what level the upgrades are at, and what price is needed)
		checkStoreInformation();

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void checkStoreInformation()
	{
		speedCurrentLevel = 0;
		speedItemLevelText.text = speedCurrentLevel.ToString();
		currentSpeedUpgradeCost = speedUpgradeCost01;
		speedUpgradeCostText.text = currentSpeedUpgradeCost.ToString();

		invincibilityCurrentLevel = 0;
		invincibilityItemLevelText.text = invincibilityCurrentLevel.ToString();
		currentInvincibilityUpgradeCost = invincibilityUpgradeCost01;
		invincibilityUpgradeCostText.text = currentInvincibilityUpgradeCost.ToString();

		doubleCurrentLevel = 0;
		doubleItemLevelText.text = doubleCurrentLevel.ToString();
		currentDoubleUpgradeCost = doubleUpgradeCost01;
		doubleUpgradeCostText.text = currentDoubleUpgradeCost.ToString();

		laserCurrentLevel = 0;
		laserItemLevelText.text = laserCurrentLevel.ToString();
		currentLaserUpgradeCost = laserUpgradeCost01;
		laserUpgradeCostText.text = currentLaserUpgradeCost.ToString();

		extraPaddleLevel = 0;
		extraPaddleLevelText.text = extraPaddleLevel.ToString();
		currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost01;
		extraPaddleUpgradeCostText.text = currentExtraPaddleUpgradeCost.ToString();

	}

	public void upgradeSpeed()
	{
		if((gm.playerCurrency > currentSpeedUpgradeCost)&&(speedCurrentLevel < 5))
		{
			gm.lessCurrency(currentSpeedUpgradeCost);
			speedCurrentLevel += 1;
			speedItemLevelText.text = speedCurrentLevel.ToString();
			gm.rotationSpeedTimer += 1.2f;
			switch (speedCurrentLevel)
			{

				case 1:
					currentSpeedUpgradeCost = speedUpgradeCost02;
					speedUpgradeCostText.text = currentSpeedUpgradeCost.ToString();
					break;

				case 2:
					currentSpeedUpgradeCost = speedUpgradeCost03;
					speedUpgradeCostText.text = currentSpeedUpgradeCost.ToString();
					break;

				case 3:
					currentSpeedUpgradeCost = speedUpgradeCost04;
					speedUpgradeCostText.text = currentSpeedUpgradeCost.ToString();
					break;

				case 4:
					currentSpeedUpgradeCost = speedUpgradeCost05;
					speedUpgradeCostText.text = currentSpeedUpgradeCost.ToString();
					break;
				case 5:
					speedUpgradeCostText.text = "Complete";
					break;

			}
		}

		else if((gm.playerCurrency < currentSpeedUpgradeCost)&&(speedCurrentLevel < 5))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}

		
	}

	public void upgradeInvicibility()
	{
		if ((gm.playerCurrency > currentInvincibilityUpgradeCost) && (invincibilityCurrentLevel < 5))
		{
			gm.lessCurrency(currentInvincibilityUpgradeCost);
			invincibilityCurrentLevel += 1;
			invincibilityItemLevelText.text = invincibilityCurrentLevel.ToString();
			gm.shieldObjTimer += 1.2f;
			switch (invincibilityCurrentLevel)
			{
				case 1:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost02;
					invincibilityUpgradeCostText.text = currentInvincibilityUpgradeCost.ToString();
					break;

				case 2:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost03;
					invincibilityUpgradeCostText.text = currentInvincibilityUpgradeCost.ToString();
					break;

				case 3:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost04;
					invincibilityUpgradeCostText.text = currentInvincibilityUpgradeCost.ToString();
					break;

				case 4:
					currentInvincibilityUpgradeCost = invincibilityUpgradeCost05;
					invincibilityUpgradeCostText.text = currentInvincibilityUpgradeCost.ToString();
					break;
				case 5:
					invincibilityUpgradeCostText.text = "Complete";
					break;
			}
		}

		else if ((gm.playerCurrency < currentInvincibilityUpgradeCost) && (invincibilityCurrentLevel < 5))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}


	}

	public void upgradeDoublePoints()
	{
		if ((gm.playerCurrency > currentDoubleUpgradeCost) && (doubleCurrentLevel< 5))
		{
			gm.lessCurrency(currentDoubleUpgradeCost);
			doubleCurrentLevel += 1;
			doubleItemLevelText.text = doubleCurrentLevel.ToString();
			gm.doublePointsTimer += 1.2f;
			switch (doubleCurrentLevel)
			{
				case 1:
					currentDoubleUpgradeCost = doubleUpgradeCost02;
					doubleUpgradeCostText.text = currentDoubleUpgradeCost.ToString();
					break;

				case 2:
					currentDoubleUpgradeCost = doubleUpgradeCost03;
					doubleUpgradeCostText.text = currentDoubleUpgradeCost.ToString();
					break;

				case 3:
					currentDoubleUpgradeCost = doubleUpgradeCost04;
					doubleUpgradeCostText.text = currentDoubleUpgradeCost.ToString();
					break;

				case 4:
					currentDoubleUpgradeCost = doubleUpgradeCost05;
					doubleUpgradeCostText.text = currentDoubleUpgradeCost.ToString();
					break;
				case 5:
					doubleUpgradeCostText.text = "Complete";
					break;
			}
		}

		else if ((gm.playerCurrency< currentDoubleUpgradeCost) && (doubleCurrentLevel < 5))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}


	}

	public void upgradeLaserBeam()
	{
		if ((gm.playerCurrency > currentLaserUpgradeCost) && (laserCurrentLevel< 5))
		{
			gm.lessCurrency(currentLaserUpgradeCost);
			laserCurrentLevel += 1;
			laserItemLevelText.text = laserCurrentLevel.ToString();
			gm.laserObjTimer += 1.2f;
			switch (laserCurrentLevel)
			{
				case 1:
					currentLaserUpgradeCost = laserUpgradeCost02;
					laserUpgradeCostText.text = currentLaserUpgradeCost.ToString();
					break;

				case 2:
					currentLaserUpgradeCost = laserUpgradeCost03;
					laserUpgradeCostText.text = currentLaserUpgradeCost.ToString();
					break;

				case 3:
					currentLaserUpgradeCost = laserUpgradeCost04;
					laserUpgradeCostText.text = currentLaserUpgradeCost.ToString();
					break;

				case 4:
					currentLaserUpgradeCost = laserUpgradeCost05;
					laserUpgradeCostText.text = currentLaserUpgradeCost.ToString();
					break;
				case 5:
					laserUpgradeCostText.text = "Complete";
					break;
			}
		}

		else if ((gm.playerCurrency<currentLaserUpgradeCost) && (laserCurrentLevel< 5))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}


	}

	public void upgradeExtraPaddle()
	{
		if ((gm.playerCurrency > currentExtraPaddleUpgradeCost) && (extraPaddleLevel< 5))
		{
			gm.lessCurrency(currentExtraPaddleUpgradeCost);
			extraPaddleLevel += 1;
			extraPaddleLevelText.text = extraPaddleLevel.ToString();
			gm.extraPaddleTimer += 1.2f;
			switch (extraPaddleLevel)
			{
				case 1:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost02;
					extraPaddleUpgradeCostText.text = currentExtraPaddleUpgradeCost.ToString();
					break;

				case 2:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost03;
					extraPaddleUpgradeCostText.text = currentExtraPaddleUpgradeCost.ToString();
					break;

				case 3:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost04;
					extraPaddleUpgradeCostText.text = currentExtraPaddleUpgradeCost.ToString();
					break;

				case 4:
					currentExtraPaddleUpgradeCost = extraPaddleUpgradeCost05;
					extraPaddleUpgradeCostText.text = currentExtraPaddleUpgradeCost.ToString();
					break;
				case 5:
					extraPaddleUpgradeCostText.text = "Complete";
					break;
			}
		}

		else if ((gm.playerCurrency< currentExtraPaddleUpgradeCost) && (extraPaddleLevel < 5))
		{
			//cannot buy upgrade, dialogue pop up.
			Debug.Log("can't buy upgrade");
		}
		

	}

}
