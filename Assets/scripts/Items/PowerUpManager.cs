using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour 
{

	public GameObject PowerUpPrefab;

	public bool IsPowered; 
	public static int PowerUpMeter;
	int Timer; 

	// Use this for initialization
	void Start() 
    {	 

		IsPowered = false; 
		PowerUpMeter = 50; // default bonus on start 
		Timer = 1; 
		// creates a randomSpawn object
		// with random x, y coordinates
		float x = Random.Range(-6.2f, 6.2f); 
		float y = Random.Range(-3.4f, 3.4f);
		float z = transform.position.z;  

		// sets the position of the object to the randomSpawn
		transform.position = new Vector3(x,y,z);

		GameObject.Instantiate(PowerUpPrefab, transform.position, transform.rotation); 
	}
	
	// Update is called once per frame
	void Update()
    {
		PowerUpSpawn(); 
		PowerCheck(); 
	
	}

	// Spawns a new powerup every 300 frames
	void PowerUpSpawn()
	{ 
		if (Timer % 300 == 0)		
		{
			// finds the PowerUp game object
			// PowerUpPrefab = GameObject.Find("PowerUpPrefab");
		
			// with random x, y coordinates
			float x = Random.Range(-6.2f, 6.2f); 
			float y = Random.Range(-3.4f, 3.4f);
			float z = transform.position.z;  

			// sets the position of the object to the transform.position
			transform.position = new Vector3(x,y,z);

			// create new powerup
			GameObject.Instantiate(PowerUpPrefab, 
				transform.position, 
				transform.rotation, 
				this.gameObject.transform); 		
		}
		Timer++; 
    }

	void PowerCheck()
	{
		// flips the bool state when Z pressed
		if (Input.GetKeyDown(KeyCode.Z) && (PowerUpMeter > 0) )  
		{
			// turns the PowerUp off if already on and visa-versa
			IsPowered = !IsPowered;
		}

		// runs the powerup
		if (IsPowered)
		{
			PowerUp(); 
		}
		else
			PowerDown();  
	}

	void PowerUp()
	{
		// activate the powered state
		CubeController.Speed =  .2f;

		// countdown
		PowerUpMeter -= 1;

		// Switch the state at countdown
		if (PowerUpMeter == 0)
		{
			PowerDown();
		}
		
	}
	void PowerDown()
	{
		IsPowered = false; 
		CubeController.Speed = 0.09f; 		
	}

	
}


