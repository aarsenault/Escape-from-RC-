using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour 
{
	void OnGUI()
	{
		GUI.contentColor = Color.blue;
		GUI.Label( new Rect(15,15,Screen.width, Screen.height),
			string.Format("<b>Power Up: {0}</b>", PowerUpManager.PowerUpMeter.ToString())
		 );

		GUI.contentColor = Color.blue;
		GUI.Label( new Rect(15,35,Screen.width, Screen.height),
			string.Format("<b>Cool Down: {0}</b>", CubeController.CoolDownCnt.ToString())
		 );
	}
}