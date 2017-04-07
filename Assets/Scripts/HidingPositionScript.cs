using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPositionScript : MonoBehaviour {

	public Transform fly;
	public Transform player;
	public Transform hidingPos1;

	public bool flyCanHide1;


	void Update () 
	{
		if (fly != null)//if fly object is not destroyed
		{
			if (Vector3.Distance (fly.position, hidingPos1.position) < 7 && Vector3.Distance (fly.position, player.position) > 3)//checks that fly is close enough to hiding position and far enough away from player
			{
				Debug.Log ("fly can hide");
				flyCanHide1 = true;//if yes flyCanHide1 = true for use in main movement script
			} else 
			{
				flyCanHide1 = false;//if not then false
			}
		}
		
	}
}
