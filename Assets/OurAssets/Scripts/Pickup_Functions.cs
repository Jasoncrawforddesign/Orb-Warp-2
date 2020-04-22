using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Functions : MonoBehaviour
{
	public GameObject playerControl;
	public GameObject gm;

	public bool isRotationPickup;
	public bool isExtraPaddlePickup;
	public bool isOneUseShieldPickup;
	public bool isDoublePointsPickup;
	public bool isLaserBeamPickup;

	private int typeNum;

	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void checkPickupType()
	{
		if (isRotationPickup == true)
		{
			typeNum = 1;
		}

		if (isExtraPaddlePickup == true)
		{
			typeNum = 2;
		}
		if (isOneUseShieldPickup == true)
		{
			typeNum = 3;
		}
		if (isDoublePointsPickup == true)
		{
			typeNum = 4;
		}
		if (isLaserBeamPickup == true)
		{
			typeNum = 5;
		}
	}

	void pickupType()
	{
		switch (typeNum)
		{
			case 1:
				//isRotationPickup call function;
				break;

			case 2:
				//isExtraPaddlePickup call function;
				break;

			case 3:
				//isOneUseShieldPickup call function;
				break;

			case 4:
				//isDoublePointsPickup call function;
				break;

			case 5:
				//isLaserBeamPickup call function;
				break;
		}
		
	}
}
