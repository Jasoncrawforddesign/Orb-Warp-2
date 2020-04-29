using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	public float playerSpeed;

	public GameObject forwardSpline;
	public GameObject backwardSpline;

	private GameObject me;

    // Start is called before the first frame update
    void Start()
    {
		me = this.gameObject;
    }

    // Update is called once per frame
	// Allows keyboard or mobile touch controls.
    void Update()
    {
		touchControls();
		KeyboardControls();
	}

	//Controls used for mobile.
	public void touchControls()
	{
		if ((Input.touchCount > 0))

		{
			for (int i = 0; i < Input.touchCount; ++i)
			{
				if ((Input.GetTouch(i).phase == TouchPhase.Stationary) || (Input.GetTouch(i).phase == TouchPhase.Moved))
				{

					//if the screen was touched it checks to see if it is below 50% of the X axis on the screen.
					//if this is true the player rotates right.
					Vector3 CheckMousePos = Camera.main.ScreenToViewportPoint(Input.GetTouch(i).position);

					if (CheckMousePos.x > .5f)

					{
						transform.RotateAround(this.transform.position, Vector3.forward, (-playerSpeed * 10) * Time.deltaTime);
					}

					else if (CheckMousePos.x < .5f)

					{
						transform.RotateAround(this.transform.position, Vector3.forward, (playerSpeed * 10) * Time.deltaTime);
					}
				}
			}
		}
	}


	//Keyboard Controls.
	void KeyboardControls()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.RotateAround(this.transform.position, Vector3.forward, (playerSpeed * 10) * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.RotateAround(this.transform.position, Vector3.forward, (-playerSpeed * 10) * Time.deltaTime);
		}
	}

	//This function resets the player paddle to it's initial starting location.
	public void resetPlayer()
	{
		me.transform.rotation = new Quaternion(0, 0, 0, 0);
	}

	//This function is used to update the player paddles rotation speed.
	public void playerSpeedis(float newSpeed)
	{
		playerSpeed = newSpeed;
	}

}
