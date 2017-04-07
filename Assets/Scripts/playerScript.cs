using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public attackAnimation _attackAnimation;
    public bool isSwinging;


    void FalseSwing()//sets is swinging to false
    {
        isSwinging = false;
    }

    void Update () {

        if (Input.GetButtonDown("Fire1"))//checks if left mouse button has been clicked
        {
            _attackAnimation.attack();//plays attack animation 
            isSwinging = true;//sets isSwinging to true so that hp will be taken off fly, only when swinging flyswatter
			Invoke("FalseSwing", 0.2f);//invokes false swing function in 0.2 seconds to add small delay so that damage can't be spammed
        }

    }
}
