using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleeScript : MonoBehaviour {

    //Initialize variables
    public Transform player;
    public Transform healthRegen1;
    public Transform healthRegen2;
    public Transform healthRegen3;
    public Transform healthRegen4;

	public Transform flyHidingPosition1;

    public float flyVelocityWander = 0.03f;
    public float flyVelocityEvade = 0.15f;
	public float flyVelocityTowardRegen = 0.0f;

    public float xRot;
    public float zRot;

    public float xPos;
    public float yPos;
    public float zPos;
    Vector3 pos;

    public float timer = 0.0f;

    public Slider flyHealthBar;

    public bool flyIsHealing;
	public bool flyIsHiding;


	void SpawnFly()//spawns fly in random x, y and z position in between ranges i set (within the house)
    {
        xPos = Random.Range(242.0f, 273.0f);
        yPos = Random.Range(1.0f, 3.0f);
        zPos = Random.Range(224.0f, 258.0f);

        pos = new Vector3(xPos, yPos, zPos);

        transform.position = pos;
    }

    void FlyWander()
    {
        if (Vector3.Distance(player.position, this.transform.position) > 10)//only runs if player is far away from fly
        {
            timer += Time.deltaTime;//updates timer in seconds

            this.transform.Translate(0, flyVelocityWander, 0);//adds a velocity to the flys forward axix

            if (timer >= 2.5f)
            {
				xRot = Random.Range(-25.0f, 25.0f);//updates fly x rotation from a random range every 2.5 seconds
				zRot = Random.Range(-25.0f, 25.0f);//updates fly z rotation from a random range every 2.5 seconds
                this.transform.Rotate(xRot, 0, zRot);//applys this rotation to fly every 2.5 seconds 

                flyVelocityWander = Random.Range(0.02f, 0.04f);//updates fly velocity from a random range every 2.5 seconds

                timer = 0.0f;//resets the timer
            }

        }
    }

    void FlyEvade()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 10)//only runs if player is close to the fly
        {
            timer += Time.deltaTime;

            this.transform.Translate(0, flyVelocityEvade, 0);//gives the fly a evade velocity

            if (timer >= 2.5f && flyHealthBar.value > 40)//applys new values to velocity, xrot and zrot every 2.5 seconds when fly is above 40 hp
            {
                xRot = Random.Range(-10.0f, 10.0f);
                zRot = Random.Range(-10.0f, 10.0f);
                this.transform.Rotate(xRot, 0, zRot);

                flyVelocityEvade = Random.Range(0.13f, 0.17f);

                timer = 0.0f;
            }

			if (flyHealthBar.value <= 40 && flyHealthBar.value > 20)//applys new values to velocity, xrot and zrot every 2.5 seconds when fly is less than or equal to 40hp but greater than 20hp
            {
                if (timer >= 2.5f)
                {
                    xRot = Random.Range(-10.0f, 10.0f);
                    zRot = Random.Range(-10.0f, 10.0f);
                    this.transform.Rotate(xRot, 0, zRot);

                    timer = 0.0f;
                }

                flyVelocityEvade = Random.Range(0.18f, 0.20f);
            }

			if (flyHealthBar.value <= 20)//applys new values to velocity, xrot and zrot every 2.5 seconds when fly is less than or equal to 20hp
            {
                if (timer >= 2.5f)
                {
                    xRot = Random.Range(-10.0f, 10.0f);
                    zRot = Random.Range(-10.0f, 10.0f);
                    this.transform.Rotate(xRot, 0, zRot);

                    timer = 0.0f;
                }

                flyVelocityEvade = Random.Range(0.21f, 0.23f);
            }
		
        }
    }


    void flyTowardsRegen()
    {
		flyVelocityTowardRegen = Random.Range(0.08f, 0.13f);//gives the fly a fly towards regen velocity

        if (GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal1)//takes the flyCanHeal1 variable from healthRegenScript
        {
			transform.position = Vector3.MoveTowards(transform.position, healthRegen1.position, flyVelocityTowardRegen);//if flyCanHeal1 is true then fly towards regen box 1
        }

        if (GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal2)
        {
			transform.position = Vector3.MoveTowards(transform.position, healthRegen2.position, flyVelocityTowardRegen);
        }
      
        if (GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal3)
        {
			transform.position = Vector3.MoveTowards(transform.position, healthRegen3.position, flyVelocityTowardRegen);
        }

        if (GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal4)
        {
			transform.position = Vector3.MoveTowards(transform.position, healthRegen4.position, flyVelocityTowardRegen);
        }     
    }

    void flyTowardsRegenCheck()
    {
        if (GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal1 ||
            GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal2 ||
            GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal3 ||
            GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal4)//checks if any of the flyCanHeal variables are true, if so flyIsHealing = true
        {
            flyIsHealing = true;
        }
        else
        {
            flyIsHealing = false;//if not flyIsHealing = false
        }

    }

    void flyRegenHealth()
    {
        if (Vector3.Distance(this.transform.position, healthRegen1.position) < 1 && GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal1)//when flyCanHeal is true and the fly is close enough to box
        {
            flyHealthBar.value = 60;//heal the fly to 60hp
        }

        if (Vector3.Distance(this.transform.position, healthRegen2.position) < 1 && GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal2)
        {
            flyHealthBar.value = 60;
        }

        if (Vector3.Distance(this.transform.position, healthRegen3.position) < 1 && GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal3)
        {
            flyHealthBar.value = 60;
        }

        if (Vector3.Distance(this.transform.position, healthRegen4.position) < 1 && GameObject.FindWithTag("healthRegen").GetComponent<HealthRegenScript>().flyCanHeal4)
        {
            flyHealthBar.value = 60;
        }

    }

	void flyTowardsHidingPosition()
	{

		if (GameObject.FindWithTag("hidingPosition").GetComponent<HidingPositionScript>().flyCanHide1) 
		{
			transform.position = Vector3.MoveTowards(transform.position, flyHidingPosition1.position, 0.05f);//if flyCanHide is true, fly towards hiding spot at given speed
		}
	}

	void flyTowardsHidingCheck()
	{
		if (GameObject.FindWithTag("hidingPosition").GetComponent<HidingPositionScript>().flyCanHide1)//if flyCanHide is true the set fLyIsHiding to true
		{
			flyIsHiding = true;
		}
		else
		{
			flyIsHiding = false;//if not flyIsHiding = false
		}

	}
		

    void Start () {

        SpawnFly();//call spawnFly function in start function

    }
	
	void Update () {

        flyTowardsRegenCheck();
		flyTowardsHidingCheck ();
        flyRegenHealth();


        if (flyHealthBar.value <= 0)
        {
			Destroy(gameObject);//if flys health is 0 then destroy the fly object
            return;
        }

		if (flyIsHealing == true && flyIsHiding == false) {
			flyTowardsRegen ();//fly toward regen when flyIsHealing is true
		} else if (flyIsHealing == false && flyIsHiding == true) {
			flyTowardsHidingPosition ();//fly toward hiding when flyIsHiding is true
		} else {
			FlyWander ();
			FlyEvade ();//otherwise call the main 2 movment algorithms
		}  
        
    }

}
