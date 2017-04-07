using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRegenScript : MonoBehaviour
{
    public Transform fly;
    public Transform healthRegen1;
    public Transform healthRegen2;
    public Transform healthRegen3;
    public Transform healthRegen4;

    public bool flyCanHeal1;
    public bool flyCanHeal2;
    public bool flyCanHeal3;
    public bool flyCanHeal4;

    public Slider flyHealthBar;


    void Update()
    {
		if (fly != null)//if there is still a fly object (not destroyed)
        {
            if (Vector3.Distance(fly.position, healthRegen1.position) < 10 && flyHealthBar.value <= 20)//checks if fly is close enough to the regen box and is at 20hp
            {
                Debug.Log("Fly is in healing distance of health regen 1");
                flyCanHeal1 = true;//if yes set flyCanHeal1 to true for use in the main movement script
            }
            else
            {
                flyCanHeal1 = false;//if not set false
            }

            if (Vector3.Distance(fly.position, healthRegen2.position) < 15 && flyHealthBar.value <= 20)
            {
                Debug.Log("Fly is in healing distance of health regen 2");
                flyCanHeal2 = true;
            }
            else
            {
                flyCanHeal2 = false;
            }

            if (Vector3.Distance(fly.position, healthRegen3.position) < 10 && flyHealthBar.value <= 20)
            {
                Debug.Log("Fly is in healing distance of health regen 3");
                flyCanHeal3 = true;
            }
            else
            {
                flyCanHeal3 = false;
            }

            if (Vector3.Distance(fly.position, healthRegen4.position) < 10 && flyHealthBar.value <= 20)
            {
                Debug.Log("Fly is in healing distance of health regen 4");
                flyCanHeal4 = true;
            }
            else
            {
                flyCanHeal4 = false;
            }
        } 

    }

}
