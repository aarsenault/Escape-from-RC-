using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour 
{
	Vector3 Move;

	float CamWidthX = 6.2f;
	float CamHeightY = 3.4f; 
	public static float Speed = 0.09f;
	public static int CoolDownCnt; 
	public bool IsDisappear = false;

	// Use this for initialization
	void Start() 
    {
        Move = transform.position;
	}
	
	// Update is called once per frame
	void Update()
    {
		TeleportCheck(); 
		MovementUpdate();
		MovementConstraints();
    }

	private void TeleportCheck()
	{
		IsDisappear = false; 
		// Debug.Log("Dissapear = False");
		
		// Teleport
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (CoolDownCnt == 0)
			{
				// Teleport has occured
				IsDisappear = true; 
				Debug.Log("Dissapear = True");
				Move.x = Random.Range(-6.2f, 6.2f); 
				Move.y = Random.Range(-3.4f, 3.4f);
				CoolDownCnt = 100;
			}
		}

		CoolDownCnt--; 
		if (CoolDownCnt < 0)
			CoolDownCnt = 0; 
	}

	private void MovementUpdate()
	{
		// Movement
		if (Input.GetKey(KeyCode.LeftArrow))
			Move.x -= Speed;
		if (Input.GetKey(KeyCode.RightArrow))
			Move.x += Speed;
		// + is up in y direction
		if (Input.GetKey(KeyCode.UpArrow))
			Move.y += Speed;
		if (Input.GetKey(KeyCode.DownArrow))
			Move.y -= Speed;

		transform.position = Move;

	}

	private void MovementConstraints()
	{
		// Check if the edge of screen
		// constrain Movement if needed

		if (transform.position.x < CamWidthX * -1)
			Move.x = CamWidthX * -1;
		if (transform.position.x > CamWidthX * 1)
			Move.x = CamWidthX * 1; 
		if (transform.position.y < CamHeightY * -1)
			Move.y = CamHeightY * -1;
		if (transform.position.y > CamHeightY * 1)
			Move.y = CamHeightY * 1; 

	}
}