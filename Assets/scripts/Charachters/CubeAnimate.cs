using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimate : MonoBehaviour 
{

	// Use this for initialization
	void Start() 
    {
        
	}
	
	// Update is called once per frame
	void Update()
    {
		// called a generic method
        SpriteRenderer CubeRender = GetComponent<SpriteRenderer>();
		// Color is stored as a struct, therefore need to coppy whole thing. 
		Color colour = CubeRender.color; 
		

		// return an instance of CubeController component - that is the 
		// component we already spawned. 
		

		if (GetComponent<CubeController>().IsDisappear)
		{
			// if teleport engaged
			Debug.Log("colour.a = 0");
			colour.a = 0; 
		}
		else
		{
			// Debug.Log("colour = 1");
			// Linear interpolation
			colour.a = Mathf.Lerp(colour.a, 1f, 0.029f);

		}

		// Need to reset the colour
		CubeRender.color = colour; 
	}
}