using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour {

    public Slider flyHealthBar;

    public float delay = 0.0f;


    void OnTriggerEnter(Collider other)//registers collison between flyswatter and fly
    {
        if (delay >= 0.8f)//adds dely so the damage can not be spammed on fly
        {
           if (GameObject.FindWithTag("player").GetComponent<playerScript>().isSwinging)//uses isSwinging from another script so damage is only registered when the player is swinging flyswatter
            {
                flyHealthBar.value -= 20;//takes 20hp from flys healthbar
                Debug.Log("Hit");
                delay = 0;
            }

        }
    }
	
	void Update () {

        delay += Time.deltaTime;//updates dely in seconds

    }
  
}
