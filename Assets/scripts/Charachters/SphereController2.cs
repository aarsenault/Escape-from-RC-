using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController2 : MonoBehaviour 
{

	GameObject CubeReference; 
	float Speed = 0.08f; 
	public Vector3 CubeRefPosition;
	public int Timer; 

	float smallrandx;
	float smallrandy;
	float teenyamount = 2.5f;

	void Start() 
    {
		// Reference to our Cube
		CubeReference = GameObject.Find("Cube"); 
		Timer = 1; 
		
	}
	
	// Update is called once per frame
	void Update()
    {
		Movement();
		EnemyProximity();
		SpawnEnemy(); 
    }

	private void Movement()
	{
		if (Timer%20==0)
		{
			smallrandx = Random.Range(-teenyamount, teenyamount); 
			smallrandy = Random.Range(-teenyamount, teenyamount);
		}

		Vector3 newtarget = new Vector3(CubeRefPosition.x + smallrandx, 
									CubeRefPosition.y + smallrandy,
									CubeRefPosition.z);

		transform.position = Vector3.MoveTowards(transform.position, newtarget, Speed);
		CubeRefPosition = CubeReference.transform.position;

	}

	private void EnemyProximity()
	{
	    Vector2 Distance;
		// check position
		Distance.x = transform.position.x - CubeRefPosition.x;
		Distance.y = transform.position.y - CubeRefPosition.y;

		// If occupying same space, you're dead
		if ( (Mathf.Abs(Distance.x) < 0.02f) && (Mathf.Abs(Distance.y) < 0.02f) )
		{
			GameObject.Destroy(CubeReference); 
			Debug.Log("You have been eaten!"); 
		}

	}

	private void SpawnEnemy()
	{
		// Spawn Duplicates every 500 timer ticks
		if (Timer % 200 == 0)
		{	
			float x = Random.Range(-6.2f, 6.2f); 
			float y = Random.Range(-3.4f, 3.4f);
			float z = transform.position.z; 

			GameObject.Instantiate( this.gameObject, new Vector3(x,y,z) , transform.rotation);
		}

		Timer++;			

	}
}