using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAnimate : MonoBehaviour 
{
	int RandRotateDir; 
	float RandRotateSpeed; 

	// Use this for initialization
	void Start() 
    {
		// 0-2 inclusive gives 0 or 1, Function goes from -1 to 1
        RandRotateDir = Random.Range(0,2)* 2 - 1 ;  
        RandRotateSpeed = Random.Range(3.0f, 9.0f);
	}
	
	// Update is called once per frame
	void Update()
    {	
		transform.Rotate(0f, 0f, RandRotateDir * RandRotateSpeed);
    }
}