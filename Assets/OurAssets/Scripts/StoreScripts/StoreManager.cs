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
		//checkStoreInformation();

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void checkStoreInformation()
	{
		speedCurrentLevel = gm.speedLevel;
		speedItemLevelText.text = speedCurrentLevel.ToString();
		upgradeSpeed();

		invincibilityCurrentLevel = gm.invincibilityLevel;
		invincibilityItemLevelText.text = invincibilityCurrentLevel.ToString();
		upgradeInvicibility();

		doubleCurrentLevel = gm.doublePointsLevel;
		doubleItemLevelText.text = doubleCurrentLevel.ToString();
		upgradeDoublePoints();

		laserCurrentLevel = gm.laserbeamLevel;
		laserItemLevelText.text = laserCurrentLevel.ToString();
		upgradeLaserBeam();

		extraPaddleLevel = gm.extraPaddleLevel;
		extraPaddleLevelText.text = extraPaddleLevel.ToString();
		upgradeExtraPaddle();

	}

	public void purchaseSpeedUpgrade()
	{
		if ((gm.playerCurrency >= currentSpeedUpgradeCost) && (speedCurrentLevel < 5))
		{
			gm.lessCurrency(currentSpeedUpgradeCost);
			speedCurrentLevel += 1;
			speedItemLevelText.text = speedCurrentLevel.ToString();
			gm.rotationSpeedTimer += 1.2f;
			upgradeSpeed();
			SaveItemLevels();
		}

		else if ((gm.playerCurrency < currentSpeedUpgradeCost) && (speedCurrentLevel < 5))
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
				speedUpgradeCostText.text = currentSpeedUpgradeCost.ToString();
					break;

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



	public void purchaseInvincibilityUpgrade()
	{
		if ((gm.playerCurrency >= currentInvincibilityUpgradeCost) && (invincibilityCurrentLevel < 5))
		{
			gm.lessCurrency(currentInvincibilityUpgradeCost);
			invincibilityCurrentLevel += 1;
			invincibilityItemLevelText.text = invincibilityCurrentLevel.ToString();
			gm.shieldObjTimer += 1.2f;
			upgradeInvicibility();
			SaveItemLevels();
		}

		else if ((gm.playerCurrency < currentInvincibilityUpgradeCost) && (invincibilityCurrentLevel < 5))
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
				invincibilityUpgradeCostText.text = currentInvincibilityUpgradeCost.ToString();
					break;

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


	public void purchaseDoublePointsUpgrade()
	{
		if ((gm.playerCurrency >= currentDoubleUpgradeCost) && (doubleCurrentLevel < 5))
		{
			gm.lessCurrency(currentDoubleUpgradeCost);
			doubleCurrentLevel += 1;
			doubleItemLevelText.text = doubleCurrentLevel.ToString();
			gm.doublePointsTimer += 1.2f;
			upgradeDoublePoints();
			SaveItemLevels();
		}
		else if ((gm.playerCurrency < currentDoubleUpgradeCost) && (doubleCurrentLevel < 5))
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
				doubleUpgradeCostText.text = currentDoubleUpgradeCost.ToString();
				break;

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


	public void purchaseLaserBeamUpgrade()
	{
		if ((gm.playerCurrency >= currentLaserUpgradeCost) && (laserCurrentLevel < 5))
		{
			gm.lessCurrency(currentLaserUpgradeCost);
			laserCurrentLevel += 1;
			laserItemLevelText.text = laserCurrentLevel.ToString();
			gm.laserObjTimer += 1.2f;
			upgradeLaserBeam();
			SaveItemLevels();
		}
		else if ((gm.playerCurrency < currentLaserUpgradeCost) && (laserCurrentLevel < 5))
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
				laserUpgradeCostText.text = currentLaserUpgradeCost.ToString();
				break;

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


	public void purchaseExtraPaddleUpgrade()
	{
		if ((gm.playerCurrency >= currentExtraPaddleUpgradeCost) && (extraPaddleLevel < 5))
		{
			gm.lessCurrency(currentExtraPaddleUpgradeCost);
			extraPaddleLevel += 1;
			extraPaddleLevelText.text = extraPaddleLevel.ToString();
			gm.extraPaddleTimer += 1.2f;
			upgradeExtraPaddle();
			SaveItemLevels();
		}
		else if ((gm.playerCurrency < currentExtraPaddleUpgradeCost) && (extraPaddleLevel < 5))
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
					extraPaddleUpgradeCostText.text = currentExtraPaddleUpgradeCost.ToString();
					break;
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




	public void SaveItemLevels()
	{
		gm.speedLevel = speedCurrentLevel;
		gm.invincibilityLevel = invincibilityCurrentLevel;
		gm.doublePointsLevel = doubleCurrentLevel;
		gm.laserbeamLevel = laserCurrentLevel;
		gm.extraPaddleLevel = extraPaddleLevel;

		gm.SaveGame();
	}
}
