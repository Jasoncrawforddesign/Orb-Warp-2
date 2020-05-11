using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public AdManager adManager;
	public StoreManager storeManager;
	public GameObject endGamePopupObject;
	public TweenManager tweenManager;
	public AudioManager audioManager;

	public ParticleSystem asteroidParticlePrefab;

	public GameObject spawnManager;
	public GameObject playerControl;

	public TextMeshProUGUI scoreText;
	public int currentScore;

	public int highScore;
	public TextMeshProUGUI highScoreText;

	public GameObject gui_Panel;
	public GameObject MainMenu_Panel;
	public GameObject Settings_Panel;
	public GameObject Shop_Panel;

	public int playerCurrency;
	public TextMeshProUGUI currencyText;

	[Header("Pickup Variables Below")]
	public GameObject currentPickupText;
	private Text pickupText;

	//RotationSpeed Pickup variables
	private float holdSpeed;
	private float newSpeed;
	[Header("Rotation Pickup Variables")]
	public float rotationSpeedTimer;
	public float currentSpeed;


	[Header("ExtraPaddle Pickup Variables")]
	//ExtraPaddle Pickup variables
	public GameObject secondPaddle;
	public float extraPaddleTimer;


	[Header("OneUseShield Pickup Variables")]
	//OneUseShield Pickup variables
	public GameObject shieldObject;
	public float shieldObjTimer;

	//DoublePoints Pickup variables
	private bool isDoublePointsActive;
	[Header("DoublePoints Pickup Variables")]
	public float doublePointsTimer;

	[Header("LaserBeam Pickup Variables")]
	//LaserBeam Pickup variables
	public GameObject laserObject;
	public float laserObjTimer;

	public float pickUpCooldownTimer;

	[Header("Animation Variables")]
	//animation clip that fades text in and out.
	public AnimationClip textFadeClip; 
	//used to assign the animator found on the pickUp text gameobject.
	private Animator pickUpAnim;
	//used to assign textFadeClip length to this float, this variable is used for waitForSeconds in the pickup Courountine.
	private float pickUpAnimLength;



	[Header("Regen Shield Variables")]
	public int shieldMax;
	private int currentShieldAmount;
	public GameObject shieldBar1;
	public GameObject shieldBar2;
	public GameObject shieldBar3;
	public GameObject shieldBar4;
	public GameObject shieldBar5;

	public GameObject emptyShieldBar1;
	public GameObject emptyShieldBar2;
	public GameObject emptyShieldBar3;
	public GameObject emptyShieldBar4;
	public GameObject emptyShieldBar5;

	public int asteroidCounter;
	private int tempAsteroidCounter;
	public int asteroidsNeededToMultiply;

	public TextMeshProUGUI scoreMultiplierText;
	public int scoreMultiplier = 1;

	public GameObject test_ring;
	public GameObject cameraMain;

	public int speedLevel;
	public int invincibilityLevel;
	public int doublePointsLevel;
	public int extraPaddleLevel;
	public int laserbeamLevel;

	// Start is called before the first frame update
	void Start()
    {
		//check see if there is a save.
		// it will then LoadPlayer data if a save already exists.
		SaveSystem.InitialSave(this);
		//Assigning Highscores
		highScoreText.text = highScore.ToString();
		currencyText.text = "$" + playerCurrency.ToString();
		MainMenu_Panel.SetActive(true);
		//Loading pickUpText components and assigning private variables.
		pickupText = currentPickupText.GetComponent<Text>();
		pickUpAnim = currentPickupText.GetComponent<Animator>();
		pickUpAnimLength = textFadeClip.length;
		

		currentSpeed = playerControl.GetComponent<PlayerController>().playerSpeed;

		//Loading Main Menu UI
		endRun();
		MainMenu();

		//currentPickupText.text = "";
		spawnManager.SetActive(false);
		pickUpAnim.enabled = false;
		pickUpAllowed();
	}

    // Update is called once per frame
    void Update()
    {
		//laserBeamRayCast();
	}

	#region Add Score Function

	public void addScore()
	{
		if (isDoublePointsActive == true)
		{
			currentScore += 2 * scoreMultiplier;
			scoreText.text = currentScore.ToString();
			spawnManager.GetComponent<SpawnManager>().adjustVariables();
			
		}
		else
		{
			currentScore += 1 * scoreMultiplier;
			scoreText.text = currentScore.ToString();
			spawnManager.GetComponent<SpawnManager>().adjustVariables();
		}

	}
	#endregion

	void destroyAsteroids() //need to call animation to show visual destruction of asteroids, fast growing/exploding circle (orange like the paddle).
	{
		//Destroys all Asteroids left in the game.
		foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
		{

			ParticleSystem asteroidBoom = Instantiate (asteroidParticlePrefab, asteroid.transform.position, asteroid.transform.rotation) as ParticleSystem;
			asteroidBoom.name = "particle";
			asteroidBoom.Play();
			Destroy(asteroidBoom.gameObject, 3);
			Destroy(asteroid);
		}
		test_ring.GetComponent<DOTweenAnimation>().DOPlay();
		test_ring.GetComponent<DOTweenAnimation>().DORestart();


		cameraMain.GetComponent<DOTweenAnimation>().DOPlay();
		cameraMain.GetComponent<DOTweenAnimation>().DORestart();

		pickUpAllowed();

	}
	#region Use this function to load the Main Menu/stop the run.
	public void MainMenu()
	{

		tweenManager.playEndResultPanel(false);
		tweenManager.playGameComponentAnim(false);
		MainMenu_Panel.gameObject.GetComponent<DOTweenAnimation>().DORestart();
		MainMenu_Panel.gameObject.GetComponent<DOTweenAnimation>().DOPlay();
		//Turns on the Main menu, checks currect score against highscore, updating highscore when needed.
		//MainMenu_Panel.SetActive(true);
	}

	void endRun()
	{
		tweenManager.playEndResultPanel(true);
		test_ring.GetComponent<DOTweenAnimation>().DORewind();

		if (currentScore > highScore)
		{
			highScore = currentScore;
			highScoreText.text = "New HighScore: " + highScore.ToString();
			SaveGame();

		}else
		{

			highScoreText.text = "High Score: " + highScore.ToString();
		}
		currentSpeed = playerControl.GetComponent<PlayerController>().playerSpeed;
		//Stops all the neccesary objects.
		spawnManager.GetComponent<SpawnManager>().stopSpawner();
		spawnManager.SetActive(false);
		isDoublePointsActive = false;
		shieldObject.SetActive(false);
		laserObject.SetActive(false);
		secondPaddle.SetActive(false);
		playerControl.GetComponent<PlayerController>().playerSpeed = currentSpeed;
		gui_Panel.SetActive(false);
	}

	#endregion

	#region Use this function to start a run
	public void playGame()
	{

		tweenManager.playEndResultPanel(false);
		MainMenu_Panel.gameObject.GetComponent<DOTweenAnimation>().DOPlayBackwards();
		tweenManager.playGameComponentAnim(true);
		currentScore = 0;
		scoreText.text = currentScore.ToString();
		scoreMultiplierText.text = null;
		asteroidCounter = 0;

		//MainMenu_Panel.SetActive(false);
		playerControl.GetComponent<PlayerController>().resetPlayer();
		gui_Panel.SetActive(true);
		checkShieldMax();
		//pickUpTextAnimation();
		spawnManager.SetActive(true);
		spawnManager.GetComponent<SpawnManager>().startSpawner();
		pickUpTextViewable();
	}
	#endregion

	
	//---------------Currency calculators below--------------------------//
	#region Currency Functions
	public void addCurrency(int cash)
	{
		playerCurrency += cash;
		currencyText.text = "$" + playerCurrency.ToString();
		
	}

	public void lessCurrency(int lessAmount)
	{
		playerCurrency -= lessAmount;
		currencyText.text = "$" + playerCurrency.ToString();
	}


	#endregion

	//------------------------------------------PICK UP FUNCTIONS BELOW------------------------------------------//

	#region Determines what function the pickup needs to run.
	public void pickupType(int typeNum)
	{
		switch (typeNum)
		{
			case 1:
				StartCoroutine(rotationPickup());
				break;

			case 2:
				StartCoroutine(extraPaddlePickup());
				break;

			case 3:
				StartCoroutine(oneUseShieldPickup());
				break;

			case 4:
				StartCoroutine(doublePointsPickup());
				break;

			case 5:
				StartCoroutine(laserBeamPickup());
				break;
		}

	}
	#endregion

	// enables pickups to been spawned.
	public void pickUpAllowed()
	{
		spawnManager.GetComponent<SpawnManager>().pickupAllowed();
	}

	#region Pickup Functions, contains the pickup functions and there timers.
	
	//not entirely sure what this is for.
	IEnumerator pickUpTimer(float timer)
	{
		Debug.Log("Counting");
		//if(less then 2 secs to go, start currency animation);
		yield return new WaitForSeconds(timer);
	}

	//Contains rotation speed pickup timer, also activates and deactivates the extra speed;
	IEnumerator rotationPickup()
	{
		pickupText.text = "Increase Speed";
		currentPickupText.SetActive(true);
		playerControl.GetComponent<PlayerController>().playerSpeed += 5;
		//Debug.Log("rotate Active");
		yield return new WaitForSeconds(rotationSpeedTimer - pickUpAnimLength);

		//Waits another 2 seconds for fading animation and time left of pickup
		pickUpAnim.enabled = true;
		yield return new WaitForSeconds(pickUpAnimLength);
		pickUpAnim.enabled = false;
		pickUpTextViewable();

		//Debug.Log("rotate deactive");
		playerControl.GetComponent<PlayerController>().playerSpeed = currentSpeed;
		pickupText.text = null;
		pickUpSpawnCooldown();
	}

	//Contains extraPaddle pickup timer, also activates and deactivates the extra paddle gameobject.
	IEnumerator extraPaddlePickup()
	{
		pickupText.text = "Extra Paddle";
		currentPickupText.SetActive(true);
		secondPaddle.SetActive(true);
		//Debug.Log("paddle Active");
		yield return new WaitForSeconds(extraPaddleTimer - pickUpAnimLength);

		//Waits another 2 seconds for fading animation and time left of pickup
		pickUpAnim.enabled = true;
		yield return new WaitForSeconds(pickUpAnimLength);
		pickUpAnim.enabled = false;
		pickUpTextViewable();

		//Debug.Log("paddle deactive");
		secondPaddle.SetActive(false);
		pickupText.text = null;
		pickUpSpawnCooldown();
	}

	//Contains invincibility pickup timer, also activates and deactivates the invincibility gameobject.
	IEnumerator oneUseShieldPickup()
	{
		pickupText.text = "invincibility";
		currentPickupText.SetActive(true);
		shieldObject.SetActive(true);
		//Debug.Log("shield Active");
		yield return new WaitForSeconds(shieldObjTimer - pickUpAnimLength);

		//Waits another 2 seconds for fading animation and time left of pickup
		pickUpAnim.enabled = true;
		yield return new WaitForSeconds(pickUpAnimLength);
		pickUpAnim.enabled = false;
		pickUpTextViewable();

		//Debug.Log("shield deactive");
		shieldObject.SetActive(false);
		pickupText.text = null;
		pickUpSpawnCooldown();
	}

	//Contains double points pickup timer, also enables and disables the doublepoints bool.
	IEnumerator doublePointsPickup()
	{
		pickupText.text = "Double Points";
		currentPickupText.SetActive(true);
		isDoublePointsActive = true;
		//Debug.Log("double points Active");
		yield return new WaitForSeconds(doublePointsTimer - pickUpAnimLength);

		//Waits another 2 seconds for fading animation and time left of pickup
		pickUpAnim.enabled = true;
		yield return new WaitForSeconds(pickUpAnimLength);
		pickUpAnim.enabled = false;
		pickUpTextViewable();

		//Debug.Log("double points deactive");
		isDoublePointsActive = false;
		pickupText.text = null;
		pickUpSpawnCooldown();
	}


	//Contains laser beam pickup timer, also activates and deactivates the laserbeam gameobject.
	IEnumerator laserBeamPickup()
	{
		pickupText.text = "Laser Beam";
		currentPickupText.SetActive(true);
		laserObject.SetActive(true);
		//Debug.Log("laser Active");
		yield return new WaitForSeconds(laserObjTimer - pickUpAnimLength);

		//Waits another 2 seconds for fading animation and time left of pickup
		pickUpAnim.enabled = true;
		yield return new WaitForSeconds(pickUpAnimLength);
		pickUpAnim.enabled = false;
		pickUpTextViewable();

		//Debug.Log("laser deactive");
		laserObject.SetActive(false);
		pickupText.text = null;
		pickUpSpawnCooldown();
	}
#endregion 


	//-----------Below for Cooldown pickup Timer------------
	public void pickUpSpawnCooldown()
	{
		StartCoroutine(spawnCooldown());
	}

	//This courotine waits until the is 0, then allows pickups to be spawned.
	//pickUpCooldownTimer is declared in the inspector window.
	public IEnumerator spawnCooldown()
	{
		yield return new WaitForSeconds(pickUpCooldownTimer);
		spawnManager.GetComponent<SpawnManager>().pickupAllowed();
	}

	//This function turns the alpha of spawn pickup text to 1, allowing it to be viewable. Text appears at the bottom of the screen.
	public void pickUpTextViewable()
	{
		Color temp = pickupText.color;
		temp.a = 1;
		pickupText.color = temp;
		currentPickupText.SetActive(false);
	}

	//function used to designate a new rotation speed of the player paddal.
	public void newPlayerSpeed(float speed)
	{
		playerControl.GetComponent<PlayerController>().playerSpeedis(speed);
	}

	#region Contains functions for takeDamage, addShield, check shield amount

	void checkShieldMax()
	{
		//how much shield the player starts with, will be linked to amount of upgrades.
		shieldMax = 3;
		currentShieldAmount = shieldMax;

		switch (shieldMax)
		{

			case 1:
				shieldBar1.SetActive(true);
				emptyShieldBar1.SetActive(false);
				break;

			case 2:
				shieldBar1.SetActive(true);
				shieldBar2.SetActive(true);

				emptyShieldBar1.SetActive(false);
				emptyShieldBar2.SetActive(false);
				break;

			case 3:
				shieldBar1.SetActive(true);
				shieldBar2.SetActive(true);
				shieldBar3.SetActive(true);

				emptyShieldBar1.SetActive(false);
				emptyShieldBar2.SetActive(false);
				emptyShieldBar3.SetActive(false);
				break;

			case 4:
				shieldBar1.SetActive(true);
				shieldBar2.SetActive(true);
				shieldBar3.SetActive(true);
				shieldBar4.SetActive(true);

				emptyShieldBar1.SetActive(false);
				emptyShieldBar2.SetActive(false);
				emptyShieldBar3.SetActive(false);
				emptyShieldBar4.SetActive(false);
				break;

			case 5:
				shieldBar1.SetActive(true);
				shieldBar2.SetActive(true);
				shieldBar3.SetActive(true);
				shieldBar4.SetActive(true);
				shieldBar5.SetActive(true);

				emptyShieldBar1.SetActive(false);
				emptyShieldBar2.SetActive(false);
				emptyShieldBar3.SetActive(false);
				emptyShieldBar4.SetActive(false);
				emptyShieldBar5.SetActive(false);
				break;
		}

	}

	public void takeDamage()
	{
		int newShield = currentShieldAmount - 1;

		switch (newShield)
		{
			case -1:
				destroyAsteroids();
				endRun();
				SaveGame();
				endGamePopupObject.GetComponent<EndGame_Popup>().updateVariables();
				endGamePopupObject.GetComponent<EndGame_Popup>().updateText();
				//adManager.DisplayAd();
				//MainMenu();
				break;

			case 0:
				shieldBar1.SetActive(false);
				emptyShieldBar1.SetActive(true);
				destroyAsteroids();
				break;

			case 1:
				shieldBar2.SetActive(false);
				emptyShieldBar2.SetActive(true);
				destroyAsteroids();
				break;

			case 2:
				shieldBar3.SetActive(false);
				emptyShieldBar3.SetActive(true);
				destroyAsteroids();
				break;

			case 3:
				shieldBar4.SetActive(false);
				emptyShieldBar4.SetActive(true);
				destroyAsteroids();
				break;

			case 4:
				shieldBar5.SetActive(false);
				emptyShieldBar5.SetActive(true);
				destroyAsteroids();
				break;

		}
		currentShieldAmount = newShield;

		scoreMultiplier = 1;
		scoreMultiplierText.text = null;
		tempAsteroidCounter = 0;
	}


	#region Call this function if ever needed to add shield back to the player.
	public void addShield()
	{
		if(currentShieldAmount < shieldMax)
		{
			int newShield = currentShieldAmount + 1;

			switch (newShield)
			{
				case 1:
					emptyShieldBar1.SetActive(false);
					shieldBar1.SetActive(true);
					break;

				case 2:
					emptyShieldBar2.SetActive(false);
					shieldBar2.SetActive(true);
					break;

				case 3:
					emptyShieldBar3.SetActive(false);
					shieldBar3.SetActive(true);
					break;

				case 4:
					emptyShieldBar4.SetActive(false);
					shieldBar4.SetActive(true);
					break;

				case 5:
					emptyShieldBar5.SetActive(false);
					shieldBar5.SetActive(true);
					break;
			}

			currentShieldAmount = newShield;
		}
		
	}
	#endregion


	#endregion

	public void countAsteroid()
	{
		asteroidCounter += 1;
		tempAsteroidCounter += 1;

		audioManager.playSound("AsteroidDestroyed");

		if(tempAsteroidCounter >= asteroidsNeededToMultiply)
		{
			scoreMultiplier += 1;
			tempAsteroidCounter = 0;
			scoreMultiplierText.text = "x " + scoreMultiplier.ToString();

		}
	}


	public void SaveGame()
	{
		//storeManager.SaveItemLevels();
		SaveSystem.SaveGameManager(this);
	}

	public void LoadPlayer()
	{
		GameManagerData data = SaveSystem.LoadGameManager();
		playerCurrency = data.playerCurrency;

		highScore = data.highScore;

		speedLevel = data.speedLevel;
		rotationSpeedTimer = data.speedTimer;

		invincibilityLevel = data.invincibilityLevel;
		shieldObjTimer = data.invincibilityTimer;

		doublePointsLevel = data.doublePointsLevel;
		doublePointsTimer = data.doublePointsTimer;

		extraPaddleLevel = data.extraPaddleLevel;
		extraPaddleTimer = data.extraPaddleTimer;

		laserbeamLevel = data.laserbeamLevel;
		laserObjTimer = data.laserbeamTimer;

		storeManager.checkStoreInformation();
	}


	public void resetGame()
	{
		playerCurrency = 0;
		highScore = 0;

		speedLevel = 0;
		rotationSpeedTimer = 10;

		invincibilityLevel = 0;
		shieldObjTimer = 10;

		doublePointsLevel = 0;
		doublePointsTimer = 10;

		extraPaddleLevel = 0;
		extraPaddleTimer = 10;

		laserbeamLevel = 0;
		laserObjTimer = 6;

		highScoreText.text = highScore.ToString();
		currencyText.text = "$" + playerCurrency.ToString();

		storeManager.checkStoreInformation();
		SaveSystem.SaveGameManager(this);
	}
}
