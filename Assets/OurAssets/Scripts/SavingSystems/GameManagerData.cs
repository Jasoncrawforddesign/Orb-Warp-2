using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManagerData {

	public int playerCurrency;

	public int highScore;

	public int speedLevel;
	public float speedTimer;

	public int invincibilityLevel;
	public float invincibilityTimer;

	public int doublePointsLevel;
	public float doublePointsTimer;

	public int extraPaddleLevel;
	public float extraPaddleTimer;

	public int laserbeamLevel;
	public float laserbeamTimer;

	public GameManagerData(GameManager gm)
	{
		playerCurrency = gm.playerCurrency;

		highScore = gm.highScore;

		speedLevel = gm.speedLevel;
		speedTimer = gm.rotationSpeedTimer;

		invincibilityLevel = gm.invincibilityLevel;
		invincibilityTimer = gm.shieldObjTimer;

		doublePointsLevel = gm.doublePointsLevel;
		doublePointsTimer = gm.doublePointsTimer;

		extraPaddleLevel = gm.extraPaddleLevel;
		extraPaddleTimer = gm.extraPaddleTimer;

		laserbeamLevel = gm.laserbeamLevel;
		laserbeamTimer = gm.laserObjTimer;

	}
}
