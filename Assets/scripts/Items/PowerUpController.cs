using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script attached to GameObject Powerup
public class PowerUpController: MonoBehaviour 
{
	// New fields - Can be used in all methods
	GameObject CubeReference;
	
	public int Timer = 1; 

	// Use this for initialization
	void Start() 
    {
        CubeReference = GameObject.Find("Cube");
		// Give bonus power at start
		
	}
	
	// Update is called once per frame
	void Update()
    { 
		PowerUpAnimate();
		// if ate - Destroy
		// if time up - Destroy
		DestroyPowerUp(); 
    }

	private bool AtePowerUp()
	{
		// Eat Powerup
		// set the distance between the player and powerup
		Vector2 Distance = new Vector2( 
			transform.position.x - CubeReference.transform.position.x,
			transform.position.y - CubeReference.transform.position.y
		);

		// if cube reaches powerup
		if ( (Mathf.Abs(Distance.x) < 0.30f) && (Mathf.Abs(Distance.y) < 0.30f) )
			return true;
		else
			return false; 
	}

	private void DestroyPowerUp()
	{
		Timer++; 
		if (AtePowerUp())
		{
			GameObject.Destroy(this.gameObject); 
			PowerUpManager.PowerUpMeter += 100;
		}

		if (Timer % 150 == 0)
		{
			GameObject.Destroy(this.gameObject);
		}
	}

void PowerUpAnimate()
	{
		float increment = Mathf.Sin(2*Mathf.PI/60 * Timer );
		// transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1,1,1), 0.05f);

		transform.localScale = new Vector3(increment, increment, transform.position.z); 
	}


} // update loop